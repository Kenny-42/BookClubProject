namespace BookClub.Views;

public class ViewBlue : UserControl, IView
{
    public event EventHandler? ToRedClicked;

    public ViewBlue()
    {
        InitializeComponent();

        buttonToRed.Click += (_, _) => ToRedClicked?.Invoke(this, EventArgs.Empty);
    }

    public void OnNavigateTo() { }
    public void OnNavigateFrom() { }
    public Control GetControl() => this;
    public const string ViewKey = "ViewBlue";

    private void InitializeComponent()
    {
        buttonToRed = new Button();
        SuspendLayout();
        // 
        // buttonToRed
        // 
        buttonToRed.Location = new Point(315, 226);
        buttonToRed.Name = "buttonToRed";
        buttonToRed.Size = new Size(75, 23);
        buttonToRed.TabIndex = 0;
        buttonToRed.Text = "To Red";
        buttonToRed.UseVisualStyleBackColor = true;
        // 
        // ViewBlue
        // 
        BackColor = Color.Blue;
        Controls.Add(buttonToRed);
        Name = "ViewBlue";
        Size = new Size(900, 600);
        ResumeLayout(false);

    }
    private Button buttonToRed;

}
