using BookClub.Models;
using BookClub.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms;

public partial class Login : Form
{
    private AccountsRepository _repo;
    public Login(AccountsRepository repo)
    {
        InitializeComponent();
        _repo = repo;
        this.FormClosed += (s, args) => Application.Exit();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        // Very simple login check
        // Recommend turning into separate function and adding more checks
        // e.g. signature `private string TryLogin(string username, string password)
        bool result = _repo.GetByKey(a => a.Username == txtUsername.Text && a.Password == txtPassword.Text) != null;

        if (!result)
        {
            MessageBox.Show("Nope");
            return;
        }

        // Resolve BookList form via DI
        BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();

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

    private void buttonResetPassword_Click(object sender, EventArgs e)
    {
        ResetPassword resetPasswordForm = Program.AppServices.GetRequiredService<ResetPassword>();
        resetPasswordForm.Show();
        this.Hide();
    }
}
