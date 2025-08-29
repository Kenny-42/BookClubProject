namespace BookClub.Forms
{
    partial class EditReview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnReviews = new Button();
            btnLogout = new Button();
            pcbStar5 = new PictureBox();
            pcbStar1 = new PictureBox();
            pcbStar4 = new PictureBox();
            pcbStar2 = new PictureBox();
            pcbStar3 = new PictureBox();
            btnSaveChanges = new Button();
            txtReview = new TextBox();
            btnDeleteReview = new Button();
            ((System.ComponentModel.ISupportInitialize)pcbStar5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar3).BeginInit();
            SuspendLayout();
            // 
            // btnReviews
            // 
            btnReviews.Location = new Point(12, 54);
            btnReviews.Name = "btnReviews";
            btnReviews.Size = new Size(130, 36);
            btnReviews.TabIndex = 5;
            btnReviews.Text = "Reviews";
            btnReviews.UseVisualStyleBackColor = true;
            btnReviews.Click += btnReviews_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(130, 36);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // pcbStar5
            // 
            pcbStar5.Location = new Point(448, 280);
            pcbStar5.Name = "pcbStar5";
            pcbStar5.Size = new Size(25, 25);
            pcbStar5.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbStar5.TabIndex = 25;
            pcbStar5.TabStop = false;
            // 
            // pcbStar1
            // 
            pcbStar1.Location = new Point(322, 280);
            pcbStar1.Name = "pcbStar1";
            pcbStar1.Size = new Size(25, 25);
            pcbStar1.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbStar1.TabIndex = 24;
            pcbStar1.TabStop = false;
            // 
            // pcbStar4
            // 
            pcbStar4.Location = new Point(417, 280);
            pcbStar4.Name = "pcbStar4";
            pcbStar4.Size = new Size(25, 25);
            pcbStar4.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbStar4.TabIndex = 23;
            pcbStar4.TabStop = false;
            // 
            // pcbStar2
            // 
            pcbStar2.Location = new Point(355, 280);
            pcbStar2.Name = "pcbStar2";
            pcbStar2.Size = new Size(25, 25);
            pcbStar2.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbStar2.TabIndex = 22;
            pcbStar2.TabStop = false;
            // 
            // pcbStar3
            // 
            pcbStar3.Location = new Point(386, 280);
            pcbStar3.Name = "pcbStar3";
            pcbStar3.Size = new Size(25, 25);
            pcbStar3.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbStar3.TabIndex = 21;
            pcbStar3.TabStop = false;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(309, 322);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(178, 49);
            btnSaveChanges.TabIndex = 20;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // txtReview
            // 
            txtReview.Location = new Point(162, 139);
            txtReview.Multiline = true;
            txtReview.Name = "txtReview";
            txtReview.PlaceholderText = "Review Message";
            txtReview.Size = new Size(485, 122);
            txtReview.TabIndex = 19;
            // 
            // btnDeleteReview
            // 
            btnDeleteReview.ForeColor = Color.Firebrick;
            btnDeleteReview.Location = new Point(322, 386);
            btnDeleteReview.Name = "btnDeleteReview";
            btnDeleteReview.Size = new Size(151, 29);
            btnDeleteReview.TabIndex = 26;
            btnDeleteReview.Text = "Delete Review";
            btnDeleteReview.UseVisualStyleBackColor = true;
            btnDeleteReview.Click += new System.EventHandler(this.btnDeleteReview_Click);
            // 
            // EditReview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteReview);
            Controls.Add(pcbStar5);
            Controls.Add(pcbStar1);
            Controls.Add(pcbStar4);
            Controls.Add(pcbStar2);
            Controls.Add(pcbStar3);
            Controls.Add(btnSaveChanges);
            Controls.Add(txtReview);
            Controls.Add(btnReviews);
            Controls.Add(btnLogout);
            Name = "EditReview";
            Text = "Edit Review";
            ((System.ComponentModel.ISupportInitialize)pcbStar5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReviews;
        private Button btnLogout;
        private PictureBox pcbStar5;
        private PictureBox pcbStar1;
        private PictureBox pcbStar4;
        private PictureBox pcbStar2;
        private PictureBox pcbStar3;
        private Button btnSaveChanges;
        private TextBox txtReview;
        private Button btnDeleteReview;
    }
}