using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClub.Models;

/// <summary>
/// This is the Review entity model.
/// </summary>
public class Review
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = 0; // Auto-generated ID

    /// <summary>
    /// Gets or sets the unique identifier for the book.
    /// </summary>
    [Required]
    public int BookId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the account.
    /// </summary>
    [Required]
    public int AccountId { get; set; }

    /// <summary>
    /// Gets or sets the rating, which must be a value between 1 and 5.
    /// </summary>
    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }

    /// <summary>
    /// Gets or sets the comment associated with the entity.
    /// </summary>
    [Required]
    [StringLength(2048, ErrorMessage = "Comment cannot be longer than 2048 characters.")]
    public string Comment { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the timestamp indicating when the entity was created.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }

    public Review(int id, int bookId, int accountId, int rating, string comment, DateTime createdAt)
    {
        Id = id;
        BookId = bookId;
        AccountId = accountId;
        Rating = rating;
        Comment = comment;
        CreatedAt = createdAt;
    }

    public Review() { }
}

/// <summary>
/// This is a Data Transfer Object (DTO) for updating Review entities.
/// </summary>
/// <remarks>All properties are optional to allow partial updates.</remarks>
public class ReviewUpdateDTO
{
    [Required]
    [Range(1, 5)]
    public int? Rating { get; set; }

    [Required]
    [StringLength(2048, ErrorMessage = "Comment cannot be longer than 2048 characters.")]
    public string? Comment { get; set; } = string.Empty;

    public ReviewUpdateDTO(int rating, string comment)
    {
        Rating = rating;
        Comment = comment;
    }

    public ReviewUpdateDTO() { }
}