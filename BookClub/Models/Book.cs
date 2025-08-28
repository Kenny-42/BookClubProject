using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClub.Models;

/// <summary>
/// This is the Book entity model.
/// </summary>
public class Book
{
    /// <summary>
    /// This is the unique identifier for the book.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// This is the title of the book.
    /// </summary>
    [Required]
    public string Title { get; set; }

    /// <summary>
    /// This is the author of the book.
    /// </summary>
    [Required]
    public string Author { get; set; }

    /// <summary>
    /// This is a brief description of the book.
    /// </summary>
    [StringLength(1024, ErrorMessage = "Description cannot be longer than 1024 characters.")]
    public string Description { get; set; }


    /// <summary>
    /// This is a simplified ISBN validation.
    /// </summary>
    [Required]
    [StringLength(13, ErrorMessage = "ISBN must be 13 characters long.")]
    public string ISBN { get; set; }

    /// <summary>
    /// This is the constructor for the Book class.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="title"></param>
    /// <param name="author"></param>
    /// <param name="description"></param>
    /// <param name="iSBN"></param>
    public Book(int id, string title, string author, string description, string iSBN)
    {
        Id = id;
        Title = title;
        Author = author;
        Description = description;
        ISBN = iSBN;
    }

    /// <summary>
    /// This is a parameterless constructor for EF Core.
    /// </summary>
    public Book() { }
}

/// <summary>
/// This is a Data Transfer Object (DTO) for updating Book entities.
/// Uses nullable properties to allow partial updates.
/// </summary>
public class BookUpdateDTO
{
    public string? Title { get; set; }
    public string? Author { get; set;  }

    [StringLength(1024, ErrorMessage = "Description cannot be longer than 1024 characters.")]
    public string? Description { get; set; }

    [StringLength(13, ErrorMessage = "ISBN must be 13 characters long.")]
    public string? ISBN { get; set; }
}
