using BookClub.Common;
using BookClub.Controllers;
using BookClub.Models;
using System.ComponentModel;

namespace BookClub.Views;

public class LoginView : UserControl, IView
{
    private LoginController _controller;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IController Controller
    {
        get => _controller;
        set => _controller = (LoginController)value;
    }
    public LoginView()
    {
        InitializeComponent();
        buttonLogin.Click += OnLoginClicked;
        buttonRegister.Click += OnRegisterClicked;
        buttonForgotPassword.Click += OnForgotPasswordClicked;
    }

    private void OnLoginClicked(object? sender, EventArgs e)
    {
        AccountLogin loginAttempt = new AccountLogin
        {
            UsernameEmail = textBoxUsernameEmail.Text,
            Password = textBoxPassword.Text
        };
        var result = _controller.TryLogin(loginAttempt);

        if (result != null)
        {
            MessageBox.Show("Login successful!");
        }
        else
        {
            MessageBox.Show("Login Failed");
        }
    }

    private void OnRegisterClicked(object? sender, EventArgs e)
    {
        _controller.Register();
    }

    private void OnForgotPasswordClicked(object? sender, EventArgs e)
    {
        _controller.ForgotPassword();
    }

    public void OnNavigateTo() { }
    public void OnNavigateFrom()
    {
        // Clearing all fields when navigating away
        textBoxUsernameEmail.Clear();
        textBoxPassword.Clear();
    }

    public Control GetControl() => this;
    public const string ViewKey = "LoginView";

