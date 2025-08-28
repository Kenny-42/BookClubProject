using BookClub.Data;
using BookClub.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms;

public partial class AddBook : Form
{
    private BookRepository _repo;
    public AddBook(BookRepository repo)
    {
        InitializeComponent();
        _repo = repo;
        this.FormClosed += (s, args) => Application.Exit();
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        // TODO: Implement proper logout functionality (e.g., clear session data)

        // Return to login screen
        Login loginForm = Program.AppServices.GetRequiredService<Login>();
        loginForm.Show();
        this.Hide();
    }

    private void btnBookList_Click(object sender, EventArgs e)
    {
        // Navigate back to BookList
        BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();
        bookListForm.Show();
        this.Hide();
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        // Attempt to add the book
        if (!TryAddBook(txtTitle.Text, txtAuthor.Text, txtDescription.Text, txtISBN.Text, out string error))
        {
            MessageBox.Show(error, "Add Book Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // On success, navigate back to BookList
        BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();
        bookListForm.Show();
        this.Hide();
    }

    /// <summary>
    /// Attempts to add a new book to the repository with the specified details.
    /// </summary>
    /// <remarks>This method validates the input parameters and ensures that all required fields are provided.
    /// If the validation fails, the method returns <see langword="false"/> and populates the <paramref name="error"/>
    /// parameter with a detailed error message.</remarks>
    /// <param name="title">The title of the book. Cannot be null, empty, or consist only of whitespace.</param>
    /// <param name="author">The author of the book. Cannot be null, empty, or consist only of whitespace.</param>
    /// <param name="description">The description of the book. Cannot be null, empty, or consist only of whitespace, and must not exceed 1024
    /// characters.</param>
    /// <param name="isbn">The International Standard Book Number (ISBN) of the book. Must be exactly 13 characters long after removing any
    /// hyphens.</param>
    /// <param name="error">When the method returns, contains an error message describing why the operation failed, if the operation was
    /// unsuccessful; otherwise, contains an empty string. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the book was successfully added to the repository; otherwise, <see langword="false"/>.</returns>
    private bool TryAddBook(string title, string author, string description, string isbn, out string error)
    {
        var errors = new List<string>();

        // Trim inputs to avoid leading/trailing spaces
        title = title.Trim();
        author = author.Trim();
        description = description.Trim();
        isbn = isbn.Trim();

        // Make sure all fields are filled
        if (string.IsNullOrWhiteSpace(title) ||
            string.IsNullOrWhiteSpace(author) ||
            string.IsNullOrWhiteSpace(description) ||
            string.IsNullOrWhiteSpace(isbn))
        {
            errors.Add("All fields must be filled.");
        }

        // (Note: A more thorough ISBN validation could be implemented if needed)
        // e.g. Building Java Programs 5th Edition's ISBN-13 is '978-0135471944'
        // so we should trim hyphens before checking length

        // ISBN validation
        isbn = isbn.Replace("-", "");
        if (isbn.Length != 13)
            errors.Add("ISBN must be exactly 13 characters long.");

        // Description validation
        if(description.Length > 1024)
            errors.Add("Description cannot be longer than 1024 characters.");

        if(errors.Count > 0)
        {
            error = string.Join("\n", errors);
            return false;
        }

        // Create new Book object
        var newBook = new Models.Book
        {
            Title = title,
            Author = author,
            Description = description,
            ISBN = isbn
        };

        // Attempt to add the book to the repository
        if (!_repo.Add(newBook))
        {
            error = "Failed to add the book. Please try again.";
            return false;
        }

        error = string.Empty;
        return true;
    }
}
