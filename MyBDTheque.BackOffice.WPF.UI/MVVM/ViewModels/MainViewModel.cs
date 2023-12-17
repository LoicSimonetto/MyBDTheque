using CommunityToolkit.Mvvm.Input;
using MyBDTheque.BackOffice.WPF.UI.Core;
using MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels.BandeDessinee;
using MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels.Login;
using MyBDTheque.BackOffice.WPF.UI.MVVM.Views;
using MyBDTheque.BackOffice.WPF.UI.MVVM.Views.Login;
using MyBDTheque.BackOffice.WPF.UI.Services.DataSample;
using MyBDTheque.BackOffice.WPF.UI.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public string WindowTitle { get; set; }
        public string utilisateur { get; set; }
        public string Utilisateur
        {
            get => utilisateur;
            set
            {
                utilisateur = value;
                OnPropertyChanged();
            }
        }
        private readonly IDataSample _dataSample;
        public RelayCommand NavigateToBandeDessineeIndexCommand { get; set; }
        public RelayCommand Deconnexion { get; set; }
        public MainViewModel(INavigationService navServices, IDataSample dataSample) 
        {
            Navigation = navServices;
            _dataSample = dataSample;

            WindowTitle = "Gestion du catalogue de bande dessinées";

            NavigateToBandeDessineeIndexCommand = new RelayCommand(() => { Navigation.NavigateTo<BandeDessineeIndexViewModel>(); }, () => { return true; });
            Deconnexion = new RelayCommand(ExecuteDeconnexion,()=> true);
        }

        private void ExecuteDeconnexion()
        {
            _dataSample.SetIdUtilisateurConnecte(-1);
            var window = Navigation.OpenWindow<MainLogin>(typeof(MainWindow));
            (window.DataContext as MainLoginViewModel).Navigation.NavigateTo<LoginViewModel>();
            window.Show();
        }
    }
}
