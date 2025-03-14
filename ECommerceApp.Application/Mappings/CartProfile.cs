namespace ECommerceApp.Application.Mappings
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartDto>();

            CreateMap<CartItem, CartItemDto>()
              .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src =>
                  src.Product.Translations.Any(t => t.LanguageCode == "en")
                  ? src.Product.Translations.First(t => t.LanguageCode == "en").Name
                  : "Unknown"
              ));
        }
    }
}
