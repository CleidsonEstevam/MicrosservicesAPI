using Microsoft.AspNetCore.Mvc;
using ServiceWeb.ProductAPI.DTO;
using ServiceWeb.ProductAPI.Model.Entities;
using ServiceWeb.ProductAPI.Model.Entities.Execeptions;
using ServiceWeb.ProductAPI.Repository.Interface;
using ServiceWeb.ProductAPI.Util;
using ServiceWeb.ProductAPI.ViewModels;

namespace ServiceWeb.ProductAPI.Controllers
{
   
    [ApiController]
    public class ProductController : Controller
    {

        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("api/v1/product/create")]
        public async Task<ActionResult<ProductDTO>> Create([FromBody] ProductDTO dto)
        {
            try
            {
                if (dto == null) return BadRequest();
                var product = await _repository.Create(dto);

                return Ok(new ResultViewModel
                {
                    Message = "Produto criado com sucesso!",
                    Success = true,
                    Data = product
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.AplicationErrorMessage());
            }

        }

        [HttpPut]
        [Route("api/v1/product/update")]
        public async Task<ActionResult<ProductDTO>> Update([FromBody] ProductDTO dto)
        {
            try
            {
                if (dto == null) return BadRequest();

                var product = await _repository.Update(dto);

                if(product != null)
                return Ok(new ResultViewModel
                    {
                        Message = "Usuário não encontrado",
                        Success = true,
                        Data = dto
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário modificado com sucesso.",
                    Success = true,
                    Data = product
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.AplicationErrorMessage());
            }
        }
        [HttpDelete]
        [Route("api/v1/product/delete/{id}")]

        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var status = await _repository.Delete(id);
                if (!status)
                    return Ok(new ResultViewModel
                    {
                        Message = "Produto informado não encontrado.",
                        Success = true,
                        Data = null
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Produto removido com sucesso.",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.AplicationErrorMessage());
            }

        }
        [HttpGet]
        [Route("api/v1/product/find-all")]

        public async Task<ActionResult<IEnumerable<ProductDTO>>> FindAll()
        {
            try
            {
                var products = await _repository.FindAll();
                return Ok(new ResultViewModel
                {
                    Message = "Produtos encontrados com sucesso.",
                    Success = true,
                    Data = products
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.AplicationErrorMessage());
            }

        }

        [HttpGet]
        [Route("api/v1/product/find-by-id/{id}")]

        public async Task<ActionResult<ProductDTO>> FindById(long id)
        {
            try
            {
                var product = await _repository.FindById(id);
                if (product == null) 
                    return Ok(new ResultViewModel
                    {
                        Message = "ID informado não pertence a nenhum Produto.",
                        Success = true,
                        Data = product
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Produto encontrado com sucesso.",
                    Success = true,
                    Data = product
                });

            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.AplicationErrorMessage());
            }
          
        }

    }
}
