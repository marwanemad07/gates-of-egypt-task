namespace ECommerceApp.Domain.Entities
{
    [Table("users")]
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string PasswordHash { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
     
        public List<Cart> Carts { get; set; }
    }
}
