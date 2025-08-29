
using BookClub.Data;
using BookClub.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace BookClub.Repositories;

public class DiscussionsRepository
{
    private readonly AppDbContext _context;

    public DiscussionsRepository(AppDbContext context)
    {
        _context = context;
    }

    /*
     *  CREATE Operations 
     */

    public bool Add(Discussion discussion)
    {
        if (discussion == null)
            throw new ArgumentNullException(nameof(discussion), "Account cannot be null");

        if (discussion.Id != 0)
            throw new ArgumentException("Account ID must be 0 for new accounts. It will be auto-generated.", nameof(discussion.Id));

        _context.Discussions.Add(discussion);
        return _context.SaveChanges() > 0;
    }

    /*
     *  READ Operations 
     */

    public Discussion? GetByKey(Expression<Func<Discussion, bool>> predicate)
    {
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null");

        return _context.Discussions.FirstOrDefault(predicate);
    }

    public IEnumerable<Discussion> GetAll()
    {
        return _context.Discussions.ToList();
    }

    /*
     *  UPDATE Operations 
     */

    public bool Update(int id, DiscussionUpdateDTO dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

        if (!isValid)
        {
            // Validation failed; optionally log errors or handle as needed
            return false;
        }

        var discussion = _context.Discussions.Find(id);
        if (discussion == null) return false;

        discussion.Comment = dto.Comment ?? discussion.Comment;

        return _context.SaveChanges() > 0;
    }

    /*
     *  DELETE Operations 
     */

    public bool Delete(int id)
    {
        var discussion = _context.Discussions.Find(id);
        if (discussion != null)
        {
            _context.Discussions.Remove(discussion);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}
