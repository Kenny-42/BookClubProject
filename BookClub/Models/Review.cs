using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClub.Models;

public class Review
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = 0; // Auto-generated ID

    [Required]
    public int BookId { get; set; }

    [Required]
    public int AccountId { get; set; }

    [Required]
    [Range(1, 5)]
    public int Rating { get; set; } // Rating out of 5

    [Required]
    [StringLength(2048, ErrorMessage = "Comment cannot be longer than 2048 characters.")]
    public string Comment { get; set; } = string.Empty;

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
