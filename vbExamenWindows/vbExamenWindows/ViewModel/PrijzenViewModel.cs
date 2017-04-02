using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using vbExamenWindows.Views;
using Xamarin.Forms;
using vbExamenWindows.Messages;

namespace vbExamenWindows.ViewModel
{
    public class PrijzenViewModel: ViewModelBase
    {
        private Boolean toggled = false;
        private Double prijsInclBtw;
        private Double prijsExclBtw;
        private Double basisprijs;

        public ICommand Optie1Command { get; private set; }
        public ICommand Optie2Command { get; private set; }
        public ICommand Optie3Command { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand BestelCommand { get; private set; }

        public Boolean Toggled
        {
            get { return toggled; }
            set
            {
                toggled = value;
                System.Diagnostics.Debug.WriteLine(value);
                updatePrijzen();
                RaisePropertyChanged();
            }
        }

        public Double PrijsInclBtw
        {
            get { return prijsInclBtw; }
            set
            {
                prijsInclBtw = value;
                RaisePropertyChanged();
            }
        }

        public Double PrijsExclBtw
        {
            get { return prijsExclBtw; }
            set
            {
                prijsExclBtw = value;
                RaisePropertyChanged();
            }
        }

        public PrijzenViewModel()
        {
            System.Diagnostics.Debug.WriteLine("PrijzenViewModel constructor");
            InstantiateCommands();
            ExecuteOptie1();
            
        }

        public void InstantiateCommands()
        {
            Optie1Command = new RelayCommand(ExecuteOptie1);
            Optie2Command = new RelayCommand(ExecuteOptie2);
            Optie3Command = new RelayCommand(ExecuteOptie3);
            CancelCommand = new RelayCommand(ExecuteCancel);
            BestelCommand = new RelayCommand(ExecuteBestel);
        }

        private void ExecuteOptie1()
        {
            basisprijs = 10;
            updatePrijzen();
        }

        private void ExecuteOptie2()
        {
            basisprijs = 50;
            updatePrijzen();
            
        }

        private void ExecuteOptie3()
        {
            basisprijs = 30;
            updatePrijzen();
        }

        private void updatePrijzen()
        {
            if(toggled == true)
            {
                PrijsExclBtw = basisprijs * 0.9;
                PrijsInclBtw = (basisprijs * 0.9) * 1.21;
            }
            else
            {
                PrijsExclBtw = basisprijs;
                PrijsInclBtw = basisprijs * 1.21;
            }
        }

        private void ExecuteCancel()
        {
            Messenger.Default.Send<NavigationMessage>(new NavigationMessage { View = new StartView() });
        }

        private void ExecuteBestel()
        {
            var bestelViewModel = new BestelViewModel { PrijsBTW = prijsInclBtw, PrijsZonderBTW = prijsExclBtw };
            Messenger.Default.Send<NavigationMessage>(new Messages.NavigationMessage { View = new BestelView { BindingContext = bestelViewModel } });
            //var todoDetailViewModel = new TodoDetailViewModel { Name = SelectedTodoItem.Name, Body = SelectedTodoItem.Body };
            //Messenger.Default.Send<NavigationMessage>(new NavigationMessage { View = new TodoDetailView { BindingContext = todoDetailViewModel } });
        }
    }
}
