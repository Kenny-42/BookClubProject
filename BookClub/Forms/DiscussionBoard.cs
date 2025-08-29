using BookClub.Data;
using BookClub.Models;
using BookClub.Repositories;
using BookClub.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms;

/// <summary>
/// Represents a discussion board interface for managing and interacting with discussions related to a specific book.
/// </summary>
/// <remarks>The <see cref="DiscussionBoard"/> class provides a user interface for viewing, creating, editing, and
/// deleting discussions associated with a selected book. It integrates with the application's dependency injection
/// system to retrieve necessary services and repositories, such as <see cref="DiscussionsRepository"/> for managing
/// discussions and <see cref="BookContext"/> for accessing the current book context.  This form includes functionality
/// for: - Displaying book information (title, author, ISBN, description). - Listing discussions related to the selected
/// book, ordered by their posting time. - Allowing users to create new discussion posts. - Enabling users to edit or
/// delete their own discussion posts. - Navigating to other forms, such as the login screen, book list, or reviews. 
/// The form ensures that only the owner of a discussion post can edit or delete it. It also provides validation for
/// user input when creating new posts.</remarks>
public partial class DiscussionBoard : Form
{
    /// <summary>
    /// Provides access to discussion data operations.
    /// </summary>
    private readonly DiscussionsRepository _discussionsRepo;

    /// <summary>
    /// Represents the currently selected book. This field may be null if no book is selected.
    /// </summary>
    /// <remarks>This field is intended to store the state of the selected book within the application.  It
    /// can be null to indicate that no book is currently selected.</remarks>
    private Book? _selectedBook = null;

    /// <summary>
    /// Represents the currently selected <see cref="GroupBox"/> in the application.
    /// </summary>
    /// <remarks>This field holds a reference to the selected <see cref="GroupBox"/> or <see langword="null"/>
    /// if no <see cref="GroupBox"/> is currently selected.</remarks>
    private GroupBox? _selectedGroupBox = null;

    /// <summary>
    /// Represents the currently selected discussion.
    /// </summary>
    /// <remarks>This field holds the discussion that is currently selected. It may be <see langword="null"/> 
    /// if no discussion is selected.</remarks>
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

    /// <summary>
    /// Handles the Click event of the Logout button by transitioning the user to the login form.
    /// </summary>
    /// <param name="sender">The source of the event, typically the Logout button.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    private void btnLogout_Click(object sender, EventArgs e)
    {
        Login loginForm = Program.AppServices.GetRequiredService<Login>();
        loginForm.Show();
        this.Hide();
    }

    /// <summary>
    /// Handles the click event for the "Book List" button.  Opens the <see cref="BookList"/> form and hides the current
    /// form.
    /// </summary>
    /// <param name="sender">The source of the event, typically the "Book List" button.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    private void btnBookList_Click(object sender, EventArgs e)
    {
        BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();
        bookListForm.Show();
        this.Hide();
    }

    /// <summary>
    /// Handles the click event for the "Reviews" button, opening the Reviews form.
    /// </summary>
    /// <param name="sender">The source of the event, typically the "Reviews" button.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    private void btnReviews_Click(object sender, EventArgs e)
    {
        Reviews reviewsForm = Program.AppServices.GetRequiredService<Reviews>();
        reviewsForm.Show();
        this.Hide();
    }

    /// <summary>
    /// Loads the information of the currently selected book and updates the corresponding UI labels.
    /// </summary>
    /// <remarks>If no book is selected, default placeholder values are displayed for each label.</remarks>
    private void LoadBookInfo()
    {
        lblBookTitle.Text = _selectedBook?.Title ?? "Book Title";
        lblAuthor.Text = "Author: " + (_selectedBook?.Author ?? "Author");
        lblISBN.Text = "ISBN: " + (_selectedBook?.ISBN ?? "ISBN");
        lblDescription.Text = _selectedBook?.Description ?? "Description";
    }

    /// <summary>
    /// Populates the discussion panel with a list of discussions related to the currently selected book.
    /// </summary>
    /// <remarks>This method retrieves all discussions associated with the selected book, orders them by their
    /// posting time,  and dynamically creates UI elements to display each discussion. Each discussion is displayed in a
    /// <see cref="GroupBox"/> containing the comment, the username of the poster, and the timestamp of the post. 
    /// Clicking on a discussion highlights it and triggers the selection logic.</remarks>
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

    /// <summary>
    /// Handles the click event of the Submit button, validating the input and adding a new discussion post.
    /// </summary>
    /// <remarks>This method validates that the discussion post text is not empty or whitespace. If the
    /// validation passes, it creates a new discussion entry associated with the selected book and the current user,
    /// adds it to the repository, clears the input field, and refreshes the discussion panel to display the updated
    /// list of posts.</remarks>
    /// <param name="sender">The source of the event, typically the Submit button.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
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

    /// <summary>
    /// Selects the specified discussion group box and updates the current selection state.
    /// </summary>
    /// <remarks>This method updates the visual state of the selected group box and enables related action
    /// buttons. If the current user is not the owner of the specified discussion, the selection is ignored.</remarks>
    /// <param name="groupBox">The <see cref="GroupBox"/> representing the discussion to be selected.</param>
    /// <param name="discussion">The <see cref="Discussion"/> object associated with the group box.</param>
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

    /// <summary>
    /// Enables the buttons for editing and deleting posts.
    /// </summary>
    /// <remarks>This method sets the <see cref="Button.Enabled"/> property of the edit and delete post
    /// buttons to <see langword="true"/>,  allowing user interaction with these buttons.</remarks>
    private void EnablePostActionButtons()
    {
        btnEditPost.Enabled = true;
        btnDeletePost.Enabled = true;
    }

    /// <summary>
    /// Disables the post action buttons, preventing the user from editing or deleting a post.
    /// </summary>
    /// <remarks>This method sets the <see cref="Control.Enabled"/> property of the post action buttons     
    /// to <see langword="false"/>, making them unclickable.</remarks>
    private void DisablePostActionButtons()
    {
        btnEditPost.Enabled = false;
        btnDeletePost.Enabled = false;
    }

    /// <summary>
    /// Handles the click event for the "Edit Post" button, allowing the user to edit the currently selected discussion.
    /// </summary>
    /// <remarks>This method sets the current discussion context to the selected discussion and opens the edit
    /// discussion form. The current form is hidden while the edit discussion form is displayed.</remarks>
    /// <param name="sender">The source of the event, typically the "Edit Post" button.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    private void btnEditPost_Click(object sender, EventArgs e)
    {
        var discussionContext = Program.AppServices.GetRequiredService<DiscussionContext>();
        discussionContext.CurrentDiscussion = _selectedDiscussion;

        EditDiscussion editDiscussionForm = Program.AppServices.GetRequiredService<EditDiscussion>();
        editDiscussionForm.Show();
        this.Hide();
    }

    /// <summary>
    /// Handles the click event for the "Delete Post" button, prompting the user for confirmation  and deleting the
    /// selected discussion if confirmed.
    /// </summary>
    /// <remarks>This method displays a confirmation dialog to the user. If the user confirms the deletion 
    /// and a discussion is selected, the discussion is removed from the repository, the discussion  board is refreshed,
    /// and the selected discussion and related UI elements are cleared.</remarks>
    /// <param name="sender">The source of the event, typically the "Delete Post" button.</param>
    /// <param name="e">The event data associated with the click event.</param>
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
