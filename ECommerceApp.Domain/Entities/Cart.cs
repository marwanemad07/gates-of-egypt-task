namespace ECommerceApp.Domain.Entities
{
    [Table("carts")]
    public class Cart : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Using this to soft delete the cart
        public bool isActive { get; set; } = true; 

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}
