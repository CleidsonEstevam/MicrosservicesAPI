﻿using Microsoft.AspNetCore.Mvc;
using ServiceWeb.ProductAPI.DTO;
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

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Create([FromBody] ProductDTO dto)
        {
            if (dto == null) return BadRequest();
            var product = await _repository.Create(dto);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDTO>> Update([FromBody] ProductDTO dto)
        {
            if (dto == null) return BadRequest();
            var product = await _repository.Update(dto);
            return Ok(product);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if(!status) return BadRequest();
            return Ok(status);
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
