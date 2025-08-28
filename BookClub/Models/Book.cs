using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClub.Models;

/// <summary>
/// This is the Book entity model.
/// </summary>
public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Author { get; set; }

    [StringLength(1024, ErrorMessage = "Description cannot be longer than 1024 characters.")]
    public string Description { get; set; }

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
public class BookUpdateDTO
{
    public string? Title { get; set; }
    public string? Author { get; set;  }

    [StringLength(1024, ErrorMessage = "Description cannot be longer than 1024 characters.")]
    public string? Description { get; set; }

    [StringLength(13, ErrorMessage = "ISBN must be 13 characters long.")]
    public string? ISBN { get; set; }
}
