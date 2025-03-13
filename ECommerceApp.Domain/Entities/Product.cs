namespace ECommerceApp.Domain.Entities
{
    [Table("products")]
    public class Product : BaseEntity
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be at least 0.")]
        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ProductTranslation> Translations { get; set; } = new List<ProductTranslation>();
    }
}