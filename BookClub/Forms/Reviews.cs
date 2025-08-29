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
            groupBox.Controls.Add(lblReview); // Add first so height is calculated

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
            groupBox.Controls.Add(lblDate);

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
            groupBox.Controls.Add(starsPanel);

            // Dynamically set groupbox height after controls are added
            int bottom = starsPanel.Top + starsPanel.Height;
            groupBox.Height = bottom + groupBoxPadding;

            pnlReviewBoard.Controls.Add(groupBox);
            y += groupBox.Height + spacing;
        }
    }

    private bool ValidateInputs(string reviewMessage, int rating, out string error)
    {
        if (string.IsNullOrWhiteSpace(reviewMessage))
        {
            error = "Please enter a review message.";
            return false;
        }
        if (reviewMessage.Length > 1024)
        {
            error = "Review message cannot be longer than 1024 characters.";
            return false;
        }
        if (rating < 1 || rating > 5)
        {
            error = "Star rating must be 1-5.";
            return false;
        }
        error = string.Empty;
        return true;
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        // Read the review message from the textbox and the selected star rating
        string reviewMessage = txtReview.Text.Trim();
        int rating = currentRating;

        // Validate inputs
        string error;
        if (!ValidateInputs(reviewMessage, rating, out error))
        {
            MessageBox.Show(error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Create a new Review object with the user's input
        var reviewsRepo = Program.AppServices.GetRequiredService<ReviewsRepository>();
        var newReview = new Review
        {
            BookId = _book.Id,
            AccountId = _userContext.CurrentAccount.Id,
            Rating = rating,
            Comment = reviewMessage,
            CreatedAt = DateTime.Now
        };

        // Add the new review to the database
        bool added = reviewsRepo.Add(newReview);

        if (added)
        {
            // If successful, clear the input fields and reset the star rating
            txtReview.Text = string.Empty;
            currentRating = 0;
            UpdateStarImages(0);

            // Refresh the reviews panel to show the new review
            PopulateReviewsPanel();
        }
        else
        {
            // Show an error if the review could not be added
            MessageBox.Show("Failed to add review. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
