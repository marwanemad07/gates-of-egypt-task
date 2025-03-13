namespace ECommerceApp.Application.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<RestDto<UserDto>> RegisterAsync(RegisterUserDto dto);
        public Task<RestDto<AuthUserDto>> LoginAsync(LoginUserDto dto);
    }
}
