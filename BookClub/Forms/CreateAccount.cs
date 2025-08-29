using BookClub.Data;
using BookClub.Models;
using BookClub.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms;

public partial class CreateAccount : Form
{
    private AppDbContext _context;
    private AccountsRepository _repo;
    private UserContext _userContext;
    public CreateAccount(AppDbContext context, AccountsRepository repo, UserContext userContext)
    {
        InitializeComponent();
        _context = context;
        _repo = repo;
        _userContext = userContext;
        this.FormClosed += (s, args) => Application.Exit();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        Login loginForm = Program.AppServices.GetRequiredService<Login>();
        loginForm.Show();
        this.Hide();
    }

    private bool ValidateInputs(string firstName, string lastName, string email, string username, string password, out string error)
    {
        error = string.Empty;

        // Trim all inputs
        firstName = firstName.Trim();
        lastName = lastName.Trim();
        email = email.Trim();
        username = username.Trim();
        password = password.Trim();

        // First and last names must be 50 or fewer characters
        if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > 50)
        {
            error = "First name is required and must be 50 characters or fewer.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > 50)
        {
            error = "Last name is required and must be 50 characters or fewer.";
            return false;
        }

        // Email must be a valid email format
        if (string.IsNullOrWhiteSpace(email))
        {
            error = "Email is required.";
            return false;
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            if (addr.Address != email)
            {
                error = "Invalid email format.";
                return false;
            }
        }
        catch
        {
            error = "Invalid email format.";
            return false;
        }

        // Username must be 2-20 characters, only letters/numbers/underscores, start and end with a letter/number
        // and be unique (no other account uses it)
        if (string.IsNullOrWhiteSpace(username) || username.Length < 2 || username.Length > 20)
        {
            error = "Username is required and must be between 2 and 20 characters.";
            return false;
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(username, "^[a-zA-Z0-9][a-zA-Z0-9_]*[a-zA-Z0-9]$"))
        {
            error = "Username must only contain letters, numbers, underscores, and start/end with a letter or number.";
            return false;
        }
        var existing = _repo.GetByKey(a => a.Username == username);
        if (existing != null)
        {
            error = "Username is already taken.";
            return false;
        }

        // Password must be between 3-32 characters and only contain letters, numbers,
        // and special characters
        if (string.IsNullOrWhiteSpace(password) || password.Length < 3 || password.Length > 32)
        {
            error = "Password is required and must be between 3 and 32 characters.";
            return false;
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"^[\w\d\p{P}\p{S}]+$"))
        {
            error = "Password contains invalid characters.";
            return false;
        }
        return true;
    }

    private void btnCreateAccount_Click(object sender, EventArgs e)
    {
        // Get user input from textboxes
        string firstName = txtFirstName.Text;
        string lastName = txtLastName.Text;
        string email = txtEmail.Text;
        string username = txtUsername.Text;
        string password = txtPassword.Text;

        // Validate inputs
        string error;
        if (!ValidateInputs(firstName, lastName, email, username, password, out error))
        {
            MessageBox.Show(error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Create Account object
        var newAccount = new Account
        {
            FirstName = firstName.Trim(),
            LastName = lastName.Trim(),
            Email = email.Trim(),
            Username = username.Trim(),
            Password = password.Trim()
        };

        // Add to database
        bool success = _repo.Add(newAccount);
        if (success)
        {
            // Set current user context
            _userContext.CurrentAccount = newAccount;

            // Show BookList form
            BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();
            bookListForm.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show("Failed to create account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
