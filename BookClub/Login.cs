using BookClub.Data;
using BookClub.Models;
using BookClub.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub;

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
        //bool result = _context.accounts
        //    .FirstOrDefault(u => u.Username == txtUsername.Text && u.Password == txtPassword.Text) != null;

        bool result = _repo.GetByKey(a => a.Username == txtUsername.Text && a.Password == txtPassword.Text) != null;

        if (!result) return;

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

    private void TryLogin()
    {
        
    }
}
