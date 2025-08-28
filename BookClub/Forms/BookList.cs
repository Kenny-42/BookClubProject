using BookClub.Data;
using BookClub.Models;
using BookClub.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms;

public partial class BookList : Form
{
    private AccountsRepository _repo;
    private UserContext _userContext;

    public BookList(UserContext userContext, AccountsRepository repo)
    {
        InitializeComponent();
        _repo = repo;
        _userContext = userContext;
        this.FormClosed += (s, args) => Application.Exit();
        //PopulateBookList();
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

        var books = new List<(int BookId, string Title, string Author)>();
        string connectionString = "Server=localhost;Database=BookClub;Trusted_Connection=True;TrustServerCertificate=True;";
        string query = "SELECT BookId, Title, Author FROM Books";

        using (var conn = new SqlConnection(connectionString))
        using (var cmd = new SqlCommand(query, conn))
        {
            conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    books.Add((reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
            }
        }

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
            btn.Tag = book.BookId;
            btn.UseCompatibleTextRendering = true;

            btn.Click += (s, e) =>
            {
                int bookId = (int)((Button)s).Tag;
                var context = Program.AppServices.GetRequiredService<AppDbContext>();
                Reviews reviewsForm = new Reviews(context, bookId);
                reviewsForm.Show();
                this.Hide();
            };

            pnlBookList.Controls.Add(btn);
        }
    }
}
