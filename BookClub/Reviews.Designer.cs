namespace BookClub
{
    partial class Reviews
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
            btnLogout = new Button();
            btnBookList = new Button();
            btnOpenDiscussionBoard = new Button();
            pcbBookThumbnail = new PictureBox();
            lblISBN = new Label();
            lblAuthor = new Label();
            lblDescription = new Label();
            lblBookTitle = new Label();
            lblReviews = new Label();
            pnlReviewBoard = new Panel();
            txtReview = new TextBox();
            btnSubmit = new Button();
            pcbStar3 = new PictureBox();
            pcbStar2 = new PictureBox();
            pcbStar4 = new PictureBox();
            pcbStar1 = new PictureBox();
            pcbStar5 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pcbBookThumbnail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar5).BeginInit();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(130, 36);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnBookList
            // 
            btnBookList.Location = new Point(12, 54);
            btnBookList.Name = "btnBookList";
            btnBookList.Size = new Size(130, 36);
            btnBookList.TabIndex = 3;
            btnBookList.Text = "Book List";
            btnBookList.UseVisualStyleBackColor = true;
            // 
            // btnOpenDiscussionBoard
            // 
            btnOpenDiscussionBoard.Location = new Point(519, 12);
            btnOpenDiscussionBoard.Name = "btnOpenDiscussionBoard";
            btnOpenDiscussionBoard.Size = new Size(269, 36);
            btnOpenDiscussionBoard.TabIndex = 4;
            btnOpenDiscussionBoard.Text = "Open Discussion Board";
            btnOpenDiscussionBoard.UseVisualStyleBackColor = true;
            // 
            // pcbBookThumbnail
            // 
            pcbBookThumbnail.Location = new Point(19, 96);
            pcbBookThumbnail.Name = "pcbBookThumbnail";
            pcbBookThumbnail.Size = new Size(115, 184);
            pcbBookThumbnail.TabIndex = 5;
            pcbBookThumbnail.TabStop = false;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Font = new Font("Segoe UI", 7F);
            lblISBN.Location = new Point(12, 283);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(32, 15);
            lblISBN.TabIndex = 6;
            lblISBN.Text = "ISBN";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(12, 298);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(54, 20);
            lblAuthor.TabIndex = 7;
            lblAuthor.Text = "Author";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 7F);
            lblDescription.Location = new Point(12, 318);
            lblDescription.MaximumSize = new Size(130, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(97, 15);
            lblDescription.TabIndex = 8;
            lblDescription.Text = "Book Description";
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.Font = new Font("Segoe UI", 20F);
            lblBookTitle.Location = new Point(171, 12);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(169, 46);
            lblBookTitle.TabIndex = 9;
            lblBookTitle.Text = "Book Title";
            // 
            // lblReviews
            // 
            lblReviews.AutoSize = true;
            lblReviews.Font = new Font("Segoe UI", 14F);
            lblReviews.Location = new Point(174, 61);
            lblReviews.Name = "lblReviews";
            lblReviews.Size = new Size(98, 32);
            lblReviews.TabIndex = 10;
            lblReviews.Text = "Reviews";
            // 
            // pnlReviewBoard
            // 
            pnlReviewBoard.AutoScroll = true;
            pnlReviewBoard.Location = new Point(171, 96);
            pnlReviewBoard.Name = "pnlReviewBoard";
            pnlReviewBoard.Size = new Size(588, 184);
            pnlReviewBoard.TabIndex = 11;
            // 
            // txtReview
            // 
            txtReview.Location = new Point(222, 295);
            txtReview.Multiline = true;
            txtReview.Name = "txtReview";
            txtReview.PlaceholderText = "Review Message";
            txtReview.Size = new Size(485, 68);
            txtReview.TabIndex = 12;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(399, 409);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(129, 29);
            btnSubmit.TabIndex = 13;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // pcbStar3
            // 
            pcbStar3.Location = new Point(449, 369);
            pcbStar3.Name = "pcbStar3";
            pcbStar3.Size = new Size(25, 25);
            pcbStar3.TabIndex = 14;
            pcbStar3.TabStop = false;
            // 
            // pcbStar2
            // 
            pcbStar2.Location = new Point(418, 369);
            pcbStar2.Name = "pcbStar2";
            pcbStar2.Size = new Size(25, 25);
            pcbStar2.TabIndex = 15;
            pcbStar2.TabStop = false;
            // 
            // pcbStar4
            // 
            pcbStar4.Location = new Point(480, 369);
            pcbStar4.Name = "pcbStar4";
            pcbStar4.Size = new Size(25, 25);
            pcbStar4.TabIndex = 16;
            pcbStar4.TabStop = false;
            // 
            // pcbStar1
            // 
            pcbStar1.Location = new Point(385, 369);
            pcbStar1.Name = "pcbStar1";
            pcbStar1.Size = new Size(25, 25);
            pcbStar1.TabIndex = 17;
            pcbStar1.TabStop = false;
            // 
            // pcbStar5
            // 
            pcbStar5.Location = new Point(511, 369);
            pcbStar5.Name = "pcbStar5";
            pcbStar5.Size = new Size(25, 25);
            pcbStar5.TabIndex = 18;
            pcbStar5.TabStop = false;
            // 
            // Reviews
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pcbStar5);
            Controls.Add(pcbStar1);
            Controls.Add(pcbStar4);
            Controls.Add(pcbStar2);
            Controls.Add(pcbStar3);
            Controls.Add(btnSubmit);
            Controls.Add(txtReview);
            Controls.Add(pnlReviewBoard);
            Controls.Add(lblReviews);
            Controls.Add(lblBookTitle);
            Controls.Add(lblDescription);
            Controls.Add(lblAuthor);
            Controls.Add(lblISBN);
            Controls.Add(pcbBookThumbnail);
            Controls.Add(btnOpenDiscussionBoard);
            Controls.Add(btnBookList);
            Controls.Add(btnLogout);
            Name = "Reviews";
            Text = "Reviews";
            ((System.ComponentModel.ISupportInitialize)pcbBookThumbnail).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbStar5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogout;
        private Button btnBookList;
        private Button btnOpenDiscussionBoard;
        private PictureBox pcbBookThumbnail;
        private Label lblISBN;
        private Label lblAuthor;
        private Label lblDescription;
        private Label lblBookTitle;
        private Label lblReviews;
        private Panel pnlReviewBoard;
        private TextBox txtReview;
        private Button btnSubmit;
        private PictureBox pcbStar3;
        private PictureBox pcbStar2;
        private PictureBox pcbStar4;
        private PictureBox pcbStar1;
        private PictureBox pcbStar5;
    }
}