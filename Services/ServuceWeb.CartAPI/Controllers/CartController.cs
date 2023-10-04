using Microsoft.AspNetCore.Mvc;
using ServiceWeb.CartAPI.DTO;
using ServiceWeb.CartAPI.Repository.Interface;
using ServiceWeb.CartAPI.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace ServiceWeb.CartAPI.Controllers
{
    [ApiController]
    public class CartController : Controller
    {
        private ICartRepository _cartRepository;
        private IProductRepository _productRepository;

        public CartController(ICartRepository repository, IProductRepository productRepository)
        {
            _cartRepository = repository;
            _productRepository = productRepository;
        }

        [HttpPost]
        [Route("api/v1/cart/add-cart")]
        public async Task<ActionResult<CartDTO>> AddCart(CartDTO dto)
        {

            var product = await _productRepository.IsProductCodeValid(dto.CartItems.FirstOrDefault().ProductCode);
            
            if(!product)
            {
                return NotFound(new ResultViewModel
                {
                    Message = "Produto não encontrado",
                    Success = false,
                    Data = dto
                });
            };

            var cart = await _cartRepository.SaveOrUpdateCart(dto);
            if (cart == null) return NotFound();
            return Ok(cart);
        }
    }
}
