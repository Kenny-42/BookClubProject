namespace BookClub.Forms
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblLogin = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnCreateAccount = new Button();
            buttonResetPassword = new Button();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 20F);
            lblLogin.Location = new Point(294, 7);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(84, 37);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Login";
            lblLogin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(220, 66);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(232, 23);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(220, 111);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(232, 23);
            txtPassword.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(342, 157);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(110, 40);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.Location = new Point(242, 235);
            btnCreateAccount.Margin = new Padding(3, 2, 3, 2);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(200, 38);
            btnCreateAccount.TabIndex = 4;
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.UseVisualStyleBackColor = true;
            btnCreateAccount.Click += btnCreateAccount_Click;
            // 
            // buttonResetPassword
            // 
            buttonResetPassword.Location = new Point(220, 157);
            buttonResetPassword.Margin = new Padding(3, 2, 3, 2);
            buttonResetPassword.Name = "buttonResetPassword";
            buttonResetPassword.Size = new Size(110, 40);
            buttonResetPassword.TabIndex = 5;
            buttonResetPassword.Text = "Reset Password";
            buttonResetPassword.UseVisualStyleBackColor = true;
            buttonResetPassword.Click += buttonResetPassword_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(buttonResetPassword);
            Controls.Add(btnCreateAccount);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblLogin);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLogin;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCreateAccount;
        private Button buttonResetPassword;
    }
}
