namespace ECommerceApp.Application.Dtos
{
    public class NewProductTranslationDto
    {
        [Required]
        [MinLength(2), MaxLength(2)]
        public string LanguageCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
