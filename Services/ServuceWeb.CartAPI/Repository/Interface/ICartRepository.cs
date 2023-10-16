using Microsoft.AspNetCore.Mvc;
using ServiceWeb.CartAPI.DTO;
using ServiceWeb.CartAPI.DTO.Messages;

namespace ServiceWeb.CartAPI.Repository.Interface
{
    public interface ICartRepository
    {
        Task<CartDTO> SaveOrUpdateCart(CartDTO cart);
        Task<CartDTO> FindCartByUserId(string userId);
        Task<bool> RemoveCart(int id);
        Task<bool> ClearCart(string userId);
        Task<ActionResult<CheckoutHeaderDTO>> Checkout(CheckoutHeaderDTO dto);
    }
}
