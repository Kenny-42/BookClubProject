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
        private StarSystemController starController;
        private int currentRating = 0;
        private UserContext _userContext;
        private BookContext _bookContext;
        private ReviewsRepository _reviewsRepo;
        private Review _currentReview;

        public EditReview(UserContext userContext, BookContext bookContext, ReviewsRepository reviewsRepo, Review currentReview)
        {
            InitializeComponent();
            _userContext = userContext;
            _bookContext = bookContext;
            _reviewsRepo = reviewsRepo;
            _currentReview = currentReview;

            // Initialize the star rating system using StarSystemController
            starController = new StarSystemController(
                new PictureBox[] { pcbStar1, pcbStar2, pcbStar3, pcbStar4, pcbStar5 },
                Properties.Resources.star_filled,
                Properties.Resources.star_empty
            );
            starController.RatingChanged += (rating) => { currentRating = rating; };

            // Populate fields with current review data
            txtReview.PlaceholderText = _currentReview.Comment;
            starController.SetRating(_currentReview.Rating);
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

            // Only update fields that are not blank and different from current value
            var dto = new ReviewUpdateDTO();
            bool anyChange = false;
            if (!string.IsNullOrEmpty(reviewMessage) && reviewMessage != _currentReview.Comment)
            {
                dto.Comment = reviewMessage;
                anyChange = true;
            }
            if (rating != _currentReview.Rating)
            {
                dto.Rating = rating;
                anyChange = true;
            }

            bool updated = false;
            if (anyChange)
            {
                updated = _reviewsRepo.Update(_currentReview.Id, dto);
            }

            if (updated)
            {
                MessageBox.Show("Review updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _currentReview.Comment = reviewMessage;
                _currentReview.Rating = rating;
            }
            else
            {
                MessageBox.Show("No changes were made.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Set placeholder text to current review comment
            txtReview.PlaceholderText = _currentReview.Comment;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var loginForm = Program.AppServices.GetRequiredService<Login>();
            loginForm.Show();
            this.Hide();
        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            Reviews reviewsForm = Program.AppServices.GetRequiredService<Reviews>();
            reviewsForm.Show();
            this.Hide();
        }
    }
}
