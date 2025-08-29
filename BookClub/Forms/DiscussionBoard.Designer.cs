namespace BookClub.Forms;

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
        btnLogout.Location = new Point(10, 9);
        btnLogout.Margin = new Padding(3, 2, 3, 2);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(114, 27);
        btnLogout.TabIndex = 3;
        btnLogout.Text = "Logout";
        btnLogout.UseVisualStyleBackColor = true;
        btnLogout.Click += btnLogout_Click;
        // 
        // btnReviews
        // 
        btnReviews.Location = new Point(454, 9);
        btnReviews.Margin = new Padding(3, 2, 3, 2);
        btnReviews.Name = "btnReviews";
        btnReviews.Size = new Size(235, 27);
        btnReviews.TabIndex = 5;
        btnReviews.Text = "Back to Reviews";
        btnReviews.UseVisualStyleBackColor = true;
        btnReviews.Click += btnReviews_Click;
        // 
        // btnBookList
        // 
        btnBookList.Location = new Point(10, 40);
        btnBookList.Margin = new Padding(3, 2, 3, 2);
        btnBookList.Name = "btnBookList";
        btnBookList.Size = new Size(114, 27);
        btnBookList.TabIndex = 6;
        btnBookList.Text = "Book List";
        btnBookList.UseVisualStyleBackColor = true;
        btnBookList.Click += btnBookList_Click;
        // 
        // pcbBookThumbnail
        // 
        pcbBookThumbnail.Location = new Point(17, 71);
        pcbBookThumbnail.Margin = new Padding(3, 2, 3, 2);
        pcbBookThumbnail.Name = "pcbBookThumbnail";
        pcbBookThumbnail.Size = new Size(101, 138);
        pcbBookThumbnail.TabIndex = 7;
        pcbBookThumbnail.TabStop = false;
        // 
        // lblISBN
        // 
        lblISBN.AutoSize = true;
        lblISBN.Font = new Font("Segoe UI", 7F);
        lblISBN.Location = new Point(10, 212);
        lblISBN.Name = "lblISBN";
        lblISBN.Size = new Size(26, 12);
        lblISBN.TabIndex = 8;
        lblISBN.Text = "ISBN";
        // 
        // lblAuthor
        // 
        lblAuthor.AutoSize = true;
        lblAuthor.Location = new Point(10, 223);
        lblAuthor.Name = "lblAuthor";
        lblAuthor.Size = new Size(44, 15);
        lblAuthor.TabIndex = 9;
        lblAuthor.Text = "Author";
        // 
        // lblDescription
        // 
        lblDescription.AutoSize = true;
        lblDescription.Font = new Font("Segoe UI", 7F);
        lblDescription.Location = new Point(10, 238);
        lblDescription.MaximumSize = new Size(114, 0);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(80, 12);
        lblDescription.TabIndex = 10;
        lblDescription.Text = "Book Description";
        // 
        // pnlDiscussionBoard
        // 
        pnlDiscussionBoard.AutoScroll = true;
        pnlDiscussionBoard.Location = new Point(152, 71);
        pnlDiscussionBoard.Margin = new Padding(3, 2, 3, 2);
        pnlDiscussionBoard.Name = "pnlDiscussionBoard";
        pnlDiscussionBoard.Size = new Size(514, 138);
        pnlDiscussionBoard.TabIndex = 12;
        // 
        // txtDiscussionPost
        // 
        txtDiscussionPost.Location = new Point(198, 223);
        txtDiscussionPost.Margin = new Padding(3, 2, 3, 2);
        txtDiscussionPost.Multiline = true;
        txtDiscussionPost.Name = "txtDiscussionPost";
        txtDiscussionPost.PlaceholderText = "Discussion Post";
        txtDiscussionPost.Size = new Size(425, 52);
        txtDiscussionPost.TabIndex = 13;
        // 
        // btnSubmit
        // 
        btnSubmit.Location = new Point(354, 293);
        btnSubmit.Margin = new Padding(3, 2, 3, 2);
        btnSubmit.Name = "btnSubmit";
        btnSubmit.Size = new Size(113, 22);
        btnSubmit.TabIndex = 14;
        btnSubmit.Text = "Submit";
        btnSubmit.UseVisualStyleBackColor = true;
        btnSubmit.Click += btnSubmit_Click;
        // 
        // lblBookTitle
        // 
        lblBookTitle.AutoSize = true;
        lblBookTitle.Font = new Font("Segoe UI", 20F);
        lblBookTitle.Location = new Point(152, 9);
        lblBookTitle.Name = "lblBookTitle";
        lblBookTitle.Size = new Size(135, 37);
        lblBookTitle.TabIndex = 15;
        lblBookTitle.Text = "Book Title";
        // 
        // lblDiscussionBoard
        // 
        lblDiscussionBoard.AutoSize = true;
        lblDiscussionBoard.Font = new Font("Segoe UI", 14F);
        lblDiscussionBoard.Location = new Point(155, 45);
        lblDiscussionBoard.Name = "lblDiscussionBoard";
        lblDiscussionBoard.Size = new Size(156, 25);
        lblDiscussionBoard.TabIndex = 16;
        lblDiscussionBoard.Text = "Discussion Board";
        // 
        // DiscussionBoard
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 338);
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
        Margin = new Padding(3, 2, 3, 2);
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