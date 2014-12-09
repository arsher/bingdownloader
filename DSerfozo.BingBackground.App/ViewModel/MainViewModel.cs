using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using DSerfozo.BingBackground.App.Service;
using NuMvvm;
using NuMvvm.Input;

namespace DSerfozo.BingBackground.App.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly StorageService storageService = new StorageService();
        private readonly BingService bingService;
        private bool _visible;
        private string _imageSource;
        private bool _busy;

        public bool Busy
        {
            get { return _busy; }
            set
            {
                _busy = value;
                OnPropertyChanged();
                RefreshCommand.RaiseCanExecuteChanged();
            }
        }

        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                OnPropertyChanged();
            }
        }

        public string ImageSource
        {
            get { return _imageSource; }
            private set
            {
                _imageSource = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowWindowCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        public MainViewModel()
        {
            ShowWindowCommand = new RelayCommand(ShowWindowCommandExecute);
            RefreshCommand = new RelayCommand(RefreshCommandExecute, RefreshCommandCanExecute);

            bingService = new BingService(new Uri("http://www.bing.com"), storageService, Application.Current.Dispatcher);
            bingService.NewImageAvailable += BingServiceOnNewImageAvailable;
            bingService.Start();
        }

        private void BingServiceOnNewImageAvailable(object sender, ImageAvailableEventArgs imageAvailableEventArgs)
        {
            ImageSource = imageAvailableEventArgs.ThumbnailPath;
        }

        private bool RefreshCommandCanExecute()
        {
            return !Busy;
        }

        private async void RefreshCommandExecute()
        {
            Busy = true;
            await bingService.Refresh();
            Busy = false;
        }

        private void ShowWindowCommandExecute()
        {
            Visible = true;
        }
    }
}