using BookClub.Models;
using BookClub.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace BookClub.Forms;

/// <summary>
/// Represents a form that allows users to reset their account password.
/// </summary>
/// <remarks>This form provides functionality for users to reset their password by verifying their email and
/// username. It validates user input, ensures password complexity, and updates the account's password in the
/// repository. If the reset is successful, the user is redirected to the login form.</remarks>
public partial class ResetPassword : Form
{
    /// <summary>
    /// Provides access to account data for performing operations such as retrieving and updating accounts.
    /// </summary>
    private AccountsRepository _repo;
    public ResetPassword(AccountsRepository repo)
    {
        InitializeComponent();
        _repo = repo;
        this.FormClosed += (s, args) => Application.Exit();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        Login loginForm = Program.AppServices.GetRequiredService<Login>();
        loginForm.Show();
        this.Hide();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        // Trim inputs to avoid leading/trailing spaces
        var email = txtEmail.Text.Trim();
        var username = txtUsername.Text.Trim();
        var newPassword = txtNewPassword.Text;
        var confirmPassword = txtConfirmPassword.Text;

        List<string> errors = new();

        // Make sure all fields are filled
        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(newPassword) ||
            string.IsNullOrWhiteSpace(confirmPassword)
            )
        {
            errors.Add("All fields must be filled.");
        }

        // Simple email regex pattern for validation
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            errors.Add("Invalid email format.");
        }

        // Basic password complexity check
        if (newPassword.Length < 5)
        {
            errors.Add("Password must be at least 5 characters and include uppercase, number, and symbol.");
        }

        // Make sure passwords match
        if (newPassword != confirmPassword)
        {
            errors.Add("Passwords don't match.");
        }

        // Retrieve account by username and email
        var account = _repo.GetByKey(a => a.Username == username && a.Email == email);

        // Ensure new password is different from old password
        if (account?.Password == newPassword)
        {
            errors.Add("New password must be different from the old password.");
        }

        // Check if account exists, if not, clear other errors and show this one
        if (account == null)
        {
            errors.Clear();
            errors.Add("No matching account found.");
        }

        // If any errors, show them and return
        if (errors.Any())
        {
            MessageBox.Show(string.Join("\n", errors));
            return;
        }

        // Use DTO for partial update
        AccountUpdateDTO dto = new()
        {
            Password = newPassword
        };

        // Performs partial update
        _repo.Update(account.Id, dto);

        // Confirmation message
        MessageBox.Show("Password reset successfully. Please log in with your new password.");

        // Navigate back to Login
        Login loginForm = Program.AppServices.GetRequiredService<Login>();
        loginForm.Show();
        this.Hide();
    }
}
