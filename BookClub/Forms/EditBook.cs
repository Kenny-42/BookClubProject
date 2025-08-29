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

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            var currentBook = _bookContext.CurrentBook;

            // Read textbox values
            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string description = txtDescription.Text.Trim();
            string isbn = txtISBN.Text.Trim();

            // Validate inputs


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
