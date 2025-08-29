namespace BookClub.Forms
{
    partial class EditAccount
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
            lblEditAccount = new Label();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblUsername = new Label();
            lblEmail = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtUsername = new TextBox();
            txtEmail = new TextBox();
            btnSaveChanges = new Button();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnDeleteAccount = new Button();
            SuspendLayout();
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
            // btnBookList
            // 
            btnBookList.Location = new Point(12, 54);
            btnBookList.Name = "btnBookList";
            btnBookList.Size = new Size(130, 36);
            btnBookList.TabIndex = 5;
            btnBookList.Text = "Book List";
            btnBookList.UseVisualStyleBackColor = true;
            btnBookList.Click += btnBookList_Click;
            // 
            // lblEditAccount
            // 
            lblEditAccount.AutoSize = true;
            lblEditAccount.Font = new Font("Segoe UI", 20F);
            lblEditAccount.Location = new Point(296, 30);
            lblEditAccount.Name = "lblEditAccount";
            lblEditAccount.Size = new Size(210, 46);
            lblEditAccount.TabIndex = 6;
            lblEditAccount.Text = "Edit Account";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(170, 114);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(83, 20);
            lblFirstName.TabIndex = 7;
            lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(171, 147);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(82, 20);
            lblLastName.TabIndex = 8;
            lblLastName.Text = "Last Name:";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(175, 213);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(78, 20);
            lblUsername.TabIndex = 9;
            lblUsername.Text = "Username:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(204, 180);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Email:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(259, 111);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(329, 27);
            txtFirstName.TabIndex = 11;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(259, 144);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(329, 27);
            txtLastName.TabIndex = 12;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(259, 210);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(329, 27);
            txtUsername.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(259, 177);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(329, 27);
            txtEmail.TabIndex = 14;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Font = new Font("Segoe UI", 13F);
            btnSaveChanges.Location = new Point(275, 321);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(254, 52);
            btnSaveChanges.TabIndex = 16;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(180, 246);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 17;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(259, 243);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(329, 27);
            txtPassword.TabIndex = 18;
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.ForeColor = Color.Firebrick;
            btnDeleteAccount.Location = new Point(324, 389);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.Size = new Size(147, 29);
            btnDeleteAccount.TabIndex = 19;
            btnDeleteAccount.Text = "Delete Account";
            btnDeleteAccount.UseVisualStyleBackColor = true;
            btnDeleteAccount.Click += btnDeleteAccount_Click;
            // 
            // EditAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteAccount);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(btnSaveChanges);
            Controls.Add(txtEmail);
            Controls.Add(txtUsername);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblEmail);
            Controls.Add(lblUsername);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(lblEditAccount);
            Controls.Add(btnBookList);
            Controls.Add(btnLogout);
            Name = "EditAccount";
            Text = "Edit Account";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogout;
        private Button btnBookList;
        private Label lblEditAccount;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblUsername;
        private Label lblEmail;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtUsername;
        private TextBox txtEmail;
        private Button btnSaveChanges;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnDeleteAccount;
    }
}