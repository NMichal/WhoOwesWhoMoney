using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WhoOwesWhoMoney.Formatki
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormWpisPodglad : Page
    {

        private ObjWpis wpis;

        public FormWpisPodglad()
        {
            this.InitializeComponent();
            UCDodajNowe2.ZablokujPola();
            // Tu musimy odebrać parametr 
            //ObjWpis = parametr;

            //Dopisać metodę na UC wyświetl wpis
            //UCDodajNowe2.WyswietlWpis(wpis);

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            wpis = e.Parameter as ObjWpis;
        }
    }
}
