using BookClub.Data;

namespace BookClub
{
    public partial class Login : Form
    {
        private AppDbContext _context;
        public Login(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            //this.FormClosed += (s, args) => Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            BookList bookListForm = new BookList();
            bookListForm.Show();
            this.Hide();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAccount createAccountForm = new CreateAccount();
            createAccountForm.Show();
            this.Hide();
        }
    }
}
