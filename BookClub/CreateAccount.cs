using BookClub.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub;

public partial class CreateAccount : Form
{
    private AppDbContext _context;
    public CreateAccount(AppDbContext context)
    {
        InitializeComponent();
        _context = context;
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        Login loginForm = Program.AppServices.GetRequiredService<Login>();
        loginForm.Show();
        this.Hide();
    }

    private void btnCreateAccount_Click(object sender, EventArgs e)
    {
        BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();
        bookListForm.Show();
        this.Hide();
    }
}
