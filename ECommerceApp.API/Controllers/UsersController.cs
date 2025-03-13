namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UsersController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterUserDto dto)
        {
            var restDto = await _authService.RegisterAsync(dto);
            return StatusCode(restDto.StatusCode, restDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUserDto dto)
        {
            var restDto = await _authService.LoginAsync(dto);
            return StatusCode(restDto.StatusCode, restDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var restDto = await _userService.GetByIdAsync(id);
            return StatusCode(restDto.StatusCode, restDto);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null || userId != id.ToString()){
                Console.WriteLine("userId " +  userId);
                Console.WriteLine("id " + id.ToString());
                var badRequestDto = new RestDto<bool>(400);
                return StatusCode(badRequestDto.StatusCode, badRequestDto);
            }

            var restDto = await _userService.DeleteUserAsync(id);
            return StatusCode(restDto.StatusCode, restDto);
        }
    }
}
