using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServiceWeb.CartAPI.DTO;
using ServiceWeb.CartAPI.Model.Entities;
using ServiceWeb.CartAPI.Repository.Interface;
using ServuceWeb.CartAPI.Model.Context;

namespace ServiceWeb.CartAPI.Repository
{
    public class CartRepository : ICartRepository
    {

        private readonly MySqlCartContext _context;
        private IMapper _mapper;
        private readonly HttpClient _httpClient;

        public CartRepository(MySqlCartContext context, IMapper mapper, HttpClient httpCliente)
        {
            _context = context;
            _mapper = mapper;
            _httpClient = httpCliente;
        }
        public async Task<CartDTO> SaveOrUpdateCart(CartDTO dto)
        {
            try
            {
                //Map DTO/MODEL
                Cart cart = _mapper.Map<Cart>(dto);

                //CHECK HEADER
                var cartHeader = await _context.CartHeaders.AsNoTracking().FirstOrDefaultAsync(c => c.UserId == cart.CartHeader.UserId);


                //HEADER NÃO EXISTE (INSERE)
                if (cartHeader == null)
                {
                    _context.CartHeaders.Add(cart.CartHeader);
                    await _context.SaveChangesAsync();
                    //salvar detalhes do cabeçalho
                    cart.CartItems.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                    _context.CartItems.Add(cart.CartItems.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
                else 
                {
                    //HEADER EXISTE (ALTERA)
                    var cartDatail = await _context.CartItems.AsNoTracking().FirstOrDefaultAsync
                        (c => c.ProductCode == cart.CartItems.FirstOrDefault().ProductCode && c.CartHeaderId == cartHeader.Id);

                    if (cartDatail == null)
                    {
                        cart.CartItems.FirstOrDefault().CartHeaderId = cartHeader.Id;
                        _context.CartItems.Add(cart.CartItems.FirstOrDefault());
                        await _context.SaveChangesAsync();
                    }
                    else 
                    {
                        cartDatail.Quantity += cart.CartItems.FirstOrDefault().Quantity;
                        _context.CartItems.Update(cartDatail);
                        await _context.SaveChangesAsync();
                    }

                }

                return _mapper.Map<CartDTO>(cart);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CartDTO> FindCartByUserId(string userId)
        {
            try
            {
                Cart cart = new()
                {
                    CartHeader = await _context.CartHeaders
                  .FirstOrDefaultAsync(c => c.UserId == userId) ?? new CartHeader(),
                };
                cart.CartItems = _context.CartItems.Where(c => c.CartHeaderId == cart.CartHeader.Id);

                return _mapper.Map<CartDTO>(cart);

            }
            catch (Exception ex)
            {

                throw ex; 
            }
          
        }

        public async Task<bool> RemoveCart(int cartItemsId)
        {
            try
            {
                CartItem cartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.Id == cartItemsId);

                _context.CartItems.Remove(cartItem);

                await _context.SaveChangesAsync();

                int countItems = _context.CartItems.Where(c => c.CartHeaderId == cartItem.CartHeaderId).Count();

                if (countItems <= 0)
                {
                    var removeCartHeader = await _context.CartHeaders.FirstOrDefaultAsync(h => h.Id == cartItem.CartHeaderId);
                    _context.CartHeaders.Remove(removeCartHeader);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
        }

        public async Task<bool> ClearCart(string userId)
        {
            CartHeader cartHeader = await _context.CartHeaders.FirstOrDefaultAsync(h => h.UserId == userId);

            if (cartHeader != null)
            {
                _context.CartItems.RemoveRange(_context.CartItems.Where(c => c.CartHeaderId == cartHeader.Id));
                await _context.SaveChangesAsync();

                _context.CartHeaders.Remove(cartHeader);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
