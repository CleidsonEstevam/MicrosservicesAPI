using Microsoft.AspNetCore.Mvc;
using ServiceWeb.CartAPI.DTO;
using ServiceWeb.CartAPI.DTO.Messages;
using ServiceWeb.CartAPI.RabbitMQSender;
using ServiceWeb.CartAPI.Repository.Interface;
using ServiceWeb.CartAPI.ViewModels;

namespace ServiceWeb.CartAPI.Controllers
{
    [ApiController]
    public class CartController : Controller
    {
        private ICartRepository _cartRepository;
        private IProductRepository _productRepository;
        private IRabbitMQMessageSender _rabbitMQMessageSender;

        public CartController(ICartRepository repository, IProductRepository productRepository, IRabbitMQMessageSender rabbitMQMessageSender)
        {
            _cartRepository = repository;
            _productRepository = productRepository;
            _rabbitMQMessageSender = rabbitMQMessageSender;
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
                    Data = dto.CartItems.FirstOrDefault().ProductCode
                });;
            };
            var cart = await _cartRepository.SaveOrUpdateCart(dto);
            
            if(cart != null) 
            {
                return Ok(new ResultViewModel
                {
                    Message = "Produto Adicionado ao carrinho.",
                    Success = true,
                    Data = cart
                }); 

            };
            return NotFound(new ResultViewModel
            {
                Message = "Erro ao adicionar produto ao carrinho.",
                Success = false,
                Data = dto.CartItems.FirstOrDefault().ProductCode
            }); 
        }

        [HttpPut]
        [Route("api/v1/cart/update-cart")]
        public async Task<ActionResult<CartDTO>> UpdateCart(CartDTO dto)
        {

            var product = await _productRepository.IsProductCodeValid(dto.CartItems.FirstOrDefault().ProductCode);

            if (!product)
            {
                return NotFound(new ResultViewModel
                {
                    Message = "Produto não encontrado",
                    Success = false,
                    Data = dto.CartItems.FirstOrDefault().ProductCode
                }); ;
            };
            var cart = await _cartRepository.SaveOrUpdateCart(dto);

            if (cart != null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Produto Adicionado ao carrinho.",
                    Success = true,
                    Data = cart
                });

            };
            return NotFound(new ResultViewModel
            {
                Message = "Erro ao editar carrinho.",
                Success = false,
                Data = dto.CartItems.FirstOrDefault().ProductCode
            });
        }

        [HttpGet]
        [Route("api/v1/cart/find-cart")]
        public async Task<ActionResult<CartDTO>> FindCartByUserId(string userId)
        {
            var cart = await _cartRepository.FindCartByUserId(userId);

            if (cart == null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Carrinho vazio.",
                    Success = true,
                    Data = cart
                }); ;
            };

            return Ok(new ResultViewModel
            {
                Message = "Carrinho encontrado.",
                Success = true,
                Data = cart
            });

           
        }
        [HttpDelete]
        [Route("api/v1/cart/remove-product-cart")]
        public async Task<ActionResult<CartDTO>> RemoveProductCart(int id)
        {
            var status = await _cartRepository.RemoveCart(id);
            if (status)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Produto removido.",
                    Success = true,
                    Data = true
                }); ;
            };

            return Ok(new ResultViewModel
            {
                Message = "Erro remover produto.",
                Success = false,
                Data = false
            });
        }

        [HttpDelete]
        [Route("api/v1/cart/clear-all-cart")]
        public async Task<ActionResult<CartDTO>> ClearAllCart(string userId)
        {
            var status = await _cartRepository.ClearCart(userId);
            if (status)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Carrinho excluído.",
                    Success = true,
                    Data = true
                }); ;
            };

            return Ok(new ResultViewModel
            {
                Message = "Erro so excluir carrinho.",
                Success = false,
                Data = false
            });
        }

        [HttpPost]
        [Route("api/v1/cart/checkout")]
        public async Task<ActionResult<CheckoutHeaderDTO>> Checkout(CheckoutHeaderDTO dto)
        {
            var cart = await _cartRepository.FindCartByUserId(dto.UserId);

            if (cart == null) 
            {
                return NotFound(new ResultViewModel
                {
                    Message = "Nenhum carrinho encontrado.",
                    Success = false,
                    Data = false
                }); 
            }

            dto.CartItems = cart.CartItems;
            dto.DateOrder = DateTime.Now;

            //RabbitMQ
            _rabbitMQMessageSender.SendMessage(dto, "checkoutqueue");

            return Ok(new ResultViewModel
            {
                Message = "Pedido finalizado.",
                Success = true,
                Data = dto
            });
        }

    }
}
