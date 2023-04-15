using Microsoft.AspNetCore.Mvc;
using ServiceWeb.ProductAPI.Model.Entities;

namespace ServiceWeb.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<Product>> FindAll()
        {
            return View();
        }
    }
}
