using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace vbExamenWindows.Messages
{
    public class NavigationMessage
    {
        public ContentView View { get; set; }
    }
}
