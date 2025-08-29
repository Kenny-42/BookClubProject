using BookClub.Data;
using BookClub.Models;
using BookClub.Repositories;
using BookClub.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms;

public partial class DiscussionBoard : Form
{
    
    private Book? _selectedBook;

    public DiscussionBoard(AppDbContext context)
    {
        InitializeComponent();

        _selectedBook = Program.AppServices.GetRequiredService<BookContext>().CurrentBook;

        this.FormClosed += (s, args) => Application.Exit();

        LoadBookInfo();
        PopulateDiscussionsPanel();
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

    private void LoadBookInfo()
    {
        lblBookTitle.Text = _selectedBook?.Title ?? "Book Title";
        lblAuthor.Text = "Author: " + (_selectedBook?.Author ?? "Author");
        lblISBN.Text = "ISBN: " + (_selectedBook?.ISBN ?? "ISBN");
        lblDescription.Text = _selectedBook?.Description ?? "Description";
    }

    public void PopulateDiscussionsPanel()
    {
        // Clear previous controls
        pnlDiscussionBoard.Controls.Clear();

        // Get repository services
        var discussionsRepo = Program.AppServices.GetRequiredService<DiscussionsRepository>();
        var accountsRepo = Program.AppServices.GetRequiredService<AccountsRepository>();

        // Fetch discussions for this book
        var discussions = discussionsRepo.GetAll()
            .Where(d => d.BookId == _selectedBook.Id)
            .OrderBy(d => d.PostedAt)
            .ToList();

        // UI layout settings
        int y = 10;
        int spacing = 6;
        int groupBoxWidth = pnlDiscussionBoard.Width - 40;
        int groupBoxPadding = 10;

        foreach (var discussion in discussions)
        {
            var account = accountsRepo.GetByKey(a => a.Id == discussion.AccountId);
            string username = account?.Username ?? "Unknown";

            // GroupBox for each comment
            var groupBox = new GroupBox();
            groupBox.Width = groupBoxWidth;
            groupBox.Left = 10;
            groupBox.Top = y;
            groupBox.Text = $"{username}";
            groupBox.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Label for the discussion comment
            var lblComment = new Label();
            lblComment.Text = discussion.Comment;
            lblComment.Font = new Font("Segoe UI", 10);
            lblComment.Left = groupBoxPadding;
            lblComment.Top = 18;
            lblComment.MaximumSize = new Size(groupBox.Width - 2 * groupBoxPadding, 0);
            lblComment.AutoSize = true;
            groupBox.Controls.Add(lblComment);

            // Label for timestamp
            var lblDate = new Label();
            lblDate.Text = discussion.PostedAt.ToString("yyyy-MM-dd HH:mm");
            lblDate.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            lblDate.ForeColor = Color.DimGray;
            lblDate.Left = groupBoxPadding;
            lblDate.Top = lblComment.Top + lblComment.Height + 2;
            lblDate.Width = groupBox.Width - 2 * groupBoxPadding;
            lblDate.Height = 16;
            lblDate.AutoSize = false;
            groupBox.Controls.Add(lblDate);

            // Adjust height of group box after adding controls
            int bottom = lblDate.Top + lblDate.Height;
            groupBox.Height = bottom + groupBoxPadding;

            // Add to panel
            pnlDiscussionBoard.Controls.Add(groupBox);

            y += groupBox.Height + spacing;
        }
    }
}
