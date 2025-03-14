namespace ECommerceApp.Domain.Entities
{
    [Table("product_translations")]
    public class ProductTranslation : BaseEntity
    {
        [Required]
        [Column("product_id")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }


        [Required]
        [MaxLength(2)]
        [Column("language_code")]
        public string LanguageCode { get; set; }  // assume ISO 639-1 only will be used

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

    }
}