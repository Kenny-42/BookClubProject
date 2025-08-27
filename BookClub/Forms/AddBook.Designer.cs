namespace BookClub
{
    partial class AddBook
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
            lblAddBook = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtISBN = new TextBox();
            btnSubmit = new Button();
            txtDescription = new TextBox();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(130, 36);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnBookList
            // 
            btnBookList.Location = new Point(12, 54);
            btnBookList.Name = "btnBookList";
            btnBookList.Size = new Size(130, 36);
            btnBookList.TabIndex = 2;
            btnBookList.Text = "Book List";
            btnBookList.UseVisualStyleBackColor = true;
            btnBookList.Click += btnBookList_Click;
            // 
            // lblAddBook
            // 
            lblAddBook.AutoSize = true;
            lblAddBook.Font = new Font("Segoe UI", 20F);
            lblAddBook.Location = new Point(312, 27);
            lblAddBook.Name = "lblAddBook";
            lblAddBook.Size = new Size(167, 46);
            lblAddBook.TabIndex = 3;
            lblAddBook.Text = "Add Book";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(218, 93);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Title";
            txtTitle.Size = new Size(350, 27);
            txtTitle.TabIndex = 4;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(218, 138);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.PlaceholderText = "Author";
            txtAuthor.Size = new Size(350, 27);
            txtAuthor.TabIndex = 5;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(218, 184);
            txtISBN.Name = "txtISBN";
            txtISBN.PlaceholderText = "ISBN";
            txtISBN.Size = new Size(350, 27);
            txtISBN.TabIndex = 6;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(321, 361);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(148, 48);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(218, 234);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Description";
            txtDescription.Size = new Size(350, 100);
            txtDescription.TabIndex = 9;
            // 
            // AddBook
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtDescription);
            Controls.Add(btnSubmit);
            Controls.Add(txtISBN);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(lblAddBook);
            Controls.Add(btnBookList);
            Controls.Add(btnLogout);
            Name = "AddBook";
            Text = "AddBook";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogout;
        private Button btnBookList;
        private Label lblAddBook;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtISBN;
        private Button btnSubmit;
        private TextBox txtDescription;
    }
}