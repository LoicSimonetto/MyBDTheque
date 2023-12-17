using MyBDTheque.BackOffice.WPF.UI.Core;
using MyBDTheque.BackOffice.WPF.UI.Services.DataSample;
using MyBDTheque.BackOffice.WPF.UI.Services.Navigation;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels.BandeDessinee
{
    public class BandeDessineeEditViewModel :ViewModel
    {
        public string WindowTitle { get; set; }
        public int MyId { get; set; }
        public Models.BandeDessinee Bd { get; set; }
        public RelayCommand NavigateToIndex { get; set; }
        public RelayCommand Validation { get; set; }

        private readonly IDataSample _dataSample;

        public BandeDessineeEditViewModel(INavigationService navServices, IDataSample dataSample)
        {
            WindowTitle = "Editer la bande dessinée :";

            _navigation = navServices;
            _dataSample = dataSample;

            NavigateToIndex = new RelayCommand(() => { Navigation.NavigateTo<BandeDessineeIndexViewModel>(); },() => { return true; });

            Validation = new RelayCommand(ValidationAction, () => { return true; });

        }

        private void ValidationAction()
        {
            _dataSample.EditElement(MyId, Bd);
            Navigation.NavigateTo<BandeDessineeIndexViewModel>();
        }
    }
}
