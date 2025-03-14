namespace ECommerceApp.Domain.Entities
{
    [Table("carts")]
    public class Cart : BaseEntity
    {
        [Required]
        [Column("user_id")]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Using this to soft delete the cart
        [Column("is_active")]
        public bool IsActive { get; set; } = true; 

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}
