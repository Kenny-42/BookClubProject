namespace BookClub.Forms
{
    partial class EditBook
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
            txtDescription = new TextBox();
            btnSaveChanges = new Button();
            txtISBN = new TextBox();
            txtAuthor = new TextBox();
            txtTitle = new TextBox();
            lblEditBook = new Label();
            btnBookList = new Button();
            btnLogout = new Button();
            lblTitle = new Label();
            lblAuthor = new Label();
            lblISBN = new Label();
            lblDescription = new Label();
            btnDeleteBook = new Button();
            SuspendLayout();
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(216, 234);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Description";
            txtDescription.Size = new Size(350, 100);
            txtDescription.TabIndex = 17;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(310, 346);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(162, 48);
            btnSaveChanges.TabIndex = 16;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(216, 184);
            txtISBN.Name = "txtISBN";
            txtISBN.PlaceholderText = "ISBN";
            txtISBN.Size = new Size(350, 27);
            txtISBN.TabIndex = 15;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(216, 138);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.PlaceholderText = "Author";
            txtAuthor.Size = new Size(350, 27);
            txtAuthor.TabIndex = 14;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(216, 93);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Title";
            txtTitle.Size = new Size(350, 27);
            txtTitle.TabIndex = 13;
            // 
            // lblEditBook
            // 
            lblEditBook.AutoSize = true;
            lblEditBook.Font = new Font("Segoe UI", 20F);
            lblEditBook.Location = new Point(310, 27);
            lblEditBook.Name = "lblEditBook";
            lblEditBook.Size = new Size(162, 46);
            lblEditBook.TabIndex = 12;
            lblEditBook.Text = "Edit Book";
            // 
            // btnBookList
            // 
            btnBookList.Location = new Point(12, 54);
            btnBookList.Name = "btnBookList";
            btnBookList.Size = new Size(130, 36);
            btnBookList.TabIndex = 11;
            btnBookList.Text = "Book List";
            btnBookList.UseVisualStyleBackColor = true;
            btnBookList.Click += btnBookList_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(130, 36);
            btnLogout.TabIndex = 10;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(169, 96);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(41, 20);
            lblTitle.TabIndex = 18;
            lblTitle.Text = "Title:";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(153, 141);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(57, 20);
            lblAuthor.TabIndex = 19;
            lblAuthor.Text = "Author:";
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(166, 187);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(44, 20);
            lblISBN.TabIndex = 20;
            lblISBN.Text = "ISBN:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(122, 237);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(88, 20);
            lblDescription.TabIndex = 21;
            lblDescription.Text = "Description:";
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.ForeColor = Color.Firebrick;
            btnDeleteBook.Location = new Point(334, 400);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(118, 29);
            btnDeleteBook.TabIndex = 22;
            btnDeleteBook.Text = "Delete Book";
            btnDeleteBook.UseVisualStyleBackColor = true;
            btnDeleteBook.Click += btnDeleteBook_Click;
            // 
            // EditBook
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteBook);
            Controls.Add(lblDescription);
            Controls.Add(lblISBN);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            Controls.Add(txtDescription);
            Controls.Add(btnSaveChanges);
            Controls.Add(txtISBN);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(lblEditBook);
            Controls.Add(btnBookList);
            Controls.Add(btnLogout);
            Name = "EditBook";
            Text = "Edit Book";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDescription;
        private Button btnSaveChanges;
        private TextBox txtISBN;
        private TextBox txtAuthor;
        private TextBox txtTitle;
        private Label lblEditBook;
        private Button btnBookList;
        private Button btnLogout;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblISBN;
        private Label lblDescription;
        private Button btnDeleteBook;
    }
}