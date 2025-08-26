using BookClub.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub;

public partial class Login : Form
{
    private AppDbContext _context;
    public Login(AppDbContext context)
    {
        InitializeComponent();
        _context = context;
        this.FormClosed += (s, args) => Application.Exit();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        // Resolve BookList form via DI
        var bookListForm = Program.AppServices.GetRequiredService<BookList>();

        // Show the BookList form
        bookListForm.Show();

        // Hide the current Login form
        this.Hide();
    }

    private void btnCreateAccount_Click(object sender, EventArgs e)
    {
        CreateAccount createAccountForm = Program.AppServices.GetRequiredService<CreateAccount>();
        createAccountForm.Show();
        this.Hide();
    }
}
