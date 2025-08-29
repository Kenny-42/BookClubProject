using BookClub.Data;
using BookClub.Models;
using BookClub.Repositories;
using BookClub.Resources;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms;

/// <summary>
/// Represents a form that displays a list of books and provides functionality for managing books and user accounts.
/// </summary>
/// <remarks>The <see cref="BookList"/> form allows users to view a list of books, select a book, and perform
/// various actions  such as editing, deleting, or adding reviews for the selected book. It also provides navigation to
/// other forms  for account management, adding new books, and logging out. The book list is dynamically populated based
/// on the  data retrieved from the <see cref="BookRepository"/>. <para> This form is designed to be the main interface
/// for managing books in the application. It ensures that the  appropriate buttons are enabled or disabled based on the
/// current state, such as whether a book is selected. </para></remarks>
public partial class BookList : Form
{
    /// <summary>
    /// Provides access to book data and operations.
    /// </summary>
    private BookRepository _bookRepo;

    /// <summary>
    /// Represents the currently selected book. This field is nullable and may be null if no book is selected.
    /// </summary>
    /// <remarks>This field is intended for internal use to track the selected book within the application. 
    /// Ensure that the value is properly validated before accessing its properties to avoid null reference
    /// exceptions.</remarks>
    private Book? _selectedBook = null;

    public BookList(BookRepository bookRepo)
    {
        InitializeComponent();
        _bookRepo = bookRepo;

        // Make sure the application exits when this form is closed
        this.FormClosed += (s, args) => Application.Exit();

        // Load and display the list of books
        PopulateBookList();
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        Login loginForm = Program.AppServices.GetRequiredService<Login>();
        loginForm.Show();
        this.Hide();
    }

    private void btnAddBook_Click(object sender, EventArgs e)
    {
        AddBook addBookForm = Program.AppServices.GetRequiredService<AddBook>();
        addBookForm.Show();
        this.Hide();
    }

    private void btnEditAccount_Click(object sender, EventArgs e)
    {
        EditAccount editAccountForm = Program.AppServices.GetRequiredService<EditAccount>();
        editAccountForm.Show();
        this.Hide();
    }

    /// <summary>
    /// Populates the book list panel with buttons representing all available books.
    /// </summary>
    /// <remarks>Each button displays the title and author of a book and is dynamically sized to fit the
    /// panel. Clicking a button selects the corresponding book and enables related action buttons. If no books are
    /// available, the panel remains empty.</remarks>
    private void PopulateBookList()
    {
        // Clear existing controls
        pnlBookList.Controls.Clear();

        // Retrieve all books from the repository
        var books = _bookRepo.GetAll().ToList();

        if (books.Count == 0)
            return;

        // Dynamically create buttons for each book
        int buttonHeight = 50;
        int spacing = 10;

        // Create and adds a button for each book
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
            btn.Tag = book;
            btn.UseCompatibleTextRendering = true;

            // Attach click event handler
            btn.Click += (s, e) =>
            {
                // Set the selected book and enable action buttons
                var clickedBook = (Book)((Button)s).Tag;
                _selectedBook = clickedBook;

                EnableBookActionButtons();
            };

            pnlBookList.Controls.Add(btn);
        }
    }

    private void btnEditBook_Click(object sender, EventArgs e)
    {
        // Navigate to EditBook form with the selected book
        EditBook editBookForm = Program.AppServices.GetRequiredService<EditBook>();
        editBookForm.Show();
        this.Hide();
    }

    private void btnDeleteBook_Click(object sender, EventArgs e)
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
            _bookRepo.Delete(_selectedBook!.Id);

            // Refresh the book list
            pnlBookList.Controls.Clear();
            PopulateBookList();

            // Disable action buttons and clear selected book
            _selectedBook = null;
            DisableBookActionButtons();
        }
    }

    private void btnReviews_Click(object sender, EventArgs e)
    {
        // Set the current book in BookContext
        var bookContext = Program.AppServices.GetRequiredService<BookContext>();
        bookContext.CurrentBook = _selectedBook!;

        // Open the Reviews form
        Reviews reviewsForm = Program.AppServices.GetRequiredService<Reviews>();
        reviewsForm.Show();
        this.Hide();
    }

    /// <summary>
    /// Enables the action buttons related to book operations, allowing the user to edit, delete, or add a review for a
    /// book.
    /// </summary>
    /// <remarks>This method sets the Enabled property of the relevant buttons to <see langword="true"/>,
    /// making them interactive. Ensure that this method is called only when the buttons should be available for user
    /// interaction.</remarks>
    private void EnableBookActionButtons()
    {
        btnEditBook.Enabled = true;
        btnDeleteBook.Enabled = true;
        btnViewReviews.Enabled = true;
    }

    /// <summary>
    /// Disables the action buttons related to book operations, preventing user interaction.
    /// </summary>
    /// <remarks>This method sets the Enabled property of the buttons for editing, deleting, and adding
    /// reviews to <see langword="false"/>, making them non-interactive.</remarks>
    private void DisableBookActionButtons()
    {
        btnEditBook.Enabled = false;
        btnDeleteBook.Enabled = false;
        btnViewReviews.Enabled = false;
    }
}
