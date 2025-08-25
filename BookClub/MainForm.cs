using BookClub.Controllers;
using BookClub.Data;
using BookClub.Models;
using BookClub.Services;
using BookClub.Views;

namespace BookClub
{
    public partial class MainForm : Form
    {
        private AppDbContext _context;
        private Panel _viewContainer;
        private ViewNavigator _navigator;
        private AccountsService _accountsService;
        public MainForm(AppDbContext context)
        {
            InitializeComponent();
            _context = context;

            _viewContainer = new Panel
            {
                Dock = DockStyle.Fill,
            };
            Controls.Add(_viewContainer);

            _accountsService = new AccountsService(_context);

            ViewFactory factory = new ViewFactory();
            factory.Register(() => new LoginView(new LoginController(_accountsService)));
            factory.Register(() => new RegisterView(new RegisterController(_accountsService)));
            factory.Register(() => new DashboardView(new DashboardController()));

            _navigator = new ViewNavigator(_viewContainer, factory);

            var loginView = factory.Create<LoginView>();
            _navigator.NavigateTo<LoginView>();

        }
    }
}
