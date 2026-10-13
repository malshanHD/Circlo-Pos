using System.ComponentModel.DataAnnotations;

namespace CircloPos.Catalog.Application.Products
{
    public sealed class CreateProductRequest : IValidatableObject
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(typeof(decimal), "0.01", "9999999999.99")]
        public decimal Price { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (decimal.Round(Price, 2) != Price)
            {
                yield return new ValidationResult("Price can have at most two decimal places.", new[] { nameof(Price) });
            }
        }
    }
}
