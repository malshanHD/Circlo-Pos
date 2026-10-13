using CircloPos.Catalog.Application.Products;
using Microsoft.AspNetCore.Mvc;

namespace CircloPos.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductAsync([FromBody] CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            var productResponse = await _productService.CreateProductAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = productResponse.Id }, productResponse);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await _productService.GetProductByIdAsync(id, cancellationToken);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
