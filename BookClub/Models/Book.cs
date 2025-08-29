using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClub.Models;

/// <summary>
/// This is the Book entity model.
/// </summary>
public class Book
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the entity. This value is required.
    /// </summary>
    [Required]
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the name of the author.
    /// </summary>
    [Required]
    public string Author { get; set; }

    /// <summary>
    /// Gets or sets the description text.
    /// </summary>
    [StringLength(1024, ErrorMessage = "Description cannot be longer than 1024 characters.")]
    public string Description { get; set; }


    /// <summary>
    /// Gets or sets the International Standard Book Number (ISBN) of the book.
    /// </summary>
    [Required]
    [StringLength(13, ErrorMessage = "ISBN must be 13 characters long.")]
    public string ISBN { get; set; }

    public Book(int id, string title, string author, string description, string iSBN)
    {
        Id = id;
        Title = title;
        Author = author;
        Description = description;
        ISBN = iSBN;
    }

    public Book() { }
}

/// <summary>
/// This is a Data Transfer Object (DTO) for updating Book entities.
/// </summary>
/// <remarks>All properties are optional to allow partial updates.</remarks>
public class BookUpdateDTO
{
    public string? Title { get; set; }
    public string? Author { get; set;  }

    [StringLength(1024, ErrorMessage = "Description cannot be longer than 1024 characters.")]
    public string? Description { get; set; }

    [StringLength(13, ErrorMessage = "ISBN must be 13 characters long.")]
    public string? ISBN { get; set; }
}
