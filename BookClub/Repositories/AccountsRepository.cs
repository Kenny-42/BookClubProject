using BookClub.Data;
using BookClub.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace BookClub.Repositories;

/// <summary>
/// Provides methods for managing accounts in the application, including creating, retrieving, updating, and deleting
/// accounts.
/// </summary>
/// <remarks>This repository serves as an abstraction layer for interacting with the underlying data store of
/// accounts. It provides CRUD (Create, Read, Update, Delete) operations and ensures that input data is validated before
/// being persisted.</remarks>
public class AccountsRepository
{
    /// <summary>
    /// Represents the database context used for interacting with the application's data store.
    /// </summary>
    /// <remarks>This field is read-only and is intended to be used internally within the class to perform
    /// database operations.</remarks>
    private readonly AppDbContext _context;

    public AccountsRepository(AppDbContext context)
    {
        _context = context;
    }

    /*
     *  CREATE Operations 
     */

    /// <summary>
    /// Adds a new account to the system.
    /// </summary>
    /// <param name="account">The account to add. The <see cref="Account.Id"/> property must be 0, as it will be auto-generated.</param>
    /// <returns><see langword="true"/> if the account was successfully added; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="account"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="account"/> has a non-zero <see cref="Account.Id"/>.</exception>
    public bool Add(Account account)
    {
        if (account == null)
            throw new ArgumentNullException(nameof(account), "Account cannot be null");

        if (account.Id != 0)
            throw new ArgumentException("Account ID must be 0 for new accounts. It will be auto-generated.", nameof(account.Id));

        _context.Accounts.Add(account);
        return _context.SaveChanges() > 0;
    }

    /*
     *  READ Operations 
     */

    /// <summary>
    /// Retrieves the first <see cref="Account"/> entity that matches the specified predicate.
    /// </summary>
    /// <param name="predicate">An expression that defines the conditions of the <see cref="Account"/> to retrieve.</param>
    /// <returns>The first <see cref="Account"/> that matches the specified predicate, or <see langword="null"/> if no match is
    /// found.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="predicate"/> is <see langword="null"/>.</exception>
    public Account? GetByKey(Expression<Func<Account, bool>> predicate)
    {
        if ( predicate == null)
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null");

        return _context.Accounts.FirstOrDefault(predicate);
    }

    /// <summary>
    /// Retrieves all accounts from the data source.
    /// </summary>
    /// <remarks>This method retrieves all accounts currently stored in the data source.  The returned
    /// collection reflects the state of the data source at the time of the call.</remarks>
    /// <returns>An <see cref="IEnumerable{T}"/> containing all accounts. The collection will be empty if no accounts exist.</returns>
    public IEnumerable<Account> GetAll()
    {
        return _context.Accounts.ToList();
    }

    /*
     *  UPDATE Operations 
     */

    /// <summary>
    /// Updates the account information for the specified account ID using the provided data transfer object (DTO).
    /// </summary>
    /// <remarks>The method performs validation on the provided <paramref name="dto"/>. If validation fails,
    /// the method  returns <see langword="false"/> without making any changes. If the account with the specified
    /// <paramref name="id"/>  does not exist, the method also returns <see langword="false"/>.</remarks>
    /// <param name="id">The unique identifier of the account to update.</param>
    /// <param name="dto">An <see cref="AccountUpdateDTO"/> containing the updated account information.  Only non-null properties in the
    /// DTO will be applied to the account.</param>
    /// <returns><see langword="true"/> if the account was successfully updated and changes were saved to the database; 
    /// otherwise, <see langword="false"/>.</returns>
    public bool Update(int id, AccountUpdateDTO dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

        if (!isValid)
        {
            // Validation failed; optionally log errors or handle as needed
            return false;
        }

        var account = _context.Accounts.Find(id);
        if (account == null) return false;

        account.FirstName = dto.FirstName ?? account.FirstName;
        account.LastName = dto.LastName ?? account.LastName;
        account.Email = dto.Email ?? account.Email;
        account.Username = dto.Username ?? account.Username;
        account.Password = dto.Password ?? account.Password;

        return _context.SaveChanges() > 0;
    }

    /*
     *  DELETE Operations 
     */

    /// <summary>
    /// Deletes the account with the specified identifier.
    /// </summary>
    /// <remarks>If no account with the specified identifier exists, the method returns <see
    /// langword="false"/>  and no changes are made to the database.</remarks>
    /// <param name="id">The unique identifier of the account to delete.</param>
    /// <returns><see langword="true"/> if the account was successfully deleted; otherwise, <see langword="false"/>.</returns>
    public bool Delete(int id)
    {
        var account = _context.Accounts.Find(id);
        if (account != null)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}
