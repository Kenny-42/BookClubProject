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
    }
}
    