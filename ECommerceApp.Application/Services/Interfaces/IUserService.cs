namespace ECommerceApp.Application.Services.Interfaces
{
    public interface IUserService
    {
        public Task<RestDto<UserDto>> GetByIdAsync(Guid id);
        public Task<RestDto<bool>> DeleteUserAsync(Guid id);
    }
}
