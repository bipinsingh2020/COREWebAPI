using COREWebAPI.Models;
using COREWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace COREWebAPI.Controllers
{
    public class ProductController : ControllerBase
    {

        private readonly IProductService _service;
        public ProductController(IProductService productService)
        {
            _service = productService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            return Ok(_service.GetProducts());
        }

        [HttpPost("api/[controller]/add")]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "Validation failed",
                    Errors = ModelState.Values.ToList()
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList()
                };
                return BadRequest(errorResponse);
            }
            else
            {
                _service.Add(product);
                return Ok();
                
            }
        }
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult Put([FromBody] Product product, int id)
        {
            _service.Update(product,id);
            return Ok();
        }
       
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
