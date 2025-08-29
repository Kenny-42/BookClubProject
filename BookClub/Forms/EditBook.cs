using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookClub.Forms
{
    public partial class EditBook : Form
    {
        public EditBook()
        {
            InitializeComponent();
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
