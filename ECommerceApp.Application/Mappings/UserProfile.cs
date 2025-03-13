 namespace ECommerceApp.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<User, AuthUserDto>()
                .ForMember(dest => dest.Token, opt => opt.MapFrom<JwtTokenResolver>());
        }
    }
}
