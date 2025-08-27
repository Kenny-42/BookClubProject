using BookClub.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub
{
    public partial class DiscussionBoard : Form
    {
        private AppDbContext _context;
        private int _bookId;

        public DiscussionBoard(AppDbContext context, int bookId)
        {
            InitializeComponent();

            _bookId = bookId;

            this.FormClosed += (s, args) => Application.Exit();

            LoadBookInfo(_bookId);
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

        private void btnReviews_Click(object sender, EventArgs e)
        {
            Reviews reviewsForm = Program.AppServices.GetRequiredService<Reviews>();
            reviewsForm.Show();
            this.Hide();
        }

        private void LoadBookInfo(int bookId)
        {
            string connectionString = "Server=localhost;Database=BookClub;Trusted_Connection=True;TrustServerCertificate=True;";
            string query = "SELECT Title, Author, ISBN, BookDescription FROM Books WHERE BookId = @BookId";

            using (var conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BookId", bookId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblBookTitle.Text = reader["Title"].ToString();
                        lblAuthor.Text = "Author: " + reader["Author"].ToString();
                        lblISBN.Text = "ISBN: " + reader["ISBN"].ToString();
                        lblDescription.Text = reader["BookDescription"].ToString();
                    }
                    else
                    {
                        lblBookTitle.Text = "Book Title";
                        lblAuthor.Text = "Author";
                        lblISBN.Text = "ISBN";
                        lblDescription.Text = "Description";
                    }
                }
            }
        }
    }
}
