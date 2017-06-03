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
    public sealed partial class FormMojeDlugi : Page
    {
        public FormMojeDlugi()
        {
            this.InitializeComponent();
            UCMojeDlugi1.DoubleTapped += new DoubleTappedEventHandler(UserControl_DoubleTapped);
            UCMojeDlugi1.PokazAktywneWpisyOdKogos();
        }

        private void UserControl_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {            
            this.Frame.Navigate(typeof(Formatki.FormWpisPodglad), UCMojeDlugi1.WybranyWpis);
        }
    }
}
