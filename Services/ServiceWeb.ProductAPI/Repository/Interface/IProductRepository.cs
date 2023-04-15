using ServiceWeb.ProductAPI.DTO;

namespace ServiceWeb.ProductAPI.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> FindAll();
        Task<ProductDTO> FindById(long id);
        Task<ProductDTO> Create(ProductDTO vo);
        Task<ProductDTO> Update(ProductDTO vo);
        Task<bool> Delete(long id);
    }
}
