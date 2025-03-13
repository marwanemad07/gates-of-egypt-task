namespace ECommerceApp.Application.Mappings.Resolvers
{
    public class JwtTokenResolver : IValueResolver<User, UserDto, string>
    {
        private readonly IJwtTokenGenerator _jwtGenerator;

        public JwtTokenResolver(IJwtTokenGenerator jwtGenerator) 
        {
            _jwtGenerator = jwtGenerator;
        }

        public string Resolve(User source, UserDto destination, string destMember, ResolutionContext context)
        {
            var token = _jwtGenerator.GenerateToken(source.Id, source.Email);
            return token;
        }
    }
}
