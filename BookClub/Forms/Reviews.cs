using BookClub.Data;
using BookClub.Repositories;
using BookClub.Resources;
using BookClub.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms;

public partial class Reviews : Form
{
    private AccountsRepository _repo;
    private BookRepository _bookRepo;
    private UserContext _userContext;
    private BookContext _bookContext;
    private Book _book;

    private PictureBox[] stars;
    private int currentRating = 0;

    public Reviews(UserContext userContext, AccountsRepository repo, BookRepository bookRepo, BookContext bookContext)
    {
        InitializeComponent();

        _repo = repo;
        _bookRepo = bookRepo;
        _userContext = userContext;
        _bookContext = bookContext;

        _book = _bookContext.CurrentBook;

        this.FormClosed += (s, args) => Application.Exit();

        LoadBookInfo();
        PopulateReviewsPanel();

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

    private void LoadBookInfo()
    {
        if (_book != null)
        {
            lblBookTitle.Text = _book.Title;
            lblAuthor.Text = "Author: " + _book.Author;
            lblISBN.Text = "ISBN: " + _book.ISBN;
            lblDescription.Text = _book.Description;
        }
        else
        {
            lblBookTitle.Text = "Book Title";
            lblAuthor.Text = "Author";
            lblISBN.Text = "ISBN";
            lblDescription.Text = "Description";
        }
    }

    public void PopulateReviewsPanel()
    {
        // Clear previous controls
        pnlReviewBoard.Controls.Clear();

        // Retrieve all reviews for the current book from the repository
        var reviewsRepo = Program.AppServices.GetRequiredService<ReviewsRepository>();
        var allReviews = reviewsRepo.GetAll()
            .Where(r => r.BookId == _book.Id)
            .OrderByDescending(r => r.CreatedAt)
            .ToList();

        // Dynamically create groupboxes for each review
        var accountsRepo = Program.AppServices.GetRequiredService<AccountsRepository>();
        int y = 10;
        int spacing = 6;
        int groupBoxWidth = pnlReviewBoard.Width - 40;
        int groupBoxPadding = 10;
        foreach (var review in allReviews)
        {
            var account = accountsRepo.GetByKey(a => a.Id == review.AccountId);
            string username = account.Username;

            // GroupBox for the review
            var groupBox = new GroupBox();
            groupBox.Width = groupBoxWidth;
            groupBox.Left = 10;
            groupBox.Top = y;
            groupBox.Text = $"{username}";
            groupBox.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Label for review message (multiline, autosize)
            var lblReview = new Label();
            lblReview.Text = review.Comment;
            lblReview.Font = new Font("Segoe UI", 10);
            lblReview.Left = groupBoxPadding;
            lblReview.Top = 18;
            lblReview.MaximumSize = new Size(groupBox.Width - 2 * groupBoxPadding, 0); // restrict width, allow height to grow
            lblReview.AutoSize = true;

            // Label for date (smaller text)
            var lblDate = new Label();
            lblDate.Text = review.CreatedAt.ToString("yyyy-MM-dd HH:mm");
            lblDate.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            lblDate.ForeColor = Color.DimGray;
            lblDate.Left = groupBoxPadding;
            lblDate.Top = lblReview.Top + lblReview.Height + 2;
            lblDate.Width = groupBox.Width - 2 * groupBoxPadding;
            lblDate.Height = 16;
            lblDate.AutoSize = false;

            // Panel for stars
            var starsPanel = new Panel();
            starsPanel.Width = 130;
            starsPanel.Height = 20;
            starsPanel.Left = groupBoxPadding;
            starsPanel.Top = lblDate.Top + lblDate.Height + 1;
            for (int i = 0; i < 5; i++)
            {
                var star = new PictureBox();
                star.Width = 18;
                star.Height = 18;
                star.Left = i * 20;
                star.Top = 0;
                star.SizeMode = PictureBoxSizeMode.StretchImage;
                star.Image = i < review.Rating ? Properties.Resources.star_filled : Properties.Resources.star_empty;
                starsPanel.Controls.Add(star);
            }

            // Dynamically set groupbox height
            int totalHeight = lblReview.Height + 2 + lblDate.Height + 1 + starsPanel.Height + groupBoxPadding;
            groupBox.Height = totalHeight + 18; // 18 for groupbox title/header

            groupBox.Controls.Add(lblReview);
            groupBox.Controls.Add(lblDate);
            groupBox.Controls.Add(starsPanel);
            pnlReviewBoard.Controls.Add(groupBox);
            y += groupBox.Height + spacing;
        }
    }
}
