using GPSNotebook.Models;
using GPSNotebook.Services.RepositoryMap;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;

namespace GPSNotebook.ViewModels
{
    public class PinList : ViewModelBase, INavigatedAware
    {

        private IRepositoryMap repository;

        private ObservableCollection<Pin> pins = new ObservableCollection<>();
        public ObservableCollection<Pin> Pin
        {
            get => pins;
            set => SetProperty(ref pins, value);
        }
        private Pin selectedItem;
        public Pin SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }

        public PinListViewModel(INavigationService navigationService, IRepositoryMap repository) : base(navigationService)
        {
            this.repository = repository;
            Pin = repository.GetPlaces();
        }


        public DelegateCommand OnNavigationToAddEditPinView =>
          new DelegateCommand(NavigationToAddEditPinViewCommand);
        public ICommand OnEditCommand => new DelegateCommand<Pin>(EditCommand);

        public ICommand OnDeleteCommand => new DelegateCommand<Pin>(DeleteCommand);
        public ICommand OnChangeTabCommand => new DelegateCommand<Pin>(ChangeTabCommand);

        private void ChangeTabCommand(Pin obj)
        {
            var Params = new NavigationParameters();

            Params.Add("SelectedPlace", obj);

            NavigationService.SelectTabAsync($"{nameof(Map)}", Params);
        }

        private void DeleteCommand(Pin e)
        {
            repository.RemovePlace(e.Id);

            UpdatePins();
        }

        private void EditCommand(Pin e)
        {
            NavigationParameters pairs = new NavigationParameters();

            pairs.Add("Place", e);

            NavigationService.NavigateAsync(nameof(AddEditPinView), pairs);
        }

        private void UpdatePins()
        {
            Pins = repository.GetPlaces();
        }

        Pin AddNewPlace()
        {
            var place = new Pin();
            repository.AddPlace(place);
            return place;
        }

        private async void NavigationToAddEditPinViewCommand()
        {
            NavigationParameters pairs = new NavigationParameters();

            pairs.Add("Place", AddNewPlace());

            await NavigationService.NavigateAsync(nameof(AddEditPinView), pairs);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            UpdatePins();
        }
    }
}
