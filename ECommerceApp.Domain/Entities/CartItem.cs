namespace ECommerceApp.Domain.Entities
{
    [Table("cart_items")]
    public class CartItem : BaseEntity
    {
        [Required]
        [Column("cart_id")]
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }


        [Required]
        [Column("product_id")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
