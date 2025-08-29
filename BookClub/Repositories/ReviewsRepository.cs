using BookClub.Data;
using BookClub.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace BookClub.Repositories;

public class ReviewsRepository
{
    private readonly AppDbContext _context;

    public ReviewsRepository(AppDbContext context)
    {
        _context = context;
    }

    /*
     *  CREATE Operations 
     */

    public bool Add(Review review)
    {
        if (review == null)
            throw new ArgumentNullException(nameof(review), "Account cannot be null");

        if (review.Id != 0)
            throw new ArgumentException("Account ID must be 0 for new accounts. It will be auto-generated.", nameof(review.Id));

        _context.Reviews.Add(review);
        return _context.SaveChanges() > 0;
    }

    /*
     *  READ Operations 
     */

    public Review? GetByKey(Expression<Func<Review, bool>> predicate)
    {
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null");

        return _context.Reviews.FirstOrDefault(predicate);
    }

    public IEnumerable<Review> GetAll()
    {
        return _context.Reviews.ToList();
    }

    /*
     *  UPDATE Operations 
     */

    public bool Update(int id, ReviewUpdateDTO dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

        if (!isValid)
        {
            // Validation failed; optionally log errors or handle as needed
            return false;
        }

        var review = _context.Reviews.Find(id);
        if (review == null) return false;

        review.Rating = dto.Rating ?? review.Rating;
        review.Comment = dto.Comment ?? review.Comment;

        return _context.SaveChanges() > 0;
    }

    /*
     *  DELETE Operations 
     */

    public bool Delete(int id)
    {
        var review = _context.Reviews.Find(id);
        if (review != null)
        {
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}
