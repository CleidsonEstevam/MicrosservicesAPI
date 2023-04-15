using ServiceWeb.ProductAPI.DTO;
using ServiceWeb.ProductAPI.Repository.Interface;

namespace ServiceWeb.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Task<ProductDTO> Create(ProductDTO vo)
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

        public Task<ProductDTO> Update(ProductDTO vo)
        {
            throw new NotImplementedException();
        }
    }
}
