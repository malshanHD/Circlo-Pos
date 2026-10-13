using CircloPos.Catalog.Domain.Entities;

namespace CircloPos.Catalog.Application.Products
{
    public sealed class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> CreateProductAsync(CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            var product = new Product(request.Name, request.Price);
            await _productRepository.AddAsync(product, cancellationToken);
            return Map(product);
        }

        public async Task<ProductResponse?> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetByIdAsync(id, cancellationToken);
            return product is null ? null : Map(product);
        }

        private static ProductResponse Map(Product product)
        {
            return new ProductResponse(
                product.Id,
                product.Name,
                product.Price,
                product.CreatedAt);
        }
    }
}
