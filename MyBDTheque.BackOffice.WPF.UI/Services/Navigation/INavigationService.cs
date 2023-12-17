using MyBDTheque.BackOffice.WPF.UI.Core;
using MyBDTheque.BackOffice.WPF.UI.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyBDTheque.BackOffice.WPF.UI.Services.Navigation
{
    public interface INavigationService
    {
        ViewModel CurrentView { get; }
        void NavigateTo<T>() where T : ViewModel;
        void NavigateToEdit<T,TE>(TE el, int id) where T : ViewModel where TE : ElementType;
        void NavigateToDelete<T,TE>(TE el,int id) where T : ViewModel where TE : ElementType;
        void NavigateToDetails<T, TE>(TE el) where T : ViewModel where TE : ElementType;
        Window OpenWindow<T>(Type typeOfWindowToClose) where T : Window;
    }
}
