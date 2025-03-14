namespace ECommerceApp.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        // TODO: this should take in a User object
        public string GenerateToken(Guid userId, string email, string role);
    }
}
