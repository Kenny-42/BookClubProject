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
        if (!TryLogin(txtUsername.Text, txtPassword.Text, out string error))
        {
            MessageBox.Show(error, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    private bool TryLogin(string username, string password, out string error)
    {
        error = string.Empty;

        // Trim inputs to avoid leading/trailing spaces
        username = username.Trim();
        password = password.Trim();

        // Make sure both fields are filled
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            error = "Both fields must be filled.";
            return false;
        }

        // Retrieve account by username
        Account? result = _repo.GetByKey(a => a.Username == username);

        // Check if account exists
        if (result == null)
        {
            error = $"No Account with username: {username} found.";
            return false;
        }

        // Check password
        if (result.Password != password)
        {
            error = "Incorrect password.";
            return false;
        }

        return true;
    }
}
