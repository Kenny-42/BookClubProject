using BookClub.Data;
using BookClub.Models;
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

    public Account? GetByKey(Func<Account, bool> predicate)
    {
        return _context.accounts.FirstOrDefault(predicate);
    }

    public IEnumerable<Account> GetAll()
    {
        return _context.accounts.ToList();
    }

    /*
     *  UPDATE Operations 
     */

    public void Update(Account account)
    {
        // Note: this updates all fields. For partial updates, consider using a different approach.
        _context.accounts.Update(account);
        _context.SaveChanges();
    }

    /*
     *  DELETE Operations 
     */

    public void Delete(int id)
    {
        var account = _context.accounts.Find(id);
        if (account != null)
        {
            _context.accounts.Remove(account);
            _context.SaveChanges();
        }
    }
}
