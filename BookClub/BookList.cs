using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace BookClub
{
    public partial class BookList : Form
    {
        public BookList()
        {
            InitializeComponent();
            this.FormClosed += (s, args) => Application.Exit();
            PopulateBookList();
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

        private void PopulateBookList()
        {
            pnlBookList.Controls.Clear();

            var books = new List<(int BookId, string Title, string Author)>();
            string connectionString = "Server=localhost;Database=BookClub;Trusted_Connection=True;TrustServerCertificate=True;";
            string query = "SELECT BookId, Title, Author FROM Books";

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add((reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                    }
                }
            }

            if (books.Count == 0)
                return;

            int buttonHeight = 50;
            int spacing = 10;

            for (int i = 0; i < books.Count; i++)
            {
                var book = books[i];
                Button btn = new Button();
                btn.Text = $"{book.Title}\nby {book.Author}";
                btn.Width = pnlBookList.ClientSize.Width - 2 * spacing;
                btn.Height = buttonHeight;
                btn.Left = spacing;
                btn.Top = i * (buttonHeight + spacing);
                btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                btn.Tag = book.BookId;
                btn.UseCompatibleTextRendering = true;
                pnlBookList.Controls.Add(btn);
            }
        }
    }
}
