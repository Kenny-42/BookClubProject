using BookClub.Models;

namespace BookClub.Resources
{
    internal class BookContext
    {
        // Stores the currently selected book
        public Book? CurrentBook { get; set; }
    }
}
