using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClub.Models;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Title { get; set; }
    public string Author { get; set; }

    public Book(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }

    public Book() { }
}
