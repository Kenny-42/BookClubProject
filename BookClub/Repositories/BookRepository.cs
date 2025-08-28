using BookClub.Data;
using BookClub.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace BookClub.Repositories;

public class BookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public bool Add(Book book)
    {
        if (book == null)
            throw new ArgumentNullException(nameof(book), "Book cannot be null");
        if (book.Id != 0)
            throw new ArgumentException("Book ID must be 0 for new books. It will be auto-generated.", nameof(book.Id));

        _context.books.Add(book);

        return _context.SaveChanges() > 0;
    }

    public Book? GetByKey(Expression<Func<Book, bool>> predicate)
    {
        if(predicate == null)
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null");

        return _context.books.FirstOrDefault(predicate);
    }

    public IEnumerable<Book> GetAll()
    {
        return _context.books.ToList();
    }

    public bool Update(int bookId, BookUpdateDTO dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

        if (!isValid)
        {
            var errors = string.Join("; ", validationResults.Select(r => r.ErrorMessage));
            MessageBox.Show($"BookUpdateDTO validation failed:\n{errors}");
        }

        var book = _context.books.Find(bookId);
        if (book == null) return false;

        book.Title = dto.Title ?? book.Title;
        book.Author = dto.Author ?? book.Author;
        book.Description = dto.Description ?? book.Description;
        book.ISBN = dto.ISBN ?? book.ISBN;

        return _context.SaveChanges() > 0;
    }

    public bool Delete(int bookId)
    {
        var book = _context.books.Find(bookId);
        if (book != null)
        {
            _context.books.Remove(book);
            return _context.SaveChanges() > 0;
        }
        return false;
    }
}
