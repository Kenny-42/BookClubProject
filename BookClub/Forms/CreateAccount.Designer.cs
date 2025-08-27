
namespace BookClub
{
    partial class CreateAccount
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
            btnLogin = new Button();
            lblCreateAccount = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtUsername = new TextBox();
            btnCreateAccount = new Button();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(12, 12);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(130, 52);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblCreateAccount
            // 
            lblCreateAccount.AutoSize = true;
            lblCreateAccount.Font = new Font("Segoe UI", 20F);
            lblCreateAccount.Location = new Point(276, 37);
            lblCreateAccount.Name = "lblCreateAccount";
            lblCreateAccount.Size = new Size(251, 46);
            lblCreateAccount.TabIndex = 2;
            lblCreateAccount.Text = "Create Account";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(288, 132);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "First Name";
            txtFirstName.Size = new Size(225, 27);
            txtFirstName.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(288, 179);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Last Name";
            txtLastName.Size = new Size(225, 27);
            txtLastName.TabIndex = 4;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(288, 222);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(225, 27);
            txtUsername.TabIndex = 5;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.Location = new Point(318, 323);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(163, 61);
            btnCreateAccount.TabIndex = 6;
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.UseVisualStyleBackColor = true;
            btnCreateAccount.Click += btnCreateAccount_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(288, 272);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(225, 27);
            txtPassword.TabIndex = 7;
            // 
            // CreateAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPassword);
            Controls.Add(btnCreateAccount);
            Controls.Add(txtUsername);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblCreateAccount);
            Controls.Add(btnLogin);
            Name = "CreateAccount";
            Text = "CreateAccount";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label lblCreateAccount;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtUsername;
        private Button btnCreateAccount;
        private TextBox txtPassword;
    }
}