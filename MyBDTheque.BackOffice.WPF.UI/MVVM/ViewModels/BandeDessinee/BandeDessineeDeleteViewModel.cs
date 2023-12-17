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
    public class BandeDessineeDeleteViewModel : ViewModel
    {
        private readonly IDataSample _dataSample;
        public int Id { get; set; }
        public Models.BandeDessinee Bd { get; set; }
        public RelayCommand Valider { get; set; }
        public RelayCommand Annuler { get; set; }

        public BandeDessineeDeleteViewModel(INavigationService navServices, IDataSample dataSample)
        {
            _navigation = navServices;
            _dataSample = dataSample;

            Valider = new RelayCommand(()=> { _dataSample.DeleteElement(Id); Navigation.NavigateTo<BandeDessineeIndexViewModel>(); },() => true);
            Annuler = new RelayCommand(() => Navigation.NavigateTo<BandeDessineeIndexViewModel>(), () => true);
        }
    }
}
