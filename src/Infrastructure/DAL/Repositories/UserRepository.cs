using Core.Entities;
using Core.Exceptions;
using Core.Repositories;
using Core.ValueObjects.Properties.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly DbSet<User> _users;

    public UserRepository(BodyGuardDbContext dbContext) => _users = dbContext.Users;

    public Task<User> GetByIdAsync(Guid id)
        => _users.SingleOrDefaultAsync(x => x.Id == id);

    public Task<User> GetByEmailAsync(Email email)
        => _users.SingleOrDefaultAsync(x => x.Email == email);
    
    public async Task AddAsync(User user)
        => await _users.AddAsync(user);

    public async Task RemoveUser(Guid id)
    {
        var user = await GetByIdAsync(id);

        if (user is null)
            throw new UserNotFoundException(id);

        _users.Remove(user);
    }

    public Task EditUserDetails(User user)
    {
        throw new NotImplementedException();
    }
}

internal class UserNotFoundException : CoreException
{
    public UserNotFoundException(Guid id) : base($"") => Value = id;

    public Guid Value { get; set; }
}