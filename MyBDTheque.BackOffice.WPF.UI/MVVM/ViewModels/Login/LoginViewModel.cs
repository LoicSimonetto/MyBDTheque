using CommunityToolkit.Mvvm.Input;
using MyBDTheque.BackOffice.WPF.UI.Core;
using MyBDTheque.BackOffice.WPF.UI.MVVM.Models;
using MyBDTheque.BackOffice.WPF.UI.MVVM.Views;
using MyBDTheque.BackOffice.WPF.UI.MVVM.Views.Login;
using MyBDTheque.BackOffice.WPF.UI.Services.DataSample;
using MyBDTheque.BackOffice.WPF.UI.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels.Login
{
    public class LoginViewModel : ViewModel
    {
        private string login;
        private string motDePasse;
        private readonly IDataSample _dataSample;

        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }
        //public string MotDePasse { get; set; }
        public string MotDePasse
        {
            get => motDePasse;
            set
            {
                motDePasse = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand Connexion { get; set; }
        public RelayCommand CreerUser { get; set; }

        public LoginViewModel(INavigationService navServices, IDataSample dataSample)
        {
            _navigation = navServices;
            _dataSample = dataSample;

            Connexion = new RelayCommand(ExecuteConnexion,()=> true);
            CreerUser = new RelayCommand(()=> Navigation.NavigateTo<AddUserViewModel>(),()=> true);
        }

        private void ExecuteConnexion()
        {
            int id = _dataSample.GetIdUtilisateur(Login);
            if (id != -1)
            {
                _dataSample.SetIdUtilisateurConnecte(id);
                var mainWindow = Navigation.OpenWindow<MainWindow>(typeof(MainLogin));
                (mainWindow.DataContext as MainViewModel).Utilisateur = _dataSample.GetIdentifiantUtilisateurConnecte();
                mainWindow.Show();
            }
            else if (Login == null | Login == "")
            {
                MessageBox.Show("Veuillez saisir un identifiant.");
            }
            else if (MotDePasse == null | MotDePasse == "")
            {
                MessageBox.Show("Veuillez saisir un mot de passe.");
            }
            else
            {
                MessageBox.Show("Identifiant / Mot de passe incorrects.");
            }
        }
    }
}
