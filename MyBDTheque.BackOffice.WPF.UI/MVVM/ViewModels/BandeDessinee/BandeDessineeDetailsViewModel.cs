using CommunityToolkit.Mvvm.Input;
using MyBDTheque.BackOffice.WPF.UI.Core;
using MyBDTheque.BackOffice.WPF.UI.Services.DataSample;
using MyBDTheque.BackOffice.WPF.UI.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels.BandeDessinee
{
    public class BandeDessineeDetailsViewModel : ViewModel
    {
        private readonly IDataSample _dataSample;
        public Models.BandeDessinee Bd { get; set; }
        public RelayCommand Retour { get; set; }

        public BandeDessineeDetailsViewModel(INavigationService navServices, IDataSample dataSample)
        {
            _navigation = navServices;
            _dataSample = dataSample;

            Retour = new RelayCommand(()=> Navigation.NavigateTo<BandeDessineeIndexViewModel>(), ()=> true);
        }
    }
}
