using Microsoft.AspNetCore.Mvc;
using ServiceWeb.ProductAPI.DTO;
using ServiceWeb.ProductAPI.Model.Entities;
using ServiceWeb.ProductAPI.Repository.Interface;

namespace ServiceWeb.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> FindAll()
        {
            var products = await _repository.FindAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);  


        }

    }
}
