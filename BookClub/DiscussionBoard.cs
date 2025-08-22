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
    public partial class DiscussionBoard : Form
    {
        public DiscussionBoard()
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

        private void btnBookList_Click(object sender, EventArgs e)
        {
            BookList bookListForm = new BookList();
            bookListForm.Show();
            this.Hide();
        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            Reviews reviewsForm = new Reviews();
            reviewsForm.Show();
            this.Hide();
        }
    }
}
