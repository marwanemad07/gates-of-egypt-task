namespace ECommerceApp.Application.Dtos
{
    public class CartDto
    {
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<CartItemDto> CartItems { get; set; } = new();
    }
}
