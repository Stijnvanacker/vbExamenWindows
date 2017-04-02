using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using vbExamenWindows.Messages;
using vbExamenWindows.Views;

namespace vbExamenWindows.ViewModel
{
    public class StartViewModel: ViewModelBase
    {
        public ICommand bekijkPrijzenCommand { get; private set; }

        public StartViewModel()
        {
            System.Diagnostics.Debug.WriteLine("StartViewModel");
            InstantiateCommands();
        }

        private void InstantiateCommands()
        {
            bekijkPrijzenCommand = new RelayCommand(ExecutePrijzenCommand);
        }

        private void ExecutePrijzenCommand()
        {
            System.Diagnostics.Debug.WriteLine("ExecutePrijzen");
            Messenger.Default.Send<NavigationMessage>(new NavigationMessage { View = new PrijzenView() });
        }
    }
}
