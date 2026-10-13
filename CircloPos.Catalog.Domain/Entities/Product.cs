namespace CircloPos.Catalog.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }

        private Product() { }

        public Product(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name cannot be empty.", nameof(name));
            }

            Name = name.Trim();

            if(name.Length > 150)
                throw new ArgumentException("Product name cannot exceed 150 characters.", nameof(name));

            if(price <=0 || price > 9999999999.99m)
                throw new ArgumentException("Product price must be greater than 0 and less than or equal to 9,999,999,999.99.", nameof(price));

            if(decimal.Round(price, 2) != price)
                throw new ArgumentException("Product price cannot have more than two decimal places.", nameof(price));

            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
