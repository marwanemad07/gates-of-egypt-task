namespace ECommerceApp.Domain.Entities
{
    [Table("product_translations")]
    public class ProductTranslation : BaseEntity
    {
        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }


        [Required]
        [MaxLength(2)]
        public string LanguageCode { get; set; }  // assume ISO 639-1 only will be used

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

    }
}