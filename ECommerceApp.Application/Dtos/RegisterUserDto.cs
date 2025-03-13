namespace ECommerceApp.Application.Dtos
{
    public class RegisterUserDto : LoginUserDto
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
    }
}
