using BookClub.Data;
using BookClub.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms;

public partial class AddBook : Form
{
    private BookRepository _repo;
    public AddBook(BookRepository repo)
    {
        InitializeComponent();
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

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();
        bookListForm.Show();
        this.Hide();
    }
}
