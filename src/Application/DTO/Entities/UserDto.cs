namespace Application.DTO.Entities;

public record UserDto(
    string FirstName, 
    string LastName, 
    string Email, 
    string Description,
    string PreferredLanguage,
    double Weight,
    double Height,
    int CaloriesIntake);