using CommunityToolkit.Mvvm.Input;
using MyBDTheque.BackOffice.WPF.UI.Core;
using MyBDTheque.BackOffice.WPF.UI.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels.Login
{
    public class MainLoginViewModel : ViewModel
    {
        public MainLoginViewModel(INavigationService navService)
        {
            _navigation = navService;
        }
    }
}
