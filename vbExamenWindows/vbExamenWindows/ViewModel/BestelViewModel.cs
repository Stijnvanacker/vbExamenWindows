using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace vbExamenWindows.ViewModel
{
    
    public class BestelViewModel: ViewModelBase
    {
        private double prijsBTW;

        public double PrijsBTW
        {
            get { return prijsBTW; }
            set
            {
                prijsBTW = value;
                RaisePropertyChanged();
            }
        }

        private double prijsZonderBTW;

        public double PrijsZonderBTW
        {
            get { return prijsZonderBTW; }
            set
            {
                prijsZonderBTW = value;
                RaisePropertyChanged();
            }
        }

        public BestelViewModel()
        {
            System.Diagnostics.Debug.WriteLine(prijsZonderBTW);
        }
    }
}
