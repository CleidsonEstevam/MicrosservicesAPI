using AutoMapper;
using ServiceWeb.ProductAPI.DTO;
using ServiceWeb.ProductAPI.Model.Context;
using ServiceWeb.ProductAPI.Model.Entities;
using ServiceWeb.ProductAPI.Repository.Interface;

namespace ServiceWeb.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public ProductRepository(MySQLContext context, IMapper mapper) 
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<ProductDTO> Create(ProductDTO DTO)
        {
            Product product = _mapper.Map<Product>(DTO);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public Task<ProductDTO> Update(ProductDTO vo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> FindById(long id)
        {
            throw new NotImplementedException();
        }

    }
}
