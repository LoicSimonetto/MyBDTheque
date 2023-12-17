using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyBDTheque.BackOffice.WPF.UI.Core;
using MyBDTheque.BackOffice.WPF.UI.Services.DataSample;
using MyBDTheque.BackOffice.WPF.UI.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels.BandeDessinee
{
    public class BandeDessineeAddViewModel : ViewModel
    {
        public Models.BandeDessinee Bd{ get; set; }
        public RelayCommand AjouterBandeDessinee { get; set; }
        public RelayCommand Annuler { get; set; }

        private readonly IDataSample _dataSample;
        public BandeDessineeAddViewModel(INavigationService navService,IDataSample dataSample)
        {
            Bd = new Models.BandeDessinee();
            Bd.DateDeSortie = DateTime.Now;

            _navigation = navService;
            _dataSample = dataSample;

            Annuler = new RelayCommand(()=> Navigation.NavigateTo<BandeDessineeIndexViewModel>(),()=> true);
            AjouterBandeDessinee = new RelayCommand(ActionAdd, () => true);
        }

        private void ActionAdd()
        {
            if (Bd.Titre != null && Bd.Titre != "")
            {
                _dataSample.AddElement(Bd);
                Navigation.NavigateTo<BandeDessineeIndexViewModel>();
            }
            else
            {
                MessageBox.Show("Le titre doit être renseigné.");
            }
        }
    }
}
