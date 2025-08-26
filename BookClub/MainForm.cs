using BookClub.Controllers;
using BookClub.Views;

namespace BookClub;

public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ViewNavigator _navigator;
    private Panel _viewContainer;

    public MainForm(IServiceProvider services)
    {
        InitializeComponent();

        // Setup _viewContainer
        _viewContainer = new Panel
        {
            Dock = DockStyle.Fill
        };
        this.Controls.Add(_viewContainer);

        // Setup ServiceProvider
        _serviceProvider = services;

        // Setup ViewNavigator
        _navigator = new ViewNavigator(_viewContainer, _serviceProvider);

        // Register views
        _navigator.RegisterView<LoginView, LoginController>(LoginView.ViewKey);
        _navigator.RegisterView<RegisterView, RegisterController>(RegisterView.ViewKey);
        _navigator.RegisterView<ForgotPasswordView, ForgotPasswordController>(ForgotPasswordView.ViewKey);


        // Start app
        _navigator.NavigateTo(LoginView.ViewKey);
    }
}
