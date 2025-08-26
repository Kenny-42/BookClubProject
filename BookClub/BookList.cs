using BookClub.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub
{
    public partial class BookList : Form
    {
        private AppDbContext _context;
        public BookList(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            //PopulateBookList();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var loginForm = Program.AppServices.GetRequiredService<Login>();
            loginForm.Show();
            this.Hide();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddBook addBookForm = Program.AppServices.GetRequiredService<AddBook>();
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

                btn.Click += (s, e) =>
                {
                    int bookId = (int)((Button)s).Tag;
                    Reviews reviewsForm = new Reviews(bookId);
                    reviewsForm.Show();
                    this.Hide();
                };

                pnlBookList.Controls.Add(btn);
            }
        }
    }
}
