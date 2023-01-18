namespace Application.Security;

public interface IPasswordManager
{
    string Hash(string password);
    bool CompareSecuredPassword(string password, string securedPassword);
}