using CommunityToolkit.Mvvm.Input;
using MyBDTheque.BackOffice.WPF.UI.Core;
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
    public class AddUserViewModel : ViewModel
    {
        private readonly IDataSample _dataSample;
        public string Identifiant { get; set; }
        public string MotDePasse { get; set; }
        public RelayCommand Annuler { get; set; }
        public RelayCommand Enregistrer { get; set; }
        public AddUserViewModel(INavigationService navService, IDataSample dataSample)
        {
            _navigation = navService;
            _dataSample = dataSample;

            Annuler = new RelayCommand(()=> Navigation.NavigateTo<LoginViewModel>(),()=> true);
            Enregistrer = new RelayCommand(ExecuteEnregistrer, () => true);
        }

        private void ExecuteEnregistrer()
        {
            if (_dataSample.CheckLogin(Identifiant))
            {
                MessageBox.Show("L'identifant "+ Identifiant +" est déjà utilisé.");
            }
            else if (Identifiant == null | Identifiant == "")
            {
                MessageBox.Show("Veuillez saisir un identifiant.");
            }
            else if (MotDePasse == null | MotDePasse == "")
            {
                MessageBox.Show("Veuillez saisir un mot de passe.");
            }
            else
            {
                _dataSample.AddUser(Identifiant, MotDePasse);
                MessageBox.Show("Utilisateur "+ Identifiant + " enregistré avec succès.");
                Navigation.NavigateTo<LoginViewModel>();
            }
        }
    }
}
