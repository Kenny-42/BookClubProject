using BookClub.Data;
using BookClub.Models;
using BookClub.Repositories;
using BookClub.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms;

public partial class DiscussionBoard : Form
{
    private readonly DiscussionsRepository _discussionsRepo;
    private Book? _selectedBook = null;
    private GroupBox? _selectedGroupBox = null;
    private Discussion? _selectedDiscussion = null;

    public DiscussionBoard(DiscussionsRepository discussionsRepo)
    {
        InitializeComponent();

        _discussionsRepo = discussionsRepo;

        _selectedBook = Program.AppServices.GetRequiredService<BookContext>().CurrentBook;

        this.FormClosed += (s, args) => Application.Exit();

        DisablePostActionButtons();

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

        var accountsRepo = Program.AppServices.GetRequiredService<AccountsRepository>();

        // Fetch discussions for this book
        var discussions = _discussionsRepo.GetAll()
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

            groupBox.Click += (s, e) => SelectDiscussionGroupBox(groupBox, discussion);
            foreach (Control ctrl in groupBox.Controls)
            {
                ctrl.Click += (s, e) => SelectDiscussionGroupBox(groupBox, discussion);
            }

            // Add to panel
            pnlDiscussionBoard.Controls.Add(groupBox);

            y += groupBox.Height + spacing;
        }
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtDiscussionPost.Text))
        {
            MessageBox.Show("Please enter a comment before submitting.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var userContext = Program.AppServices.GetRequiredService<UserContext>();

        Discussion newDiscussion = new Discussion
        {
            BookId = _selectedBook.Id,
            AccountId = userContext.CurrentAccount.Id,
            Comment = txtDiscussionPost.Text.Trim(),
            //PostedAt = DateTime.Now
        };

        _discussionsRepo.Add(newDiscussion);

        // Clear input and refresh panel
        txtDiscussionPost.Text = string.Empty;

        pnlDiscussionBoard.Controls.Clear();
        PopulateDiscussionsPanel();
    }

    private void SelectDiscussionGroupBox(GroupBox groupBox, Discussion discussion)
    {
        var currentUser = Program.AppServices.GetRequiredService<UserContext>().CurrentAccount;
        if (discussion.AccountId != currentUser.Id)
        {
            return; // Not the owner, ignore selection
        }

        // Deselect previous
        if (_selectedGroupBox != null)
            _selectedGroupBox.BackColor = Color.White;

        // Select current
        _selectedGroupBox = groupBox;
        _selectedGroupBox.BackColor = Color.LightBlue;

        _selectedDiscussion = discussion;

        // Enable buttons
        EnablePostActionButtons();
    }

    private void EnablePostActionButtons()
    {
        btnEditPost.Enabled = true;
        btnDeletePost.Enabled = true;
    }

    private void DisablePostActionButtons()
    {
        btnEditPost.Enabled = false;
        btnDeletePost.Enabled = false;
    }

    private void btnEditPost_Click(object sender, EventArgs e)
    {
        MessageBox.Show($"Editing comment: {_selectedDiscussion.Comment}");
    }

    private void btnDeletePost_Click(object sender, EventArgs e)
    {
        // Confirm deletion
        var result = MessageBox.Show(
            "Are you sure you want to delete this book?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        // If user confirmed, delete the book
        if (result == DialogResult.Yes)
        {
            if(_selectedDiscussion == null)
            {
                MessageBox.Show("selectedDiscussion Null");
                return;
            }

            _discussionsRepo.Delete(_selectedDiscussion!.Id);

            // Refresh the posts list
            pnlDiscussionBoard.Controls.Clear();
            PopulateDiscussionsPanel();

            // Disable action buttons and clear selected book
            _selectedDiscussion = null;
            _selectedGroupBox = null;
            DisablePostActionButtons();
        }
    }
}
