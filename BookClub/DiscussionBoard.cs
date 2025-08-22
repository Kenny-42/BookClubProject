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
        private int _bookId;

        public DiscussionBoard(int bookId)
        {
            InitializeComponent();
            this.FormClosed += (s, args) => Application.Exit();
            _bookId = bookId;
            // Use _bookId to load book-specific discussions or info here
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
            Reviews reviewsForm = new Reviews(_bookId);
            reviewsForm.Show();
            this.Hide();
        }
    }
}
