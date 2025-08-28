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

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            var currentAccount = _userContext.CurrentAccount;

            // Read textbox values
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

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
                MessageBox.Show("Failed to update account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}