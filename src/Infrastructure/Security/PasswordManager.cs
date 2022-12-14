using Application.Security;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Security;

internal sealed class PasswordManager : IPasswordManager
{
    private readonly IPasswordHasher<User> _passwordHasher;

    public PasswordManager(IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string Secure(string password)
    {
        return _passwordHasher.HashPassword(default, password);
    }

    public bool Validate(string password, string securedPassword)
    {
        return _passwordHasher.VerifyHashedPassword(default, securedPassword, password) ==
               PasswordVerificationResult.Success;
    }
}