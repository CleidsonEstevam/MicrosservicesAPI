using ServiceWeb.CartAPI.DTO;

namespace ServiceWeb.CartAPI.Repository.Interface
{
    public interface ICartRepository
    {
        Task<CartDTO> SaveOrUpdateCart(CartDTO cart);

        Task<CartDTO> FindCartByUserId(string userId);
    }
}
