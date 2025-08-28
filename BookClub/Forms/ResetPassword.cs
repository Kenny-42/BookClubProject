using BookClub.Data;
using BookClub.Repositories;
using Microsoft.Extensions.DependencyInjection;

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
        // TODO: Implement password reset logic
        // I figured just check if the username and email match an existing account
        // and if so, update the password to the new password

        Login loginForm = Program.AppServices.GetRequiredService<Login>();
        loginForm.Show();
        this.Hide();
    }
}
