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
        Login loginForm = Program.AppServices.GetRequiredService<Login>();
        loginForm.Show();
        this.Hide();
    }

    private void btnBookList_Click(object sender, EventArgs e)
    {
        BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();
        bookListForm.Show();
        this.Hide();
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if(!TryAddBook(txtTitle.Text, txtAuthor.Text, txtDescription.Text, txtISBN.Text, out string error))
        {
            MessageBox.Show(error, "Add Book Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();
        bookListForm.Show();
        this.Hide();
    }

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
