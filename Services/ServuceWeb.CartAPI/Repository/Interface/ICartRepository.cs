using ServiceWeb.CartAPI.DTO;

namespace ServiceWeb.CartAPI.Repository.Interface
{
    public interface ICartRepository
    {
        Task<CartDTO> SaveOrUpdateCart(CartDTO cart);

        Task<CartDTO> FindCartByUserId(string userId);

        Task<bool> RemoveCart(int id);

        Task<bool> ClearCart(string userId);
    }
}
