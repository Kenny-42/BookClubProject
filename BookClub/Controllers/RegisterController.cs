using BookClub.Common;
using BookClub.Models;
using BookClub.Services;
using BookClub.Views;
using System.Text.RegularExpressions;

namespace BookClub.Controllers;

public class RegisterController : IController
{
    private readonly AccountsService _accountsService;
    public event Action<Type, object?>? NavigationRequested;
    public RegisterController(AccountsService accountsService)
    {
        _accountsService = accountsService;
    }

    public async Task<Result> TryRegister(string email, string username, DateTime birthDate, string password, string confirmPassword)
    {
        if (string.IsNullOrWhiteSpace(email) ||
           string.IsNullOrWhiteSpace(username) ||
           string.IsNullOrWhiteSpace(password) ||
           string.IsNullOrWhiteSpace(confirmPassword))
        {
            return Result.Fail("All fields are required.");
        }

        List<string> errors = new();

        var errorList = new List<string>();

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            errorList.Add("Invalid email format.");

        if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]{3,20}$"))
            errorList.Add("Username must be 3-20 characters long and can only contain letters, numbers, and underscores.");

        int age = DateTime.Today.Year - birthDate.Year;
        if (birthDate > DateTime.Today.AddYears(-age)) age--;

        if (age < 13 || age > 100)
        {
            errorList.Add("You must be between 13 and 100 years old to register.");
        }

        if (password.Length < 6)
            errorList.Add("Password must be at least 6 characters long.");

        if (password != confirmPassword)
            errorList.Add("Confirm password does not match.");

        if (await _accountsService.GetByEmail(email) != null)
            errorList.Add($"{email} already exists.");

        if (await _accountsService.GetByUsername(username) != null)
            errorList.Add($"{username} already exists.");

        if (errorList.Any())
            return Result.Fail(string.Join("\n", errorList));

        Account newAccount = new()
        {
            Email = email,
            Username = username,
            Password = password,
        };

        _accountsService.Create(newAccount);

        return Result.Ok();
    }

    public void Cancel()
    {
        NavigationRequested?.Invoke(typeof(LoginView), null);
    }
}
