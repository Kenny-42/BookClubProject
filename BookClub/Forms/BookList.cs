using BookClub.Data;
using BookClub.Models;
using BookClub.Repositories;
using BookClub.Resources;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms;

public partial class BookList : Form
{
    private AccountsRepository _repo;
    private BookRepository _bookRepo;
    private Book? _selectedBook = null;

    public BookList(AccountsRepository repo, BookRepository bookRepo)
    {
        InitializeComponent();
        _repo = repo;
        _bookRepo = bookRepo;
        this.FormClosed += (s, args) => Application.Exit();
        PopulateBookList();
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        Login loginForm = Program.AppServices.GetRequiredService<Login>();
        loginForm.Show();
        this.Hide();
    }

    private void btnAddBook_Click(object sender, EventArgs e)
    {
        AddBook addBookForm = Program.AppServices.GetRequiredService<AddBook>();
        addBookForm.Show();
        this.Hide();
    }

    private void btnEditAccount_Click(object sender, EventArgs e)
    {
        EditAccount editAccountForm = Program.AppServices.GetRequiredService<EditAccount>();
        editAccountForm.Show();
        this.Hide();
    }

    private void PopulateBookList()
    {
        pnlBookList.Controls.Clear();

        var books = _bookRepo.GetAll().ToList();

        if (books.Count == 0)
            return;

        int buttonHeight = 50;
        int spacing = 10;

        for (int i = 0; i < books.Count; i++)
        {
            var book = books[i];
            Button btn = new Button();
            btn.Text = $"{book.Title}\nby {book.Author}";
            btn.Width = pnlBookList.ClientSize.Width - 2 * spacing;
            btn.Height = buttonHeight;
            btn.Left = spacing;
            btn.Top = i * (buttonHeight + spacing);
            btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn.Tag = book;
            btn.UseCompatibleTextRendering = true;

            btn.Click += (s, e) =>
            {
                var clickedBook = (Book)((Button)s).Tag;
                _selectedBook = clickedBook;

                btnEditBook.Enabled = true;
                btnDeleteBook.Enabled = true;
                btnAddReview.Enabled = true;
            };

            pnlBookList.Controls.Add(btn);
        }
    }

    private void btnEditBook_Click(object sender, EventArgs e)
    {
        // Navigate to EditBook form with the selected book
        EditBook editBookForm = Program.AppServices.GetRequiredService<EditBook>();
        editBookForm.Show();
        this.Hide();
    }

    private void btnDeleteBook_Click(object sender, EventArgs e)
    {
        // TODO: Implement delete functionality
        var result = MessageBox.Show(
            "Are you sure you want to delete this book?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        // If user confirmed, delete the book
        if (result == DialogResult.Yes)
        {
            _bookRepo.Delete(_selectedBook!.Id);
            pnlBookList.Controls.Clear();
            PopulateBookList();
        }
    }

    private void btnReviews_Click(object sender, EventArgs e)
    {
        // Set the current book in BookContext
        var bookContext = Program.AppServices.GetRequiredService<BookContext>();
        bookContext.CurrentBook = _selectedBook!;

        // Open the Reviews form
        Reviews reviewsForm = Program.AppServices.GetRequiredService<Reviews>();
        reviewsForm.Show();
        this.Hide();
    }
}
