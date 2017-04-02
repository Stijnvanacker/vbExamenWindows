using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using vbExamenWindows.Messages;
using vbExamenWindows.Views;
using Xamarin.Forms;

namespace vbExamenWindows.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ContentView currentView;
        public ContentView CurrentView
        {
            get
            {
                return currentView;
            }
            set
            {
                currentView = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            CurrentView = new StartView();
            InitializeMessenger();
        }

        private void InitializeMessenger()
        {
            Messenger.Default.Register<NavigationMessage>(this, NavigateToViewModel);
        }

        private void NavigateToViewModel(NavigationMessage message)
        {
            CurrentView = message.View;
        }
    }
}