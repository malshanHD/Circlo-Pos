namespace CircloPos.Catalog.Application.Products
{
    public sealed record ProductResponse(
        Guid Id,
        string Name,
        decimal Price,
        DateTime CreatedAt);
}
