using Application.DTO;
using Core.Entities;

namespace Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(User user, string role);
}