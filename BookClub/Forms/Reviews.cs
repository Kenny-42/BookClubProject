using BookClub.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms;

public partial class Reviews : Form
{
    private AppDbContext _context;
    private PictureBox[] stars;
    private int currentRating = 0;
    private int _bookId;

    public Reviews(AppDbContext context, int bookId)
    {
        InitializeComponent();
        _context = context;

        _bookId = bookId;

        this.FormClosed += (s, args) => Application.Exit();

        LoadBookInfo(_bookId);

        stars = new PictureBox[] { pcbStar1, pcbStar2, pcbStar3, pcbStar4, pcbStar5 };
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].Tag = i + 1;
            stars[i].Image = Properties.Resources.star_empty;
            stars[i].Cursor = Cursors.Hand;
            stars[i].Click += Star_Click;
        }
    }

    private void Star_Click(object sender, EventArgs e)
    {
        PictureBox clickedStar = sender as PictureBox;
        int rating = (int)clickedStar.Tag;
        currentRating = rating;
        UpdateStarImages(rating);
    }

    private void UpdateStarImages(int rating)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i < rating)
            {
                stars[i].Image = Properties.Resources.star_filled;
            }
            else
            {
                stars[i].Image = Properties.Resources.star_empty;
            }
        }
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        var loginForm = Program.AppServices.GetRequiredService<Login>();
        loginForm.Show();
        this.Hide();
    }

    private void btnBookList_Click(object sender, EventArgs e)
    {
        BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();
        bookListForm.Show();
        this.Hide();
    }

    private void btnOpenDiscussionBoard_Click(object sender, EventArgs e)
    {
        DiscussionBoard discussionBoardForm = Program.AppServices.GetRequiredService<DiscussionBoard>();
        discussionBoardForm.Show();
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
