using BookClub.Common;
using BookClub.Controllers;
using BookClub.Models;
using System.ComponentModel;

namespace BookClub.Views;

public class ForgotPasswordView : UserControl, IView
{
    private ForgotPasswordController _controller;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IController Controller
    {
        get => _controller;
        set => _controller = (ForgotPasswordController)value;
    }

    public ForgotPasswordView()
    {
        InitializeComponent();
        buttonCancel.Click += OnCancelClicked;
        buttonGetPassword.Click += OnGetPasswordClicked;
    }

    private void OnCancelClicked(object? sender, EventArgs e)
    {
        _controller.Cancel();
    }

    private void OnGetPasswordClicked(object? sender, EventArgs e)
    {
        var result = _controller.OnGetPasswordClicked(textBoxUsernameEmail.Text);

        if (result != null && result.Success)
        {
            MessageBox.Show($"Your password is: {result.Value}", "Password Retrieved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else if(result != null && result.Failed)
        {
            MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void OnNavigateTo() { }
    public void OnNavigateFrom()
    {
        textBoxUsernameEmail.Clear();
    }
    public Control GetControl() => this;
    public static string ViewKey => "ForgotPasswordView";

    private void InitializeComponent()
    {
        tableLayoutMain = new TableLayoutPanel();
        tableLayoutItems = new TableLayoutPanel();
        flowLayoutUsernameEmail = new FlowLayoutPanel();
        labelUsernameEmail = new Label();
        textBoxUsernameEmail = new TextBox();
        labelTitle = new Label();
        tableLayoutButtons = new TableLayoutPanel();
        tableLayoutButtons2 = new TableLayoutPanel();
        buttonGetPassword = new Button();
        buttonCancel = new Button();
        tableLayoutMain.SuspendLayout();
        tableLayoutItems.SuspendLayout();
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
        tableLayoutMain.TabIndex = 1;
        // 
        // tableLayoutItems
        // 
        tableLayoutItems.ColumnCount = 1;
        tableLayoutItems.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutItems.Controls.Add(flowLayoutUsernameEmail, 0, 1);
        tableLayoutItems.Controls.Add(labelTitle, 0, 0);
        tableLayoutItems.Controls.Add(tableLayoutButtons, 0, 2);
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
        tableLayoutButtons.Controls.Add(tableLayoutButtons2, 0, 0);
        tableLayoutButtons.Dock = DockStyle.Fill;
        tableLayoutButtons.Location = new Point(0, 240);
        tableLayoutButtons.Margin = new Padding(0);
        tableLayoutButtons.Name = "tableLayoutButtons";
        tableLayoutButtons.RowCount = 2;
        tableLayoutButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutButtons.Size = new Size(450, 120);
        tableLayoutButtons.TabIndex = 3;
        // 
        // tableLayoutButtons2
        // 
        tableLayoutButtons2.ColumnCount = 2;
        tableLayoutButtons2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutButtons2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutButtons2.Controls.Add(buttonGetPassword, 1, 0);
        tableLayoutButtons2.Controls.Add(buttonCancel, 0, 0);
        tableLayoutButtons2.Dock = DockStyle.Fill;
        tableLayoutButtons2.Location = new Point(0, 0);
        tableLayoutButtons2.Margin = new Padding(0);
        tableLayoutButtons2.Name = "tableLayoutButtons2";
        tableLayoutButtons2.RowCount = 1;
        tableLayoutButtons2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutButtons2.Size = new Size(450, 60);
        tableLayoutButtons2.TabIndex = 0;
        // 
        // buttonGetPassword
        // 
        buttonGetPassword.Dock = DockStyle.Fill;
        buttonGetPassword.Location = new Point(235, 10);
        buttonGetPassword.Margin = new Padding(10);
        buttonGetPassword.Name = "buttonGetPassword";
        buttonGetPassword.Size = new Size(205, 40);
        buttonGetPassword.TabIndex = 1;
        buttonGetPassword.Text = "Get Password";
        buttonGetPassword.UseVisualStyleBackColor = true;
        // 
        // buttonCancel
        // 
        buttonCancel.Dock = DockStyle.Fill;
        buttonCancel.Location = new Point(10, 10);
        buttonCancel.Margin = new Padding(10);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new Size(205, 40);
        buttonCancel.TabIndex = 0;
        buttonCancel.Text = "Cancel";
        buttonCancel.UseVisualStyleBackColor = true;
        // 
        // ForgotPasswordView
        // 
        Controls.Add(tableLayoutMain);
        Margin = new Padding(0);
        Name = "ForgotPasswordView";
        Size = new Size(900, 600);
        tableLayoutMain.ResumeLayout(false);
        tableLayoutItems.ResumeLayout(false);
        tableLayoutItems.PerformLayout();
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
    private TableLayoutPanel tableLayoutButtons2;
    private Button buttonGetPassword;
    private Button buttonCancel;
    private TableLayoutPanel tableLayoutButtons;
}
