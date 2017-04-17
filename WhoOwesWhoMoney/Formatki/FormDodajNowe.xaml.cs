using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WhoOwesWhoMoney
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class FormDodajNowe : Page
    {
        private Contact kontakt;

        public FormDodajNowe()
        {
            this.InitializeComponent();

            WybierzKontakt();


            //Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            //Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += (s, a) =>
            //{
            //    Debug.WriteLine("BackRequested");
            //    if (Frame.CanGoBack)
            //    {
            //        Frame.GoBack();
            //        a.Handled = true;
            //    }
            //};
        }

        public async void WybierzKontakt()
        {
            var contactPicker = new Windows.ApplicationModel.Contacts.ContactPicker();
            contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.Email);
            //contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.Address);
            contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.PhoneNumber);

            kontakt = await contactPicker.PickContactAsync();
            if (kontakt != null)
            {
                var email = kontakt.Emails.FirstOrDefault<Windows.ApplicationModel.Contacts.ContactEmail>();
                var phone = kontakt.Phones.FirstOrDefault<Windows.ApplicationModel.Contacts.ContactPhone>();
            }
        }

        private void UCDodajNowe1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void buttonWyczysc_Click(object sender, RoutedEventArgs e)
        {
            UCDodajNowe1.Wyczysc();
        }

        private async void buttonZapisz_Click(object sender, RoutedEventArgs e)
        {
            if (UCDodajNowe1.Zapis())
            {
                var dialog = new MessageDialog("Dane zapisano pomyślnie.");
                await dialog.ShowAsync();
                this.Frame.Navigate(typeof(MainPage));
            }
            else
            {
                var dialog = new MessageDialog("Uzupełnij brakujące dane.");
                await dialog.ShowAsync();
            }
        }

        private void buttonAnuluj_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
