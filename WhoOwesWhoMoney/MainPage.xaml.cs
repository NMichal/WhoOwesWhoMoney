using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
            //Kod odpowiedzialny za przycisk wstecz
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += (s, a) =>
            {
                Debug.WriteLine("BackRequested");
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                    a.Handled = true;
                }
            };
            GlobalVariables.Init(); //Puszczamy inicjalizację zmiennych globalnych po uruchomieniu aplikacji
            Database.Init();
            //=---------------TEST------------------TEST--------------TEST-----------------


            //=---------------TEST------------------TEST--------------TEST-----------------

            ApplicationView.PreferredLaunchViewSize = new Size(500, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            wyswietlKategorie();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void wyswietlKategorie()
        {
            listView.Items.Add("Dodaj nowe");
            listView.Items.Add("Pożyczone od kogoś");
            listView.Items.Add("Pożyczone komuś");
            listView.Items.Add("Ustawienia");
        }

        private void listView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                Debug.WriteLine("Wybrany obiekt " + listView.SelectedItem.ToString());
                Debug.WriteLine("Index obiektu " + listView.SelectedIndex.ToString());
                /*if (listView.SelectedIndex == 0)
                {
                    this.Frame.Navigate(typeof(FormDodajNowe));
                }
                if (listView.SelectedIndex == 1)
                {
                    this.Frame.Navigate(typeof(Formatki.FormMojeDlugi));
                }
                if (listView.SelectedIndex == 2)
                {
                    this.Frame.Navigate(typeof(Formatki.FormPozyczoneKomus));
                }*/
                switch (listView.SelectedIndex)
                {
                    case 0:
                        this.Frame.Navigate(typeof(FormDodajNowe));
                        break;
                    case 1:
                        this.Frame.Navigate(typeof(Formatki.FormMojeDlugi));
                        break;
                    case 2:
                        this.Frame.Navigate(typeof(Formatki.FormPozyczoneKomus));
                        break;
                    case 3:
                        this.Frame.Navigate(typeof(Formatki.FormUstawienia));
                        //GlobalVariables.EksportDoPliku();
                        GlobalVariables.ImportZPliku();
                        break;
                }
            }
            else
            {
                Debug.WriteLine("Nie wybrano obiektu");
                //=---------------TEST------------------TEST--------------TEST-----------------
                //this.Frame.Navigate(typeof(Formatki.FormWpisPodglad));
                //=---------------TEST------------------TEST--------------TEST-----------------
            }
        }


    }
}
