using System;
using System.Windows.Forms;
using System.Drawing;

namespace BookClub.Handlers
{
    public class StarSystemController
    {
        private PictureBox[] _stars;
        private int _currentRating;
        private Image _starFilled;
        private Image _starEmpty;

        public int CurrentRating => _currentRating;

        // Event triggered when the rating changes
        public event Action<int> RatingChanged;

        public StarSystemController(PictureBox[] stars, Image starFilled, Image starEmpty)
        {
            if (stars == null || stars.Length != 5)
                throw new ArgumentException("You must provide exactly 5 PictureBoxes for the star system.");

            _stars = stars;
            _starFilled = starFilled;
            _starEmpty = starEmpty;

            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i].Tag = i + 1;
                _stars[i].Image = _starEmpty;
                _stars[i].Cursor = Cursors.Hand;
                _stars[i].Click += Star_Click;
            }
            _currentRating = 0;
        }

        private void Star_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedStar && clickedStar.Tag is int rating)
            {
                SetRating(rating);
            }
        }

        public void SetRating(int rating)
        {
            if (rating < 0 || rating > 5) return;
            _currentRating = rating;
            UpdateStarImages();
            RatingChanged?.Invoke(_currentRating);
        }

        public void Reset()
        {
            SetRating(0);
        }

        private void UpdateStarImages()
        {
            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i].Image = i < _currentRating ? _starFilled : _starEmpty;
            }
        }
    }
}
