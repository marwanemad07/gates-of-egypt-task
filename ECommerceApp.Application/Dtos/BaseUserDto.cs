namespace ECommerceApp.Application.Dtos
{
    public class BaseUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
