using ECommerceApp.Domain.Entities;
using System;
namespace ECommerceApp.Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
