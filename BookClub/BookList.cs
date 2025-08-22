using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookClub
{
    public partial class BookList : Form
    {
        public BookList()
        {
            InitializeComponent();
            this.FormClosed += (s, args) => Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddBook addBookForm = new AddBook();
            addBookForm.Show();
            this.Hide();
        }
    }
}
