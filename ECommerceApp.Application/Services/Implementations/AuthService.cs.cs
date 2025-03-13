namespace ECommerceApp.Application.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository,
            IUserService userService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<RestDto<UserDto>> RegisterAsync(RegisterUserDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                return new RestDto<UserDto>(400, message: "User with this email already exists");
            }

            var user = new User
            {
                Email = dto.Email,
                FullName = dto.FullName,
                PasswordHash = HashPassword(dto.Password)
            };

            await _userRepository.AddAsync(user);

            var restDto = await _userService.GetByIdAsync(user.Id);
            if (restDto.StatusCode == 404)
            {
                return new RestDto<UserDto>(500, message: "User was created but could not be retrieved");
            }

            // User Created
            restDto = new RestDto<UserDto>(201, restDto.Data, "User was created successfuly.");
            return restDto;
        }

        public async Task<RestDto<AuthUserDto>> LoginAsync(LoginUserDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null || !VerifyPassword(dto.Password, user.PasswordHash) || user.IsDeleted)
            {
                return new RestDto<AuthUserDto>(401, message: "Invalid email or password");
            }

            var userDto = _mapper.Map<AuthUserDto>(user);
            return new RestDto<AuthUserDto>(200, userDto);
        }
        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        private static bool VerifyPassword(string password, string hashedPassword)
        {
            return HashPassword(password) == hashedPassword;
        }
    }
}
