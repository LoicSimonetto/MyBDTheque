using Microsoft.Extensions.DependencyInjection;
using MyBDTheque.BackOffice.WPF.UI.Core;
using MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels;
using MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels.BandeDessinee;
using MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels.Login;
using MyBDTheque.BackOffice.WPF.UI.MVVM.Views;
using MyBDTheque.BackOffice.WPF.UI.MVVM.Views.BandeDessinee;
using MyBDTheque.BackOffice.WPF.UI.MVVM.Views.Login;
using MyBDTheque.BackOffice.WPF.UI.Services.DataSample;
using MyBDTheque.BackOffice.WPF.UI.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyBDTheque.BackOffice.WPF.UI
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            // DALs :
            services.AddSingleton<IDataSample, DataSample>();

            // Connexion
            services.AddSingleton<MainLoginViewModel>();
            services.AddSingleton<MainLogin>(provider => new MVVM.Views.Login.MainLogin()
            {
                DataContext = provider.GetRequiredService<MainLoginViewModel>()
            });
            // Menu principal :
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>(provider => new MVVM.Views.MainWindow()
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            // Contrôles utilisateur BandeDessinee :
            services.AddTransient<BandeDessineeAddViewModel>();
            services.AddTransient<BandeDessineeDeleteViewModel>();
            services.AddTransient<BandeDessineeDetailsViewModel>();
            services.AddTransient<BandeDessineeIndexViewModel>();
            services.AddTransient<BandeDessineeEditViewModel>();
            // Contrôles utilisateur Login :
            services.AddTransient<LoginViewModel>();
            services.AddTransient<AddUserViewModel>();

            // Navigation :
            services.AddSingleton<INavigationService, NavigationService>();
            // Factories :
            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));
            services.AddSingleton<Func<Type, Window>>(serviceProvider => windowType => (Window)serviceProvider.GetRequiredService(windowType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            //var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            //mainWindow.Show();

            var mainLogin = _serviceProvider.GetRequiredService<MainLogin>();
            (mainLogin.DataContext as MainLoginViewModel).Navigation.NavigateTo<LoginViewModel>();
            mainLogin.Show();
            base.OnStartup(e);
        }
    }
}
