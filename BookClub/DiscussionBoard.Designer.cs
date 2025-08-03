namespace BookClub
{
    partial class DiscussionBoard
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
            btnReviews = new Button();
            btnBookList = new Button();
            pcbBookThumbnail = new PictureBox();
            lblISBN = new Label();
            lblAuthor = new Label();
            lblDescription = new Label();
            pnlDiscussionBoard = new Panel();
            txtDiscussionPost = new TextBox();
            btnSubmit = new Button();
            lblBookTitle = new Label();
            lblDiscussionBoard = new Label();
            ((System.ComponentModel.ISupportInitialize)pcbBookThumbnail).BeginInit();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(130, 36);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnReviews
            // 
            btnReviews.Location = new Point(519, 12);
            btnReviews.Name = "btnReviews";
            btnReviews.Size = new Size(269, 36);
            btnReviews.TabIndex = 5;
            btnReviews.Text = "Back to Reviews";
            btnReviews.UseVisualStyleBackColor = true;
            // 
            // btnBookList
            // 
            btnBookList.Location = new Point(12, 54);
            btnBookList.Name = "btnBookList";
            btnBookList.Size = new Size(130, 36);
            btnBookList.TabIndex = 6;
            btnBookList.Text = "Book List";
            btnBookList.UseVisualStyleBackColor = true;
            // 
            // pcbBookThumbnail
            // 
            pcbBookThumbnail.Location = new Point(19, 95);
            pcbBookThumbnail.Name = "pcbBookThumbnail";
            pcbBookThumbnail.Size = new Size(115, 184);
            pcbBookThumbnail.TabIndex = 7;
            pcbBookThumbnail.TabStop = false;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Font = new Font("Segoe UI", 7F);
            lblISBN.Location = new Point(12, 282);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(32, 15);
            lblISBN.TabIndex = 8;
            lblISBN.Text = "ISBN";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(12, 297);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(54, 20);
            lblAuthor.TabIndex = 9;
            lblAuthor.Text = "Author";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 7F);
            lblDescription.Location = new Point(12, 317);
            lblDescription.MaximumSize = new Size(130, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(97, 15);
            lblDescription.TabIndex = 10;
            lblDescription.Text = "Book Description";
            // 
            // pnlDiscussionBoard
            // 
            pnlDiscussionBoard.Location = new Point(174, 95);
            pnlDiscussionBoard.Name = "pnlDiscussionBoard";
            pnlDiscussionBoard.Size = new Size(588, 184);
            pnlDiscussionBoard.TabIndex = 12;
            // 
            // txtDiscussionPost
            // 
            txtDiscussionPost.Location = new Point(226, 297);
            txtDiscussionPost.Multiline = true;
            txtDiscussionPost.Name = "txtDiscussionPost";
            txtDiscussionPost.PlaceholderText = "Discussion Post";
            txtDiscussionPost.Size = new Size(485, 68);
            txtDiscussionPost.TabIndex = 13;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(405, 391);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(129, 29);
            btnSubmit.TabIndex = 14;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.Font = new Font("Segoe UI", 20F);
            lblBookTitle.Location = new Point(174, 12);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(169, 46);
            lblBookTitle.TabIndex = 15;
            lblBookTitle.Text = "Book Title";
            // 
            // lblDiscussionBoard
            // 
            lblDiscussionBoard.AutoSize = true;
            lblDiscussionBoard.Font = new Font("Segoe UI", 14F);
            lblDiscussionBoard.Location = new Point(177, 60);
            lblDiscussionBoard.Name = "lblDiscussionBoard";
            lblDiscussionBoard.Size = new Size(195, 32);
            lblDiscussionBoard.TabIndex = 16;
            lblDiscussionBoard.Text = "Discussion Board";
            // 
            // DiscussionBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblDiscussionBoard);
            Controls.Add(lblBookTitle);
            Controls.Add(btnSubmit);
            Controls.Add(txtDiscussionPost);
            Controls.Add(pnlDiscussionBoard);
            Controls.Add(lblDescription);
            Controls.Add(lblAuthor);
            Controls.Add(lblISBN);
            Controls.Add(pcbBookThumbnail);
            Controls.Add(btnBookList);
            Controls.Add(btnReviews);
            Controls.Add(btnLogout);
            Name = "DiscussionBoard";
            Text = "Discussion Board";
            ((System.ComponentModel.ISupportInitialize)pcbBookThumbnail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogout;
        private Button btnReviews;
        private Button btnBookList;
        private PictureBox pcbBookThumbnail;
        private Label lblISBN;
        private Label lblAuthor;
        private Label lblDescription;
        private Panel pnlDiscussionBoard;
        private TextBox txtDiscussionPost;
        private Button btnSubmit;
        private Label lblBookTitle;
        private Label lblDiscussionBoard;
    }
}