using Microsoft.AspNetCore.Mvc;
using ServiceWeb.CartAPI.DTO;
using ServiceWeb.CartAPI.Repository.Interface;
using Swashbuckle.AspNetCore.Annotations;

namespace ServiceWeb.CartAPI.Controllers
{
    [ApiController]
    public class CartController : Controller
    {
        private ICartRepository _cartRepository;
        public CartController(ICartRepository repository)
        {
            _cartRepository = repository;
        }

        [HttpPost]
        [Route("api/v1/cart/add-cart")]
        public async Task<ActionResult<CartDTO>> AddCart(CartDTO dto)
        {
            var cart = await _cartRepository.SaveOrUpdateCart(dto);
            if (cart == null) return NotFound();
            return Ok(cart);
        }
    }
}
