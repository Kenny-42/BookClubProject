using BookClub.Models;

public class UserContext
{
    // Stores the currently logged-in account
    public Account? CurrentAccount { get; set; }
}