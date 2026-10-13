using CircloPos.Catalog.Application.Products;
using CircloPos.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CircloPos.Catalog.Insfrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _dbContext;

        public ProductRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Products.AsNoTracking().SingleOrDefaultAsync(product => product.Id == id, cancellationToken);
        }
    }
}
