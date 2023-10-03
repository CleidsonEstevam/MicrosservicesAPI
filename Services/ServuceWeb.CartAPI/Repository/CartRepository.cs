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

        public CartRepository(MySqlCartContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CartDTO> SaveOrUpdateCart(CartDTO dto)
        {
            Cart cart = _mapper.Map<Cart>(dto);
            ////Checks if the product is already saved in the database if it does not exist then save
            //var product = await _context.Products.FirstOrDefaultAsync(
            //    p => p.ProductCode == dto.CartItems.FirstOrDefault().ProductCode);

            //if (product == null)
            //{
            //    _context.Products.Add(cart.CartItems.FirstOrDefault().Product);
            //    await _context.SaveChangesAsync();
            //}

            ////Check if CartHeader is null

            //var cartHeader = await _context.CartHeaders.AsNoTracking().FirstOrDefaultAsync(
            //    c => c.UserId == cart.CartHeader.UserId);

            //if (cartHeader == null)
            //{
            //    //Create CartHeader and CartDetails
            //    _context.CartHeaders.Add(cart.CartHeader);
            //    await _context.SaveChangesAsync();
            //    cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
            //    cart.CartDetails.FirstOrDefault().Product = null;
            //    _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
            //    await _context.SaveChangesAsync();
            //}
            //else
            //{
            //    //If CartHeader is not null
            //    //Check if CartDetails has same product
            //    var cartDetail = await _context.CartDetails.AsNoTracking().FirstOrDefaultAsync(
            //        p => p.ProductId == cart.CartDetails.FirstOrDefault().ProductId &&
            //        p.CartHeaderId == cartHeader.Id);

            //    if (cartDetail == null)
            //    {
            //        //Create CartDetails
            //        cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeader.Id;
            //        cart.CartDetails.FirstOrDefault().Product = null;
            //        _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
            //        await _context.SaveChangesAsync();
            //    }
            //    else
            //    {
            //        //Update product count and CartDetails
            //        cart.CartDetails.FirstOrDefault().Product = null;
            //        cart.CartDetails.FirstOrDefault().Count += cartDetail.Count;
            //        cart.CartDetails.FirstOrDefault().Id = cartDetail.Id;
            //        cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetail.CartHeaderId;
            //        _context.CartDetails.Update(cart.CartDetails.FirstOrDefault());
            //        await _context.SaveChangesAsync();
            //    }
            //}
            return _mapper.Map<CartDTO>(cart);
        }
    }
}
