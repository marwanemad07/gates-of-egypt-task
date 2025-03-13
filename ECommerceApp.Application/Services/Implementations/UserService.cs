namespace ECommerceApp.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<RestDto<UserDto>> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null || user.IsDeleted)
            {
                return new RestDto<UserDto>(404);
            }

            var userDto = _mapper.Map<UserDto>(user);
            return new RestDto<UserDto>(200, userDto);
        }

        public async Task<RestDto<bool>> DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null || user.IsDeleted)
            {
                return new RestDto<bool>(404, false);
            }

            user.IsDeleted = true;
            await _userRepository.UpdateAsync(user);
            return new RestDto<bool>(200, true);
        }
    }
}
