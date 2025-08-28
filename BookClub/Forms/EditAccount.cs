using BookClub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms
{
    public partial class EditAccount : Form
    {
        private AppDbContext _context;
        public EditAccount(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
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
    }
}
