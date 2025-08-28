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

    private void btnCreateAccount_Click(object sender, EventArgs e)
    {
        // Get user input from textboxes
        string firstName = txtFirstName.Text;
        string lastName = txtLastName.Text;
        string email = txtEmail.Text;
        string username = txtUsername.Text;
        string password = txtPassword.Text;

        // Create Account object
        var newAccount = new Account
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Username = username,
            Password = password
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
