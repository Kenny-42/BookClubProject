using BookClub.Data;
using BookClub.Models;
using BookClub.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms
{
    public partial class EditAccount : Form
    {
        private AccountsRepository _repo;
        private UserContext _userContext;
        public EditAccount(UserContext userContext, AccountsRepository repo)
        {
            InitializeComponent();
            _userContext = userContext;
            _repo = repo;
            this.FormClosed += (s, args) => Application.Exit();

            PopulateTextboxes(this, _userContext.CurrentAccount);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login loginForm = Program.AppServices.GetRequiredService<Login>();
            loginForm.Show();
            this.Hide();
        }

        private void btnBookList_Click(object sender, EventArgs e)
        {
            BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();
            bookListForm.Show();
            this.Hide();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            var currentAccount = _userContext.CurrentAccount;
            var result = MessageBox.Show("Are you sure you want to delete your account? This action cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                bool deleted = _repo.Delete(currentAccount.Id);
                if (deleted)
                {
                    MessageBox.Show("Your account has been deleted.", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _userContext.CurrentAccount = null;
                    Login loginForm = Program.AppServices.GetRequiredService<Login>();
                    loginForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to delete account. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            if (!string.IsNullOrEmpty(firstName) && firstName.Length > 50)
            {
                error = "First name must be 50 characters or fewer.";
                return false;
            }
            if (!string.IsNullOrEmpty(lastName) && lastName.Length > 50)
            {
                error = "Last name must be 50 characters or fewer.";
                return false;
            }

            // Email must be a valid email format
            if (!string.IsNullOrEmpty(email))
            {
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
            }

            // Username must be 2-20 characters, only letters/numbers/underscores, start and end with a letter/number
            // and be unique (no other account uses it)
            if (!string.IsNullOrEmpty(username))
            {
                if (username.Length < 2 || username.Length > 20)
                {
                    error = "Username must be between 2 and 20 characters.";
                    return false;
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(username, "^[a-zA-Z0-9][a-zA-Z0-9_]*[a-zA-Z0-9]$"))
                {
                    error = "Username must only contain letters, numbers, underscores, and start/end with a letter or number.";
                    return false;
                }
                
                var currentAccount = _userContext.CurrentAccount;
                var existing = _repo.GetByKey(a => a.Username == username);
                if (existing != null && existing.Id != currentAccount.Id)
                {
                    error = "Username is already taken.";
                    return false;
                }
            }

            // Password must be between 3-32 characters and only contain letters, numbers,
            // and special characters
            if (!string.IsNullOrEmpty(password))
            {
                if (password.Length < 3 || password.Length > 32)
                {
                    error = "Password must be between 3 and 32 characters.";
                    return false;
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"^[\w\d\p{P}\p{S}]+$"))
                {
                    error = "Password contains invalid characters.";
                    return false;
                }
            }
            return true;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            var currentAccount = _userContext.CurrentAccount;

            // Read textbox values
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validate inputs
            string error;
            if (!ValidateInputs(firstName, lastName, email, username, password, out error))
            {
                MessageBox.Show(error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PopulateTextboxes(this, currentAccount);
                return;
            }

            // Only update fields that are not blank and different from current value
            var dto = new AccountUpdateDTO();
            if (!string.IsNullOrEmpty(firstName) && firstName != currentAccount.FirstName)
            {
                dto.FirstName = firstName;
            }
            if (!string.IsNullOrEmpty(lastName) && lastName != currentAccount.LastName)
            {
                dto.LastName = lastName;
            }
            if (!string.IsNullOrEmpty(email) && email != currentAccount.Email)
            {
                dto.Email = email;
            }
            if (!string.IsNullOrEmpty(username) && username != currentAccount.Username)
            {
                dto.Username = username;
            }
            if (!string.IsNullOrEmpty(password) && password != currentAccount.Password)
            {
                dto.Password = password;
            }

            bool updated = _repo.Update(currentAccount.Id, dto);
            if (updated)
            {
                // Update the UserContext with new values
                if (dto.FirstName != null) currentAccount.FirstName = dto.FirstName;
                if (dto.LastName != null) currentAccount.LastName = dto.LastName;
                if (dto.Email != null) currentAccount.Email = dto.Email;
                if (dto.Username != null) currentAccount.Username = dto.Username;
                if (dto.Password != null) currentAccount.Password = dto.Password;
                MessageBox.Show("Account updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No changes to account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Repopulate textboxes with updated values
            PopulateTextboxes(this, currentAccount);
        }

        public static void PopulateTextboxes(EditAccount form, Account account)
        {
            // set textbox text to empty and placeholder to current value
            form.txtFirstName.Text = "";
            form.txtLastName.Text = "";
            form.txtEmail.Text = "";
            form.txtUsername.Text = "";
            form.txtPassword.Text = "";

            form.txtFirstName.PlaceholderText = account.FirstName;
            form.txtLastName.PlaceholderText = account.LastName;
            form.txtEmail.PlaceholderText = account.Email;
            form.txtUsername.PlaceholderText = account.Username;
            form.txtPassword.PlaceholderText = account.Password;
        }
    }
}