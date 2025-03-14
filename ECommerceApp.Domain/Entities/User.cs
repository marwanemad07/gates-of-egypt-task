namespace ECommerceApp.Domain.Entities
{
    [Table("users")]
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        [Column("full_name")]
        public string FullName { get; set; }

        [Required]
        [Column("email")]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Column("password_hash")]
        public string PasswordHash { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("role")]
        public UserRole Role { get; set; }

        public List<Cart> Carts { get; set; }
    }
}
