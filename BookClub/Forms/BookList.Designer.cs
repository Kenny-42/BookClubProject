namespace BookClub.Forms;

partial class BookList
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
        btnAddBook = new Button();
        lblBookList = new Label();
        pnlBookList = new Panel();
        btnEditAccount = new Button();
        btnDeleteBook = new Button();
        btnEditBook = new Button();
        btnViewReviews = new Button();
        SuspendLayout();
        // 
        // btnLogout
        // 
        btnLogout.Location = new Point(10, 9);
        btnLogout.Margin = new Padding(3, 2, 3, 2);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(114, 27);
        btnLogout.TabIndex = 0;
        btnLogout.Text = "Logout";
        btnLogout.UseVisualStyleBackColor = true;
        btnLogout.Click += btnLogout_Click;
        // 
        // btnAddBook
        // 
        btnAddBook.Location = new Point(113, 288);
        btnAddBook.Margin = new Padding(3, 2, 3, 2);
        btnAddBook.Name = "btnAddBook";
        btnAddBook.Size = new Size(110, 39);
        btnAddBook.TabIndex = 2;
        btnAddBook.Text = "Add Book";
        btnAddBook.UseVisualStyleBackColor = true;
        btnAddBook.Click += btnAddBook_Click;
        // 
        // lblBookList
        // 
        lblBookList.AutoSize = true;
        lblBookList.Font = new Font("Segoe UI", 20F);
        lblBookList.Location = new Point(276, 30);
        lblBookList.Name = "lblBookList";
        lblBookList.Size = new Size(124, 37);
        lblBookList.TabIndex = 2;
        lblBookList.Text = "Book List";
        // 
        // pnlBookList
        // 
        pnlBookList.AutoScroll = true;
        pnlBookList.Location = new Point(113, 91);
        pnlBookList.Margin = new Padding(3, 2, 3, 2);
        pnlBookList.Name = "pnlBookList";
        pnlBookList.Size = new Size(470, 185);
        pnlBookList.TabIndex = 6;
        // 
        // btnEditAccount
        // 
        btnEditAccount.Location = new Point(10, 40);
        btnEditAccount.Margin = new Padding(3, 2, 3, 2);
        btnEditAccount.Name = "btnEditAccount";
        btnEditAccount.Size = new Size(114, 27);
        btnEditAccount.TabIndex = 1;
        btnEditAccount.Text = "Edit Account";
        btnEditAccount.UseVisualStyleBackColor = true;
        btnEditAccount.Click += btnEditAccount_Click;
        // 
        // btnDeleteBook
        // 
        btnDeleteBook.Enabled = false;
        btnDeleteBook.Location = new Point(353, 288);
        btnDeleteBook.Margin = new Padding(3, 2, 3, 2);
        btnDeleteBook.Name = "btnDeleteBook";
        btnDeleteBook.Size = new Size(110, 39);
        btnDeleteBook.TabIndex = 4;
        btnDeleteBook.Text = "Delete Book";
        btnDeleteBook.UseVisualStyleBackColor = true;
        btnDeleteBook.Click += btnDeleteBook_Click;
        // 
        // btnEditBook
        // 
        btnEditBook.Enabled = false;
        btnEditBook.Location = new Point(233, 288);
        btnEditBook.Margin = new Padding(3, 2, 3, 2);
        btnEditBook.Name = "btnEditBook";
        btnEditBook.Size = new Size(110, 39);
        btnEditBook.TabIndex = 3;
        btnEditBook.Text = "Edit Book";
        btnEditBook.UseVisualStyleBackColor = true;
        btnEditBook.Click += btnEditBook_Click;
        // 
        // btnViewReviews
        // 
        btnViewReviews.Enabled = false;
        btnViewReviews.Location = new Point(473, 288);
        btnViewReviews.Margin = new Padding(3, 2, 3, 2);
        btnViewReviews.Name = "btnViewReviews";
        btnViewReviews.Size = new Size(110, 39);
        btnViewReviews.TabIndex = 5;
        btnViewReviews.Text = "View Reviews";
        btnViewReviews.UseVisualStyleBackColor = true;
        btnViewReviews.Click += btnReviews_Click;
        // 
        // BookList
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 338);
        Controls.Add(btnViewReviews);
        Controls.Add(btnDeleteBook);
        Controls.Add(btnEditBook);
        Controls.Add(btnEditAccount);
        Controls.Add(pnlBookList);
        Controls.Add(lblBookList);
        Controls.Add(btnAddBook);
        Controls.Add(btnLogout);
        Margin = new Padding(3, 2, 3, 2);
        Name = "BookList";
        Text = "Book List";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnLogout;
    private Button btnAddBook;
    private Label lblBookList;
    private Panel pnlBookList;
    private Button btnEditAccount;
    private Button btnDeleteBook;
    private Button btnEditBook;
    private Button btnViewReviews;
}