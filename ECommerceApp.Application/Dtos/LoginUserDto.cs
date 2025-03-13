namespace ECommerceApp.Application.Dtos
{
    public class LoginUserDto : BaseUserDto
    {
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