    private void InitializeComponent()
    {
        tableLayoutMain = new TableLayoutPanel();
        tableLayoutItems = new TableLayoutPanel();
        flowLayoutPassword = new FlowLayoutPanel();
        labelPassword = new Label();
        textBoxPassword = new TextBox();
        flowLayoutUsernameEmail = new FlowLayoutPanel();
        labelUsernameEmail = new Label();
        textBoxUsernameEmail = new TextBox();
        labelTitle = new Label();
        tableLayoutButtons = new TableLayoutPanel();
        buttonLogin = new Button();
        tableLayoutButtons2 = new TableLayoutPanel();
        buttonForgotPassword = new Button();
        buttonRegister = new Button();
        tableLayoutMain.SuspendLayout();
        tableLayoutItems.SuspendLayout();
        flowLayoutPassword.SuspendLayout();
        flowLayoutUsernameEmail.SuspendLayout();
        tableLayoutButtons.SuspendLayout();
        tableLayoutButtons2.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutMain
        // 
        tableLayoutMain.ColumnCount = 3;
        tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutMain.Controls.Add(tableLayoutItems, 1, 1);
        tableLayoutMain.Dock = DockStyle.Fill;
        tableLayoutMain.Location = new Point(0, 0);
        tableLayoutMain.Margin = new Padding(0);
        tableLayoutMain.Name = "tableLayoutMain";
        tableLayoutMain.RowCount = 3;
        tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
        tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutMain.Size = new Size(900, 600);
        tableLayoutMain.TabIndex = 0;
        // 
        // tableLayoutItems
        // 
        tableLayoutItems.ColumnCount = 1;
        tableLayoutItems.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutItems.Controls.Add(flowLayoutPassword, 0, 2);
        tableLayoutItems.Controls.Add(flowLayoutUsernameEmail, 0, 1);
        tableLayoutItems.Controls.Add(labelTitle, 0, 0);
        tableLayoutItems.Controls.Add(tableLayoutButtons, 0, 3);
        tableLayoutItems.Dock = DockStyle.Fill;
        tableLayoutItems.Location = new Point(225, 60);
        tableLayoutItems.Margin = new Padding(0);
        tableLayoutItems.Name = "tableLayoutItems";
        tableLayoutItems.RowCount = 4;
        tableLayoutItems.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutItems.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutItems.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutItems.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutItems.Size = new Size(450, 480);
        tableLayoutItems.TabIndex = 0;
        // 
        // flowLayoutPassword
        // 
        flowLayoutPassword.Controls.Add(labelPassword);
        flowLayoutPassword.Controls.Add(textBoxPassword);
        flowLayoutPassword.Dock = DockStyle.Fill;
        flowLayoutPassword.FlowDirection = FlowDirection.TopDown;
        flowLayoutPassword.Location = new Point(0, 240);
        flowLayoutPassword.Margin = new Padding(0);
        flowLayoutPassword.Name = "flowLayoutPassword";
        flowLayoutPassword.Size = new Size(450, 120);
        flowLayoutPassword.TabIndex = 2;
        // 
        // labelPassword
        // 
        labelPassword.AutoSize = true;
        labelPassword.Location = new Point(3, 0);
        labelPassword.Name = "labelPassword";
        labelPassword.Size = new Size(57, 15);
        labelPassword.TabIndex = 0;
        labelPassword.Text = "Password";
        // 
        // textBoxPassword
        // 
        textBoxPassword.Location = new Point(3, 18);
        textBoxPassword.Name = "textBoxPassword";
        textBoxPassword.Size = new Size(435, 23);
        textBoxPassword.TabIndex = 1;
        // 
        // flowLayoutUsernameEmail
        // 
        flowLayoutUsernameEmail.Controls.Add(labelUsernameEmail);
        flowLayoutUsernameEmail.Controls.Add(textBoxUsernameEmail);
        flowLayoutUsernameEmail.Dock = DockStyle.Fill;
        flowLayoutUsernameEmail.FlowDirection = FlowDirection.TopDown;
        flowLayoutUsernameEmail.Location = new Point(0, 120);
        flowLayoutUsernameEmail.Margin = new Padding(0);
        flowLayoutUsernameEmail.Name = "flowLayoutUsernameEmail";
        flowLayoutUsernameEmail.Size = new Size(450, 120);
        flowLayoutUsernameEmail.TabIndex = 0;
        // 
        // labelUsernameEmail
        // 
        labelUsernameEmail.AutoSize = true;
        labelUsernameEmail.Location = new Point(3, 0);
        labelUsernameEmail.Name = "labelUsernameEmail";
        labelUsernameEmail.Size = new Size(94, 15);
        labelUsernameEmail.TabIndex = 0;
        labelUsernameEmail.Text = "Username/Email";
        // 
        // textBoxUsernameEmail
        // 
        textBoxUsernameEmail.Location = new Point(3, 18);
        textBoxUsernameEmail.Name = "textBoxUsernameEmail";
        textBoxUsernameEmail.Size = new Size(435, 23);
        textBoxUsernameEmail.TabIndex = 1;
        // 
        // labelTitle
        // 
        labelTitle.AutoSize = true;
        labelTitle.Dock = DockStyle.Fill;
        labelTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        labelTitle.Location = new Point(0, 0);
        labelTitle.Margin = new Padding(0, 0, 3, 0);
        labelTitle.Name = "labelTitle";
        labelTitle.Size = new Size(447, 120);
        labelTitle.TabIndex = 1;
        labelTitle.Text = "Virtual Book Club";
        labelTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // tableLayoutButtons
        // 
        tableLayoutButtons.ColumnCount = 1;
        tableLayoutButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutButtons.Controls.Add(buttonLogin, 0, 0);
        tableLayoutButtons.Controls.Add(tableLayoutButtons2, 0, 1);
        tableLayoutButtons.Dock = DockStyle.Fill;
        tableLayoutButtons.Location = new Point(0, 360);
        tableLayoutButtons.Margin = new Padding(0);
        tableLayoutButtons.Name = "tableLayoutButtons";
        tableLayoutButtons.RowCount = 2;
        tableLayoutButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutButtons.Size = new Size(450, 120);
        tableLayoutButtons.TabIndex = 3;
        // 
        // buttonLogin
        // 
        buttonLogin.Dock = DockStyle.Fill;
        buttonLogin.Location = new Point(10, 10);
        buttonLogin.Margin = new Padding(10);
        buttonLogin.Name = "buttonLogin";
        buttonLogin.Size = new Size(430, 40);
        buttonLogin.TabIndex = 1;
        buttonLogin.Text = "Login";
        buttonLogin.UseVisualStyleBackColor = true;
        // 
        // tableLayoutButtons2
        // 
        tableLayoutButtons2.ColumnCount = 2;
        tableLayoutButtons2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutButtons2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutButtons2.Controls.Add(buttonForgotPassword, 1, 0);
        tableLayoutButtons2.Controls.Add(buttonRegister, 0, 0);
        tableLayoutButtons2.Dock = DockStyle.Fill;
        tableLayoutButtons2.Location = new Point(0, 60);
        tableLayoutButtons2.Margin = new Padding(0);
        tableLayoutButtons2.Name = "tableLayoutButtons2";
        tableLayoutButtons2.RowCount = 1;
        tableLayoutButtons2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutButtons2.Size = new Size(450, 60);
        tableLayoutButtons2.TabIndex = 0;
        // 
        // buttonForgotPassword
        // 
        buttonForgotPassword.Dock = DockStyle.Fill;
        buttonForgotPassword.Location = new Point(235, 10);
        buttonForgotPassword.Margin = new Padding(10);
        buttonForgotPassword.Name = "buttonForgotPassword";
        buttonForgotPassword.Size = new Size(205, 40);
        buttonForgotPassword.TabIndex = 1;
        buttonForgotPassword.Text = "Forgot Password";
        buttonForgotPassword.UseVisualStyleBackColor = true;
        // 
        // buttonRegister
        // 
        buttonRegister.Dock = DockStyle.Fill;
        buttonRegister.Location = new Point(10, 10);
        buttonRegister.Margin = new Padding(10);
        buttonRegister.Name = "buttonRegister";
        buttonRegister.Size = new Size(205, 40);
        buttonRegister.TabIndex = 0;
        buttonRegister.Text = "Register";
        buttonRegister.UseVisualStyleBackColor = true;
        // 
        // LoginView
        // 
        BackColor = SystemColors.Control;
        Controls.Add(tableLayoutMain);
        Name = "LoginView";
        Size = new Size(900, 600);
        tableLayoutMain.ResumeLayout(false);
        tableLayoutItems.ResumeLayout(false);
        tableLayoutItems.PerformLayout();
        flowLayoutPassword.ResumeLayout(false);
        flowLayoutPassword.PerformLayout();
        flowLayoutUsernameEmail.ResumeLayout(false);
        flowLayoutUsernameEmail.PerformLayout();
        tableLayoutButtons.ResumeLayout(false);
        tableLayoutButtons2.ResumeLayout(false);
        ResumeLayout(false);

    }

    private TableLayoutPanel tableLayoutMain;
    private TableLayoutPanel tableLayoutItems;
    private FlowLayoutPanel flowLayoutUsernameEmail;
    private Label labelUsernameEmail;
    private TextBox textBoxUsernameEmail;
    private Label labelTitle;
    private FlowLayoutPanel flowLayoutPassword;
    private Label labelPassword;
    private TextBox textBoxPassword;
    private TableLayoutPanel tableLayoutButtons;
    private Button buttonLogin;
    private TableLayoutPanel tableLayoutButtons2;
    private Button buttonForgotPassword;
    private Button buttonRegister;
}
