using BookClub.Handlers;
using BookClub.Models;
using BookClub.Repositories;
using BookClub.Resources;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace BookClub.Forms
{
    public partial class EditReview : Form
    {
        private readonly ReviewsRepository _reviewsRepo;
        private readonly Review? _selectedReview;
        private StarSystemController starController;
        private int currentRating = 0;

        public EditReview(ReviewsRepository reviewsRepo)
        {
            InitializeComponent();
            _reviewsRepo = reviewsRepo;

            var reviewContext = Program.AppServices.GetRequiredService<ReviewContext>();
            _selectedReview = reviewContext.CurrentReview;

            // Set text to current review comment
            txtReview.Text = _selectedReview.Comment;
            txtReview.PlaceholderText = _selectedReview.Comment;

            // Initialize the star rating system using StarSystemController
            starController = new StarSystemController(
                new PictureBox[] { pcbStar1, pcbStar2, pcbStar3, pcbStar4, pcbStar5 },
                Properties.Resources.star_filled,
                Properties.Resources.star_empty
            );
            starController.SetRating(_selectedReview.Rating);
            starController.RatingChanged += (rating) => { currentRating = rating; };
            currentRating = _selectedReview.Rating;

            this.FormClosed += (s, args) => Application.Exit();
        }

        private bool ValidateInputs(string reviewMessage, int rating, out string error)
        {
            if (string.IsNullOrWhiteSpace(reviewMessage))
            {
                error = "Review message cannot be left blank.";
                return false;
            }
            if (reviewMessage.Length > 1024)
            {
                error = "Review cannot exceed 1024 characters.";
                return false;
            }
            if (rating < 1 || rating > 5)
            {
                error = "Rating must be 1-5.";
                return false;
            }
            error = string.Empty;
            return true;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string reviewMessage = txtReview.Text.Trim();
            int rating = currentRating;

            // Validate inputs
            string error;
            if (!ValidateInputs(reviewMessage, rating, out error))
            {
                MessageBox.Show(error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Always set both fields in the DTO
            var dto = new ReviewUpdateDTO
            {
                Comment = reviewMessage,
                Rating = rating
            };

            // Only update if something actually changed
            bool anyChange = (reviewMessage != _selectedReview.Comment) || (rating != _selectedReview.Rating);

            if (anyChange)
            {
                bool updated = _reviewsRepo.Update(_selectedReview.Id, dto);
                if (updated)
                {
                    MessageBox.Show("Review updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _selectedReview.Comment = reviewMessage;
                    _selectedReview.Rating = rating;
                }
                else
                {
                    MessageBox.Show("Failed to update review in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No changes were made.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Set placeholder text to current review comment
            txtReview.PlaceholderText = _selectedReview.Comment;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var loginForm = Program.AppServices.GetRequiredService<Login>();
            loginForm.Show();
            this.Hide();
        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            var reviewsForm = Program.AppServices.GetRequiredService<Reviews>();
            reviewsForm.Show();
            this.Hide();
        }

        private void btnDeleteReview_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to delete this review? This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (result == DialogResult.Yes)
            {
                bool deleted = _reviewsRepo.Delete(_selectedReview.Id);
                if (deleted)
                {
                    MessageBox.Show("Review deleted successfully.", "Review Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var reviewsForm = Program.AppServices.GetRequiredService<Reviews>();
                    reviewsForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to delete review. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
