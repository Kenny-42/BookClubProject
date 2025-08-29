using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookClub.Handlers;

namespace BookClub.Forms
{
    public partial class EditReview : Form
    {
        private StarSystemController starController;
        private int currentRating = 0;

        public EditReview()
        {
            InitializeComponent();
            // Initialize the star rating system using StarSystemController
            starController = new StarSystemController(
                new PictureBox[] { pcbStar1, pcbStar2, pcbStar3, pcbStar4, pcbStar5 },
                Properties.Resources.star_filled,
                Properties.Resources.star_empty
            );
            starController.RatingChanged += (rating) => { currentRating = rating; };
        }
    }
}
