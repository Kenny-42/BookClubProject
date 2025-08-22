namespace BookClub
{
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
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(130, 52);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(650, 12);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(138, 52);
            btnAddBook.TabIndex = 1;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = true;
            // 
            // lblBookList
            // 
            lblBookList.AutoSize = true;
            lblBookList.Font = new Font("Segoe UI", 20F);
            lblBookList.Location = new Point(315, 40);
            lblBookList.Name = "lblBookList";
            lblBookList.Size = new Size(155, 46);
            lblBookList.TabIndex = 2;
            lblBookList.Text = "Book List";
            // 
            // pnlBookList
            // 
            pnlBookList.Location = new Point(129, 121);
            pnlBookList.Name = "pnlBookList";
            pnlBookList.Size = new Size(537, 247);
            pnlBookList.TabIndex = 3;
            // 
            // BookList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlBookList);
            Controls.Add(lblBookList);
            Controls.Add(btnAddBook);
            Controls.Add(btnLogout);
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
    }
}