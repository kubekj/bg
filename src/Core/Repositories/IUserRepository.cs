using Core.Entities;
using Core.ValueObjects.User;

namespace Core.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(Email email);
    Task AddAsync(User user);
    Task RemoveUser(Guid id);
    Task EditUserDetails(User user);
}