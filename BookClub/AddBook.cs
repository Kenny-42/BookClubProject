using BookClub.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub;

public partial class AddBook : Form
{
    private AppDbContext _context;
    public AddBook(AppDbContext context)
    {
        InitializeComponent();
        _context = context;
        this.FormClosed += (s, args) => Application.Exit();
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        var loginForm = Program.AppServices.GetRequiredService<Login>();
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
        BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();
        bookListForm.Show();
        this.Hide();
    }
}
