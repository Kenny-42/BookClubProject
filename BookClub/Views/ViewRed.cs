namespace BookClub.Views;

public class ViewRed : UserControl, IView
{
    public event EventHandler? ToBlueClicked;

    public ViewRed()
    {
        InitializeComponent();

        buttonToBlue.Click += (_, _) => ToBlueClicked?.Invoke(this, EventArgs.Empty);
    }

    public void OnNavigateTo() { }
    public void OnNavigateFrom() { }
    public Control GetControl() => this;
    public const string ViewKey = "ViewRed";

    private void InitializeComponent()
    {
        buttonToBlue = new Button();
        SuspendLayout();
        // 
        // buttonToBlue
        // 
        buttonToBlue.Location = new Point(315, 226);
        buttonToBlue.Name = "buttonToBlue";
        buttonToBlue.Size = new Size(75, 23);
        buttonToBlue.TabIndex = 0;
        buttonToBlue.Text = "To Blue";
        buttonToBlue.UseVisualStyleBackColor = true;
        // 
        // ViewRed
        // 
        BackColor = Color.Red;
        Controls.Add(buttonToBlue);
        Name = "ViewRed";
        Size = new Size(900, 600);
        ResumeLayout(false);

    }
    private Button buttonToBlue;

}
