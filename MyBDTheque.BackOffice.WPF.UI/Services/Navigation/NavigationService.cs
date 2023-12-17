using CommunityToolkit.Mvvm.ComponentModel;
using MyBDTheque.BackOffice.WPF.UI.Core;
using MyBDTheque.BackOffice.WPF.UI.MVVM.Models;
using MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels.BandeDessinee;
using MyBDTheque.BackOffice.WPF.UI.MVVM.Views;
using MyBDTheque.BackOffice.WPF.UI.MVVM.Views.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyBDTheque.BackOffice.WPF.UI.Services.Navigation
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private ViewModel _currentView;
        public ViewModel CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private readonly Func<Type, ViewModel> _viewModelFactory;
        private readonly Func<Type, Window> _viewFactory;

        public NavigationService(Func<Type, ViewModel> viewModelFactory, Func<Type, Window> viewFactory)
        {
            _viewModelFactory = viewModelFactory;
            _viewFactory = viewFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModel
        {
            ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
        }

        public void NavigateToEdit<TViewModel, TElementType>(TElementType el, int id) where TViewModel : ViewModel where TElementType : ElementType
        {
            ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            if (el.GetType().Name == "BandeDessinee")
            {
                (viewModel as BandeDessineeEditViewModel).Bd = el as BandeDessinee;
                (viewModel as BandeDessineeEditViewModel).MyId = id;
            }
            CurrentView = viewModel;
        }

        public void NavigateToDelete<TViewModel,TElement>(TElement el, int id) where TViewModel : ViewModel where TElement : ElementType
        {
            ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            if (el.GetType().Name == "BandeDessinee")
            {
                (viewModel as BandeDessineeDeleteViewModel).Bd = el as BandeDessinee;
                (viewModel as BandeDessineeDeleteViewModel).Id = id;
            }
            CurrentView = viewModel;
        }

        public void NavigateToDetails<TViewModel, TElement>(TElement el) where TViewModel : ViewModel where TElement : ElementType
        {
            ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            if (el.GetType().Name == "BandeDessinee")
            {
                (viewModel as BandeDessineeDetailsViewModel).Bd = el as BandeDessinee;
            }
            CurrentView = viewModel;
        }

        public Window OpenWindow<TView>(Type typeOfWindowToClose) where TView : Window
        {
            //_currentView = null;
            CurrentView = null;
            Window  window = _viewFactory.Invoke(typeof(TView));
            Window toClose = _viewFactory.Invoke(typeOfWindowToClose);
            toClose.Hide();  //
            return window;
        }

    }
}
