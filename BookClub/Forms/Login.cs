using BookClub.Models;
using BookClub.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms;

/// <summary>
/// Represents the login form for the application, allowing users to log in, create accounts, or reset passwords.
/// </summary>
/// <remarks>This form provides functionality for user authentication and navigation to other parts of the
/// application. It interacts with an <see cref="AccountsRepository"/> to validate user credentials and manage
/// account-related operations.</remarks>
public partial class Login : Form
{
    /// <summary>
    /// Represents the repository used for managing account data.
    /// </summary>
    /// <remarks>This field is intended for internal use within the class to interact with the data source for
    /// account-related operations. It should be initialized before use.</remarks>
    private AccountsRepository _repo;

    /// <summary>
    /// Initializes a new instance of the <see cref="Login"/> class.
    /// </summary>
    /// <remarks>This constructor sets up the login form and ensures the application exits when the form is
    /// closed.</remarks>
    /// <param name="repo">The repository used to manage account data. This parameter cannot be null.</param>
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

        // Successful login, set the current user context
        // UserContext is registered as a singleton, so this will be the same instance everywhere
        var userContext = Program.AppServices.GetRequiredService<UserContext>();
        userContext.CurrentAccount = account;

        // Show the BookList form
        BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();
        bookListForm.Show();

        // Hide the current Login form
        this.Hide();
    }

    private void btnCreateAccount_Click(object sender, EventArgs e)
    {
        // Show the CreateAccount form
        CreateAccount createAccountForm = Program.AppServices.GetRequiredService<CreateAccount>();
        createAccountForm.Show();
        this.Hide();
    }

    private void buttonResetPassword_Click(object sender, EventArgs e)
    {
        // Show the ResetPassword form
        ResetPassword resetPasswordForm = Program.AppServices.GetRequiredService<ResetPassword>();
        resetPasswordForm.Show();
        this.Hide();
    }

    /// <summary>
    /// Attempts to authenticate a user based on the provided username and password.
    /// </summary>
    /// <remarks>This method performs validation on the provided username and password. If either is null,
    /// empty, or consists only of  whitespace, authentication will fail. Additionally, the method checks whether the
    /// username exists in the repository  and whether the provided password matches the stored password for the
    /// account.</remarks>
    /// <param name="username">The username of the account to authenticate. Leading and trailing whitespace will be trimmed.</param>
    /// <param name="password">The password of the account to authenticate. Leading and trailing whitespace will be trimmed.</param>
    /// <param name="error">When this method returns, contains an error message describing the reason for authentication failure,  or an
    /// empty string if authentication succeeds. This parameter is passed uninitialized.</param>
    /// <returns>The authenticated <see cref="Account"/> object if the username and password are valid; otherwise, <see
    /// langword="null"/>.</returns>
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
