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
        // Attempt login
        string error;
        Account? account = TryLogin(txtUsername.Text, txtPassword.Text, out error);
        if (account == null)
        {
            MessageBox.Show(error, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Grab account ID to pass to other forms
        int accountId = account.Id;

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

    private Account? TryLogin(string username, string password, out string error)
    {
        error = string.Empty;

        // Trim inputs to avoid leading/trailing spaces
        username = username.Trim();
        password = password.Trim();

        // Make sure both fields are filled
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            error = "Both fields must be filled.";
            return null;
        }

        // Retrieve account by username
        Account? result = _repo.GetByKey(a => a.Username == username);

        // Check if account exists
        if (result == null)
        {
            error = $"No Account with username: {username} found.";
            return null;
        }

        // Check password
        if (result.Password != password)
        {
            error = "Incorrect password.";
            return null;
        }

        return result;
    }
}
