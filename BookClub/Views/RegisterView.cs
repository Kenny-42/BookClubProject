using BookClub.Common;
using BookClub.Controllers;

namespace BookClub.Views;

public class RegisterView : UserControl, IAppView
{
    private readonly RegisterController _controller;
    public IController Controller => _controller;
    public Control GetControl() => this;
    public RegisterView(RegisterController controller)
    {
        InitializeComponent();
        _controller = controller;
    }

    public void OnNavigateTo(object? parameter = null)
    {
        // Code to execute when navigating to this view
    }
    public void OnNavigateFrom()
    {
        // Code to execute when navigating away from this view
    }

    private async void buttonRegister_Click(object sender, EventArgs e)
    {
        Result result = await _controller.TryRegister(
            textBoxEmail.Text,
            textBoxUsername.Text,
            dateTimePicker1.Value,
            textBoxPassword.Text,
            textBoxConfirmPassword.Text
            );

        if (result.IsFailure)
        {
            MessageBox.Show(result.ErrorMessage, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        _controller.Cancel();
    }

    private TableLayoutPanel tableLayoutMain;
    private TableLayoutPanel tableLayoutLeftItems;
    private FlowLayoutPanel flowLayoutBirthdate;
    private FlowLayoutPanel flowLayoutEmail;
    private FlowLayoutPanel flowLayoutUsername;
    private TableLayoutPanel tableLayoutPanel1;
    private FlowLayoutPanel flowLayoutPassword;
    private FlowLayoutPanel flowLayoutConfirmPassword;
    private Label labelEmail;
    private TextBox textBoxEmail;
    private Label labelBirthdate;
    private DateTimePicker dateTimePicker1;
    private Label labelUsername;
    private TextBox textBoxUsername;
    private Label labelPassword;
    private TextBox textBoxPassword;
    private Label labelConfirmPassword;
    private TextBox textBoxConfirmPassword;
    private TableLayoutPanel tableLayoutPanel2;
    private Button buttonRegister;
    private Button buttonCancel;

    private void InitializeComponent()
    {
        tableLayoutMain = new TableLayoutPanel();
        tableLayoutLeftItems = new TableLayoutPanel();
        flowLayoutBirthdate = new FlowLayoutPanel();
        labelBirthdate = new Label();
        dateTimePicker1 = new DateTimePicker();
        flowLayoutEmail = new FlowLayoutPanel();
        labelEmail = new Label();
        textBoxEmail = new TextBox();
        flowLayoutUsername = new FlowLayoutPanel();
        labelUsername = new Label();
        textBoxUsername = new TextBox();
        tableLayoutPanel1 = new TableLayoutPanel();
        flowLayoutPassword = new FlowLayoutPanel();
        labelPassword = new Label();
        textBoxPassword = new TextBox();
        flowLayoutConfirmPassword = new FlowLayoutPanel();
        labelConfirmPassword = new Label();
        textBoxConfirmPassword = new TextBox();
        tableLayoutPanel2 = new TableLayoutPanel();
        buttonRegister = new Button();
        buttonCancel = new Button();
        tableLayoutMain.SuspendLayout();
        tableLayoutLeftItems.SuspendLayout();
        flowLayoutBirthdate.SuspendLayout();
        flowLayoutEmail.SuspendLayout();
        flowLayoutUsername.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        flowLayoutPassword.SuspendLayout();
        flowLayoutConfirmPassword.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutMain
        // 
        tableLayoutMain.ColumnCount = 4;
        tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tableLayoutMain.Controls.Add(tableLayoutLeftItems, 1, 1);
        tableLayoutMain.Controls.Add(tableLayoutPanel1, 2, 1);
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
        // tableLayoutLeftItems
        // 
        tableLayoutLeftItems.ColumnCount = 1;
        tableLayoutLeftItems.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutLeftItems.Controls.Add(flowLayoutBirthdate, 0, 3);
        tableLayoutLeftItems.Controls.Add(flowLayoutEmail, 0, 1);
        tableLayoutLeftItems.Controls.Add(flowLayoutUsername, 0, 2);
        tableLayoutLeftItems.Dock = DockStyle.Fill;
        tableLayoutLeftItems.Location = new Point(90, 60);
        tableLayoutLeftItems.Margin = new Padding(0);
        tableLayoutLeftItems.Name = "tableLayoutLeftItems";
        tableLayoutLeftItems.RowCount = 4;
        tableLayoutLeftItems.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutLeftItems.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutLeftItems.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutLeftItems.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutLeftItems.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutLeftItems.Size = new Size(360, 480);
        tableLayoutLeftItems.TabIndex = 0;
        // 
        // flowLayoutBirthdate
        // 
        flowLayoutBirthdate.Controls.Add(labelBirthdate);
        flowLayoutBirthdate.Controls.Add(dateTimePicker1);
        flowLayoutBirthdate.Dock = DockStyle.Fill;
        flowLayoutBirthdate.FlowDirection = FlowDirection.TopDown;
        flowLayoutBirthdate.Location = new Point(0, 360);
        flowLayoutBirthdate.Margin = new Padding(0);
        flowLayoutBirthdate.Name = "flowLayoutBirthdate";
        flowLayoutBirthdate.Size = new Size(360, 120);
        flowLayoutBirthdate.TabIndex = 2;
        // 
        // labelBirthdate
        // 
        labelBirthdate.AutoSize = true;
        labelBirthdate.Location = new Point(3, 0);
        labelBirthdate.Name = "labelBirthdate";
        labelBirthdate.Size = new Size(55, 15);
        labelBirthdate.TabIndex = 4;
        labelBirthdate.Text = "Birthdate";
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Location = new Point(3, 18);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.Size = new Size(200, 23);
        dateTimePicker1.TabIndex = 5;
        // 
        // flowLayoutEmail
        // 
        flowLayoutEmail.Controls.Add(labelEmail);
        flowLayoutEmail.Controls.Add(textBoxEmail);
        flowLayoutEmail.Dock = DockStyle.Fill;
        flowLayoutEmail.Location = new Point(0, 120);
        flowLayoutEmail.Margin = new Padding(0);
        flowLayoutEmail.Name = "flowLayoutEmail";
        flowLayoutEmail.Size = new Size(360, 120);
        flowLayoutEmail.TabIndex = 0;
        // 
        // labelEmail
        // 
        labelEmail.AutoSize = true;
        labelEmail.Location = new Point(3, 0);
        labelEmail.Name = "labelEmail";
        labelEmail.Size = new Size(36, 15);
        labelEmail.TabIndex = 2;
        labelEmail.Text = "Email";
        // 
        // textBoxEmail
        // 
        textBoxEmail.Location = new Point(3, 18);
        textBoxEmail.Name = "textBoxEmail";
        textBoxEmail.Size = new Size(354, 23);
        textBoxEmail.TabIndex = 3;
        // 
        // flowLayoutUsername
        // 
        flowLayoutUsername.Controls.Add(labelUsername);
        flowLayoutUsername.Controls.Add(textBoxUsername);
        flowLayoutUsername.Dock = DockStyle.Fill;
        flowLayoutUsername.Location = new Point(0, 240);
        flowLayoutUsername.Margin = new Padding(0);
        flowLayoutUsername.Name = "flowLayoutUsername";
        flowLayoutUsername.Size = new Size(360, 120);
        flowLayoutUsername.TabIndex = 1;
        // 
        // labelUsername
        // 
        labelUsername.AutoSize = true;
        labelUsername.Location = new Point(3, 0);
        labelUsername.Name = "labelUsername";
        labelUsername.Size = new Size(60, 15);
        labelUsername.TabIndex = 4;
        labelUsername.Text = "Username";
        // 
        // textBoxUsername
        // 
        textBoxUsername.Location = new Point(3, 18);
        textBoxUsername.Name = "textBoxUsername";
        textBoxUsername.Size = new Size(354, 23);
        textBoxUsername.TabIndex = 5;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Controls.Add(flowLayoutPassword, 0, 1);
        tableLayoutPanel1.Controls.Add(flowLayoutConfirmPassword, 0, 2);
        tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 3);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(450, 60);
        tableLayoutPanel1.Margin = new Padding(0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 4;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel1.Size = new Size(360, 480);
        tableLayoutPanel1.TabIndex = 1;
        // 
        // flowLayoutPassword
        // 
        flowLayoutPassword.Controls.Add(labelPassword);
        flowLayoutPassword.Controls.Add(textBoxPassword);
        flowLayoutPassword.Dock = DockStyle.Fill;
        flowLayoutPassword.Location = new Point(0, 120);
        flowLayoutPassword.Margin = new Padding(0);
        flowLayoutPassword.Name = "flowLayoutPassword";
        flowLayoutPassword.Size = new Size(360, 120);
        flowLayoutPassword.TabIndex = 2;
        // 
        // labelPassword
        // 
        labelPassword.AutoSize = true;
        labelPassword.Location = new Point(3, 0);
        labelPassword.Name = "labelPassword";
        labelPassword.Size = new Size(57, 15);
        labelPassword.TabIndex = 4;
        labelPassword.Text = "Password";
        // 
        // textBoxPassword
        // 
        textBoxPassword.Location = new Point(3, 18);
        textBoxPassword.Name = "textBoxPassword";
        textBoxPassword.Size = new Size(354, 23);
        textBoxPassword.TabIndex = 5;
        // 
        // flowLayoutConfirmPassword
        // 
        flowLayoutConfirmPassword.Controls.Add(labelConfirmPassword);
        flowLayoutConfirmPassword.Controls.Add(textBoxConfirmPassword);
        flowLayoutConfirmPassword.Dock = DockStyle.Fill;
        flowLayoutConfirmPassword.Location = new Point(0, 240);
        flowLayoutConfirmPassword.Margin = new Padding(0);
        flowLayoutConfirmPassword.Name = "flowLayoutConfirmPassword";
        flowLayoutConfirmPassword.Size = new Size(360, 120);
        flowLayoutConfirmPassword.TabIndex = 3;
        // 
        // labelConfirmPassword
        // 
        labelConfirmPassword.AutoSize = true;
        labelConfirmPassword.Location = new Point(3, 0);
        labelConfirmPassword.Name = "labelConfirmPassword";
        labelConfirmPassword.Size = new Size(104, 15);
        labelConfirmPassword.TabIndex = 4;
        labelConfirmPassword.Text = "Confirm Password";
        // 
        // textBoxConfirmPassword
        // 
        textBoxConfirmPassword.Location = new Point(3, 18);
        textBoxConfirmPassword.Name = "textBoxConfirmPassword";
        textBoxConfirmPassword.Size = new Size(354, 23);
        textBoxConfirmPassword.TabIndex = 5;
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.ColumnCount = 2;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel2.Controls.Add(buttonRegister, 1, 0);
        tableLayoutPanel2.Controls.Add(buttonCancel, 0, 0);
        tableLayoutPanel2.Dock = DockStyle.Fill;
        tableLayoutPanel2.Location = new Point(0, 360);
        tableLayoutPanel2.Margin = new Padding(0);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 1;
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel2.Size = new Size(360, 120);
        tableLayoutPanel2.TabIndex = 4;
        // 
        // buttonRegister
        // 
        buttonRegister.Dock = DockStyle.Fill;
        buttonRegister.Location = new Point(195, 35);
        buttonRegister.Margin = new Padding(15, 35, 15, 35);
        buttonRegister.Name = "buttonRegister";
        buttonRegister.Size = new Size(150, 50);
        buttonRegister.TabIndex = 1;
        buttonRegister.Text = "Register";
        buttonRegister.UseVisualStyleBackColor = true;
        buttonRegister.Click += buttonRegister_Click;
        // 
        // buttonCancel
        // 
        buttonCancel.Dock = DockStyle.Fill;
        buttonCancel.Location = new Point(15, 35);
        buttonCancel.Margin = new Padding(15, 35, 15, 35);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new Size(150, 50);
        buttonCancel.TabIndex = 0;
        buttonCancel.Text = "Cancel";
        buttonCancel.UseVisualStyleBackColor = true;
        buttonCancel.Click += buttonCancel_Click;
        // 
        // RegisterView
        // 
        Controls.Add(tableLayoutMain);
        Margin = new Padding(0);
        Name = "RegisterView";
        Size = new Size(900, 600);
        tableLayoutMain.ResumeLayout(false);
        tableLayoutLeftItems.ResumeLayout(false);
        flowLayoutBirthdate.ResumeLayout(false);
        flowLayoutBirthdate.PerformLayout();
        flowLayoutEmail.ResumeLayout(false);
        flowLayoutEmail.PerformLayout();
        flowLayoutUsername.ResumeLayout(false);
        flowLayoutUsername.PerformLayout();
        tableLayoutPanel1.ResumeLayout(false);
        flowLayoutPassword.ResumeLayout(false);
        flowLayoutPassword.PerformLayout();
        flowLayoutConfirmPassword.ResumeLayout(false);
        flowLayoutConfirmPassword.PerformLayout();
        tableLayoutPanel2.ResumeLayout(false);
        ResumeLayout(false);
    }
}
