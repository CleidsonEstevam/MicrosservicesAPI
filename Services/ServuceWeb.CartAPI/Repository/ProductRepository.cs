using AutoMapper;
using ServiceWeb.CartAPI.Repository.Interface;
using ServuceWeb.CartAPI.Model.Context;
using System.Net.Http;

namespace ServiceWeb.CartAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlCartContext _context;
        private IMapper _mapper;
        private readonly HttpClient _httpClient;


        public ProductRepository(MySqlCartContext context, IMapper mapper, HttpClient httpCliente)
        {
            _context = context;
            _mapper = mapper;
            _httpClient = httpCliente;
        }
        public async Task<bool> IsProductCodeValid(string productCode)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/v1/product/find-by-id/{productCode}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }
    }
}
