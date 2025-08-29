using BookClub.Models;
using BookClub.Repositories;
using BookClub.Resources;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace BookClub.Forms
{
    public partial class EditBook : Form
    {
        private readonly BookRepository _repo;
        private readonly BookContext _bookContext;
        public EditBook(BookRepository repo, BookContext bookContext)
        {
            InitializeComponent();
            _repo = repo;
            _bookContext = bookContext;

            PopulateTextboxes(this, _bookContext.CurrentBook);
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

        private bool ValidateInputs(string description, string isbn, out string error)
        {
            error = string.Empty;

            // Only validate non-blank fields
            // No validation needed for title or author since their only requirement is to be non-blank

            // Description cannot be longer than 1024 characters
            if (!string.IsNullOrEmpty(description))
            {
                if (description.Length > 1024)
                {
                    error = "Description cannot be longer than 1024 characters.";
                    return false;
                }
            }
            if (!string.IsNullOrEmpty(isbn))
            {
                string isbnNoHyphens = isbn.Replace("-", "");
                if (isbnNoHyphens.Length != 13)
                {
                    error = "ISBN must be exactly 13 characters long (excluding hyphens).\n";
                }
            }
            return true;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            var currentBook = _bookContext.CurrentBook;

            // Read textbox values
            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string description = txtDescription.Text.Trim();
            string isbn = txtISBN.Text.Trim();

            // Validate inputs
            string error;
            if (!ValidateInputs(description, isbn, out error))
            {
                MessageBox.Show(error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PopulateTextboxes(this, currentBook);
                return;
            }

            // Only update fields that are not blank and different from current value
            var dto = new BookUpdateDTO();
            if (!string.IsNullOrEmpty(title) && title != currentBook.Title)
            {
                dto.Title = title;
            }
            if (!string.IsNullOrEmpty(author) && author != currentBook.Author)
            {
                dto.Author = author;
            }
            if (!string.IsNullOrEmpty(description) && description != currentBook.Description)
            {
                dto.Description = description;
            }
            if (!string.IsNullOrEmpty(isbn) && isbn != currentBook.ISBN)
            {
                dto.ISBN = isbn;
            }

            bool updated = _repo.Update(currentBook.Id, dto);
            if (updated)
            {
                // Update the UserContext with new values
                if (dto.Title != null) currentBook.Title = dto.Title;
                if (dto.Author != null) currentBook.Author = dto.Author;
                if (dto.Description != null) currentBook.Description = dto.Description;
                if (dto.ISBN != null) currentBook.ISBN = dto.ISBN;
                MessageBox.Show("Book updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No changes to book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Repopulate textboxes with updated values
            PopulateTextboxes(this, currentBook);
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            var currentBook = _bookContext.CurrentBook;
            if (currentBook == null)
            {
                MessageBox.Show("No book selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = MessageBox.Show("Are you sure you want to delete this book? This action cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                String title = currentBook.Title;
                bool deleted = _repo.Delete(currentBook.Id);
                if (deleted)
                {
                    MessageBox.Show("The book: \"" + title + "\" has been deleted.", "Book Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _bookContext.CurrentBook = null;
                    BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();
                    bookListForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to delete book. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void PopulateTextboxes(EditBook form, Book book)
        {
            form.txtTitle.Text = "";
            form.txtAuthor.Text = "";
            form.txtDescription.Text = "";
            form.txtISBN.Text = "";

            form.txtTitle.PlaceholderText = book.Title;
            form.txtAuthor.PlaceholderText = book.Author;
            form.txtDescription.PlaceholderText = book.Description;
            form.txtISBN.PlaceholderText = book.ISBN;
        }
    }
}
