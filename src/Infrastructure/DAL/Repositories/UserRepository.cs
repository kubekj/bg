using Core.Entities;
using Core.Repositories;
using Core.ValueObjects.User;
using Infrastructure.DAL.UoW;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly DbSet<User> _users;
    private readonly IUnitOfWork _unitOfWork;
    
    public UserRepository(BodyGuardDbContext dbContext, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _users = dbContext.Users;
    }

    public Task<User> GetByIdAsync(Guid id)
        => _users.SingleOrDefaultAsync(x => x.Id == id);

    public Task<User> GetByEmailAsync(Email email)
        => _users.SingleOrDefaultAsync(x => x.Email == email);
    
    public async Task AddAsync(User user)
    {
        await _users.AddAsync(user);
    }

    public async Task RemoveUser(Guid id)
    {
        var user = await GetByIdAsync(id);

        if (user is null)
            throw new UserNotFoundException(id);

        _users.Remove(user);
    }

    public async Task EditUserDetails(User user)
    {
        var doesUserExists = await GetByIdAsync(user.Id);

        if (doesUserExists is null)
            throw new UserNotFoundException(user.Id);

        _users.Update(user);
    }
}