using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GeekShopping.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/v1/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var product = await _repository.FindById(id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> FindById()
        {
            var product = await _repository.FindAll();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductVO vo)
        {
            if(vo == null)
            {
                return BadRequest();
            }

            return Ok(await _repository.Create(vo));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductVO vo)
        {
            if (vo == null)
            {   
                return BadRequest();
            }

            return Ok(await _repository.Update(vo));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _repository.Delete(id);

            if (!response)
            {
                return BadRequest();
            }

            return Ok(response);
        }
    }
}
