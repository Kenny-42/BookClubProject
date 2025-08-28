using BookClub.Data;
using BookClub.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace BookClub.Repositories;

public class AccountsRepository
{
    private readonly AppDbContext _context;

    public AccountsRepository(AppDbContext context)
    {
        _context = context;
    }

    /*
     *  CREATE Operations 
     */

    public bool Add(Account account)
    {
        if (account == null)
            throw new ArgumentNullException(nameof(account), "Account cannot be null");

        if (account.Id != 0)
            throw new ArgumentException("Account ID must be 0 for new accounts. It will be auto-generated.", nameof(account.Id));

        _context.accounts.Add(account);
        return _context.SaveChanges() > 0;
    }

    /*
     *  READ Operations 
     */

    public Account? GetByKey(Expression<Func<Account, bool>> predicate)
    {
        if ( predicate == null)
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null");

        return _context.accounts.FirstOrDefault(predicate);
    }

    public IEnumerable<Account> GetAll()
    {
        return _context.accounts.ToList();
    }

    /*
     *  UPDATE Operations 
     */

    public bool Update(int id, AccountUpdateDTO dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

        if (!isValid)
        {
            var errors = string.Join("; ", validationResults.Select(r => r.ErrorMessage));
            MessageBox.Show($"AccountUpdateDTO validation failed:\n{errors}");
        }

        var account = _context.accounts.Find(id);
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

    public bool Delete(int id)
    {
        var account = _context.accounts.Find(id);
        if (account != null)
        {
            _context.accounts.Remove(account);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}
