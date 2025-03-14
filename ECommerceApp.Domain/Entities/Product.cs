namespace ECommerceApp.Domain.Entities
{
    [Table("products")]
    public class Product : BaseEntity
    {
        [Required]
        [Column("price", TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be at least 0.")]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ProductTranslation> Translations { get; set; } = new List<ProductTranslation>();
    }
}