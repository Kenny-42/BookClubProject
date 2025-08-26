using AccountSystem.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClub.Models;

public class Account
{
    /// <summary>
    /// Represent the unique identifier for the account.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccountId { get; set; } = 0;

    /// <summary>
    /// The date and time when the account was created.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The first name of the account holder.
    /// </summary>
    [Required]
    [StringLength(64, MinimumLength = 1, ErrorMessage = "First name must be between 1 and 64 characters long.")]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// The last name of the account holder.
    /// </summary>
    [Required]
    [StringLength(64, MinimumLength = 1, ErrorMessage = "Last name must be between 1 and 64 characters long.")]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// The birthdate of the account holder.
    /// </summary>
    [Required]
    [AgeRange(13, 100, ErrorMessage = "You must be between 13 and 100 years old to create an account.")]
    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }

    /// <summary>
    /// The email address of the account holder.
    /// </summary>
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    [StringLength(256, MinimumLength = 5, ErrorMessage = "Email cannot be longer than 256 characters.")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The username of the account holder.
    /// </summary>
    [Required]
    [StringLength(64, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 64 characters long.")]
    public string Username { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [StringLength(128, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 128 characters long.")]
    public string Password { get; set; } = string.Empty;    // Currently stored in plain text, should be hashed in future

    public Account(int accountId, DateTime createdAt, string firstName, string lastName, DateTime birthdate, string email, string username, string password)
    {
        AccountId = accountId;
        CreatedAt = createdAt;
        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthdate;
        Email = email;
        Username = username;
        Password = password;
    }

    public Account() { }
}

/// <summary>
/// This is a Data Transfer Object (DTO) for handling user login information.
/// </summary>
public class AccountLogin
{
    public string UsernameEmail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;

    public AccountLogin(string usernameEmail, string password, string confirmPassword)
    {
        UsernameEmail = usernameEmail;
        Password = password;
    }
    public AccountLogin() { }
}

/// <summary>
/// This is a Data Transfer Object (DTO) for handling user registration information.
/// </summary>
public class AccountRegistration
{
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public DateTime Birthdate { get; set; }
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;

    public AccountRegistration(string email, string username, DateTime birthdate, string password, string confirmPassword)
    {
        Email = email;
        Username = username;
        Birthdate = birthdate;
        Password = password;
        ConfirmPassword = confirmPassword;
    }

    public AccountRegistration() { }
}