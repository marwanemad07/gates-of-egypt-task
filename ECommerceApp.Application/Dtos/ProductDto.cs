namespace ECommerceApp.Application.Dtos
{
    public class ProductDto : NewProductDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
