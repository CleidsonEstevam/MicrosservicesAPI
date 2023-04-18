using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(ProductDTO DTO)
        {
            Product product = _mapper.Map<Product>(DTO);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Update(ProductDTO vo)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDTO>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> FindById(long id)
        {
            Product product = await _context.Products.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(product);
        }

    }
}
