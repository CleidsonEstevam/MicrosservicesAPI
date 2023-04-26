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

        public async Task<ProductDTO> Update(ProductDTO DTO)
        {
            Product product = _mapper.Map<Product>(DTO);

            Product productDb = await _context.Products.Where(x => x.Code == DTO.Code).FirstOrDefaultAsync();
            if (productDb == null)
                throw new Exception("Produto não encontrado!");
            

            productDb.ChangeCategory(product.Category);
            productDb.ChangePackagingType(product.PackagingType);
            productDb.ChangePackagingQuantity(product.PackagingQuantity);
            productDb.ChangePrice(product.Price);

            _context.Products.Update(productDb);

            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(productDb);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _context.Products.Where(x => x.Id == id)
                  .SingleOrDefaultAsync();
                if (product == null) return false;
                _context.Products.Remove(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
