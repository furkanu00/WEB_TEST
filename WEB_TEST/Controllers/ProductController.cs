using Microsoft.AspNetCore.Mvc;
using WEB_TEST.Services;
using WEB_TEST.Models;

namespace WEB_TEST.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private readonly PService _service;

        public ProductController(PService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _service.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updated)
        {
            var result = _service.Update(id, updated);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            return result ? NoContent() : NotFound();
        }
    }
}
