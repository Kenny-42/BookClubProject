using BookClub.Models;

namespace BookClub.Resources
{
    public class BookContext
    {
        // Stores the currently selected book
        public Book? CurrentBook { get; set; }
    }
}
