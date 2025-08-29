using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClub.Models;

/// <summary>
/// This is the Account entity model.
/// </summary>
public class Account
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = 0; // EF Core will auto-generate the ID - Initialize to 0 to avoid uninitialized warning
    
    /// <summary>
    /// Gets or sets the first name of the individual.
    /// </summary>
    [Required]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the individual.
    /// </summary>
    [Required]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the email address associated with the entity.
    /// </summary>
    [Required]
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the username associated with the user.
    /// </summary>
    [Required]
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the password associated with the user.
    /// </summary>
    [Required]
    public string Password { get; set; }

    public Account(int id, string firstName, string lastName, string email, string username, string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Username = username;
        Password = password;
    }
    public Account() { }
}

/// <summary>
/// This is a Data Transfer Object (DTO) for updating Account entities.
/// </summary>
/// <remarks>All properties are optional to allow partial updates.</remarks>
public class AccountUpdateDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

    public AccountUpdateDTO(string firstName, string lastName, string email, string username, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Username = username;
        Password = password;
    }

    public AccountUpdateDTO() { }
}