using AutoMapper;
using ServiceWeb.CartAPI.DTO;
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

            }
            catch (Exception ex)
            {

                throw ex;
            }


            return null;
        }
    }
}
