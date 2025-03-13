namespace ECommerceApp.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Product, NewProductDto>().ReverseMap();
        }
    }
}
