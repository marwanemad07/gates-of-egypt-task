namespace ECommerceApp.Application.Dtos
{
    public class UserDto : BaseUserDto
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
