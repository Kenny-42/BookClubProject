using BookClub.Models;
using BookClub.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace BookClub.Forms;

public partial class ResetPassword : Form
{
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

        account!.Password = newPassword;

        AccountUpdateDTO dto = new()
        {
            Password = newPassword
        };

        _repo.Update(account.Id, dto);

        MessageBox.Show("Password reset successfully. Please log in with your new password.");

        Login loginForm = Program.AppServices.GetRequiredService<Login>();
        loginForm.Show();
        this.Hide();
    }
}
