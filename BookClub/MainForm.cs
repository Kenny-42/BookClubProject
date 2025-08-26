using BookClub.Controllers;
using BookClub.Data;
using BookClub.Models;
using BookClub.Services;
using BookClub.Views;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookClub
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ViewNavigator _navigator;
        private Panel _viewContainer;
        private AppDbContext _context;
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
            _navigator.RegisterView<ViewRed, RedController>(ViewRed.ViewKey);
            _navigator.RegisterView<ViewBlue, BlueController>(ViewBlue.ViewKey);


            // Start app
            _navigator.NavigateTo(ViewRed.ViewKey);
        }
    }
}
