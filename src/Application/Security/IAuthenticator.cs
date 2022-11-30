using Application.DTO;
using Core.Enums;

namespace Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId);
}