using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace BookClub.Models;

public class Discussion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int BookId { get; set; }

    [Required]
    public int AccountId { get; set; }

    [Required]
    [StringLength(2048, ErrorMessage = "Comment cannot be longer than 2048 characters.")]
    public string Comment { get; set; } = string.Empty;

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime PostedAt { get; set; }

    public Discussion(int id, int bookId, int accountId, string comment, DateTime postedAt)
    {
        Id = id;
        BookId = bookId;
        AccountId = accountId;
        Comment = comment;
        PostedAt = postedAt;
    }

    public Discussion() { }
}

public class DiscussionUpdateDTO
{
    [Required]
    [StringLength(2048, ErrorMessage = "Comment cannot be longer than 2048 characters.")]
    public string? Comment { get; set; } = string.Empty;
    public DiscussionUpdateDTO(string comment)
    {
        Comment = comment;
    }
    public DiscussionUpdateDTO() { }
}