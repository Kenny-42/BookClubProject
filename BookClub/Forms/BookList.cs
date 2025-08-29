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
    private UserContext _userContext;

    public BookList(UserContext userContext, AccountsRepository repo, BookRepository bookRepo)
    {
        InitializeComponent();
        _repo = repo;
        _bookRepo = bookRepo;
        _userContext = userContext;
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
        // Pass the current account from UserContext
        EditAccount editAccountForm = new EditAccount(_userContext, _repo);
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
                var bookContext = Program.AppServices.GetRequiredService<BookContext>();
                bookContext.CurrentBook = clickedBook;

                Reviews reviewsForm = Program.AppServices.GetRequiredService<Reviews>();
                reviewsForm.Show();
                this.Hide();
            };

            pnlBookList.Controls.Add(btn);
        }
    }
}
