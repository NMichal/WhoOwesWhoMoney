using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WhoOwesWhoMoney
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(400, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            wyswietlKategorie();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void wyswietlKategorie()
        {
            listView.Items.Add("Dodaj nowe");
            listView.Items.Add("Moje zaległości");
            listView.Items.Add("Ktoś mi oddać ma");
        }

        private void listView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                Debug.WriteLine("Wybrany obiekt " + listView.SelectedItem.ToString());
                Debug.WriteLine("Index obiektu " + listView.SelectedIndex.ToString());
            }
            else
                Debug.WriteLine("Nie wybrano obiektu");
        }
    }
}
