using CommunityToolkit.Mvvm.Input;
using MyBDTheque.BackOffice.WPF.UI.Core;
using MyBDTheque.BackOffice.WPF.UI.MVVM.Views.BandeDessinee;
using MyBDTheque.BackOffice.WPF.UI.Services.DataSample;
using MyBDTheque.BackOffice.WPF.UI.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels.BandeDessinee
{
    public class BandeDessineeIndexViewModel : ViewModel
    {
        private readonly IDataSample _dataSample;
        public ObservableCollection<Models.BandeDessinee> BandesDessinees { get; set; }
        public Models.BandeDessinee SelectedObject { get; set; }

        public RelayCommand OpenDelete { get; set; }
        public RelayCommand OpenEdit { get; set; }
        public RelayCommand OpenAdd { get; set; }
        public RelayCommand OpenDetails { get; set; }

        public BandeDessineeIndexViewModel(INavigationService navServices, IDataSample dataSample)
        {
            _navigation = navServices;
            _dataSample = dataSample;

            BandesDessinees = new ObservableCollection<Models.BandeDessinee>(_dataSample.GetBandeDessinees());

            OpenDelete = new RelayCommand(ExecuteOpenDelete ,()=> { return true; });
            OpenEdit = new RelayCommand(ExecuteOpenEdit, () => { return true; });
            OpenDetails = new RelayCommand(ExecuteOpenDetails, () => { return true; });
            OpenAdd = new RelayCommand(() => { Navigation.NavigateTo<BandeDessineeAddViewModel>(); },()=> { return true; });
        }

        private void ExecuteOpenDetails()
        {
            if (SelectedObject != null)
            {
                Navigation.NavigateToDetails<BandeDessineeDetailsViewModel, ElementType>(new Models.BandeDessinee(SelectedObject));
            }
            else
            {
                MessageBox.Show("Sélectionner une bande dessinée.");
            }
        }

        private void ExecuteOpenDelete()
        {
            if (SelectedObject != null)
            {
                Navigation.NavigateToDelete<BandeDessineeDeleteViewModel,ElementType>(new Models.BandeDessinee(SelectedObject),BandesDessinees.IndexOf(SelectedObject));
            }
            else
            {
                MessageBox.Show("Sélectionner une bande dessinée.");
            }
        }

        private void ExecuteOpenEdit()
        {
            if (SelectedObject != null)
            {
                Navigation.NavigateToEdit<BandeDessineeEditViewModel,ElementType>(new Models.BandeDessinee(SelectedObject), BandesDessinees.IndexOf(SelectedObject));
            }
            else
            {
                MessageBox.Show("Sélectionner une bande dessinée.");
            }
        }
    }
}
