using BookClub.Data;
using BookClub.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace BookClub.Repositories;

/// <summary>
/// Provides methods for managing books in the data store, including adding, retrieving, updating, and deleting books.
/// </summary>
/// <remarks>This repository serves as an abstraction layer for interacting with the underlying data store. It
/// provides methods to perform CRUD (Create, Read, Update, Delete) operations on books.</remarks>
public class BookRepository
{
    /// <summary>
    /// Represents the application's database context used for data access operations.
    /// </summary>
    /// <remarks>This field is read-only and is intended to provide access to the database context within the
    /// class. It should be initialized through dependency injection or other appropriate mechanisms.</remarks>
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookRepository"/> class with the specified database context.
    /// </summary>
    /// <remarks>The provided <paramref name="context"/> must not be <c>null</c>. This repository depends on
    /// the context to perform data access operations for books.</remarks>
    /// <param name="context">The <see cref="AppDbContext"/> used to interact with the database.</param>
    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    /*
     *  CREATE Operations 
     */

    /// <summary>
    /// Adds a new book to the collection and saves the changes to the database.
    /// </summary>
    /// <param name="book">The book to add. The <see cref="Book.Id"/> property must be 0, as it will be auto-generated.</param>
    /// <returns><see langword="true"/> if the book was successfully added and changes were saved; otherwise, <see
    /// langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="book"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown if the <see cref="Book.Id"/> property of <paramref name="book"/> is not 0.</exception>
    public bool Add(Book book)
    {
        if (book == null)
            throw new ArgumentNullException(nameof(book), "Book cannot be null");
        if (book.Id != 0)
            throw new ArgumentException("Book ID must be 0 for new books. It will be auto-generated.", nameof(book.Id));

        _context.Books.Add(book);

        return _context.SaveChanges() > 0;
    }

    /*
     *  READ Operations 
     */

    /// <summary>
    /// Retrieves the first <see cref="Book"/> entity that matches the specified predicate.
    /// </summary>
    /// <param name="predicate">An expression that defines the conditions of the <see cref="Book"/> to retrieve.</param>
    /// <returns>The first <see cref="Book"/> that matches the specified predicate, or <see langword="null"/> if no match is
    /// found.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="predicate"/> is <see langword="null"/>.</exception>
    public Book? GetByKey(Expression<Func<Book, bool>> predicate)
    {
        if(predicate == null)
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null");

        return _context.Books.FirstOrDefault(predicate);
    }

    /// <summary>
    /// Retrieves all books from the data source.
    /// </summary>
    /// <remarks>This method retrieves all books currently stored in the data source. The returned collection
    /// reflects the state of the data source at the time of the call.</remarks>
    /// <returns>An <see cref="IEnumerable{T}"/> containing all books. The collection will be empty if no books are found.</returns>
    public IEnumerable<Book> GetAll()
    {
        return _context.Books.ToList();
    }

    /*
     *  UPDATE Operations 
     */

    /// <summary>
    /// Updates the details of an existing book in the database.
    /// </summary>
    /// <remarks>The method validates the provided <paramref name="dto"/> before applying updates. If
    /// validation fails,  an error message is displayed, and the operation is aborted. The method does not create a new
    /// book if  the specified <paramref name="bookId"/> does not exist.</remarks>
    /// <param name="bookId">The unique identifier of the book to update.</param>
    /// <param name="dto">An object containing the updated book details. Only non-null properties will be applied.</param>
    /// <returns><see langword="true"/> if the update operation succeeds; otherwise, <see langword="false"/>.</returns>
    public bool Update(int bookId, BookUpdateDTO dto)
    {
        // Use Data Annotations to validate the DTO
        var validationContext = new ValidationContext(dto);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

        // TODO: Should return validation results instead of showing a message box
        if (!isValid)
        {
            var errors = string.Join("; ", validationResults.Select(r => r.ErrorMessage));
            MessageBox.Show($"BookUpdateDTO validation failed:\n{errors}");
        }
      
        // Find the existing book by its ID
        var book = _context.books.Find(bookId);
      
        if (book == null) return false;

        // Update only the properties that are not null in the DTO
        book.Title = dto.Title ?? book.Title;
        book.Author = dto.Author ?? book.Author;
        book.Description = dto.Description ?? book.Description;
        book.ISBN = dto.ISBN ?? book.ISBN;

        return _context.SaveChanges() > 0;
    }

    /*
     *  DELETE Operations 
     */

    /// <summary>
    /// Deletes the book with the specified identifier from the database.
    /// </summary>
    /// <remarks>If the book with the specified identifier does not exist, the method returns <see
    /// langword="false"/>.</remarks>
    /// <param name="bookId">The unique identifier of the book to delete.</param>
    /// <returns><see langword="true"/> if the book was successfully deleted; otherwise, <see langword="false"/>.</returns>
    public bool Delete(int bookId)
    {
        var book = _context.Books.Find(bookId);
        if (book != null)
        {
            _context.Books.Remove(book);
            return _context.SaveChanges() > 0;
        }
        return false;
    }
}
