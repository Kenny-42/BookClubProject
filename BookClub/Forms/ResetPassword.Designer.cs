
namespace BookClub.Forms;

partial class ResetPassword
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
        txtEmail = new TextBox();
        txtUsername = new TextBox();
        txtNewPassword = new TextBox();
        btnReset = new Button();
        txtConfirmPassword = new TextBox();
        SuspendLayout();
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(10, 9);
        btnLogin.Margin = new Padding(3, 2, 3, 2);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(114, 39);
        btnLogin.TabIndex = 1;
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;
        // 
        // lblCreateAccount
        // 
        lblCreateAccount.AutoSize = true;
        lblCreateAccount.Font = new Font("Segoe UI", 20F);
        lblCreateAccount.Location = new Point(242, 28);
        lblCreateAccount.Name = "lblCreateAccount";
        lblCreateAccount.Size = new Size(198, 37);
        lblCreateAccount.TabIndex = 2;
        lblCreateAccount.Text = "Reset Password";
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(252, 99);
        txtEmail.Margin = new Padding(3, 2, 3, 2);
        txtEmail.Name = "txtEmail";
        txtEmail.PlaceholderText = "Email";
        txtEmail.Size = new Size(197, 23);
        txtEmail.TabIndex = 3;
        // 
        // txtUsername
        // 
        txtUsername.Location = new Point(252, 134);
        txtUsername.Margin = new Padding(3, 2, 3, 2);
        txtUsername.Name = "txtUsername";
        txtUsername.PlaceholderText = "Username";
        txtUsername.Size = new Size(197, 23);
        txtUsername.TabIndex = 4;
        // 
        // txtNewPassword
        // 
        txtNewPassword.Location = new Point(252, 166);
        txtNewPassword.Margin = new Padding(3, 2, 3, 2);
        txtNewPassword.Name = "txtNewPassword";
        txtNewPassword.PlaceholderText = "New Password";
        txtNewPassword.Size = new Size(197, 23);
        txtNewPassword.TabIndex = 5;
        // 
        // btnReset
        // 
        btnReset.Location = new Point(278, 242);
        btnReset.Margin = new Padding(3, 2, 3, 2);
        btnReset.Name = "btnReset";
        btnReset.Size = new Size(143, 46);
        btnReset.TabIndex = 6;
        btnReset.Text = "Reset";
        btnReset.UseVisualStyleBackColor = true;
        btnReset.Click += btnReset_Click;
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.Location = new Point(252, 204);
        txtConfirmPassword.Margin = new Padding(3, 2, 3, 2);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.PlaceholderText = "Confirm Password";
        txtConfirmPassword.Size = new Size(197, 23);
        txtConfirmPassword.TabIndex = 7;
        // 
        // ResetPassword
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 338);
        Controls.Add(txtConfirmPassword);
        Controls.Add(btnReset);
        Controls.Add(txtNewPassword);
        Controls.Add(txtUsername);
        Controls.Add(txtEmail);
        Controls.Add(lblCreateAccount);
        Controls.Add(btnLogin);
        Margin = new Padding(3, 2, 3, 2);
        Name = "ResetPassword";
        Text = "CreateAccount";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnLogin;
    private Label lblCreateAccount;
    private TextBox txtEmail;
    private TextBox txtUsername;
    private TextBox txtNewPassword;
    private Button btnReset;
    private TextBox txtConfirmPassword;
}