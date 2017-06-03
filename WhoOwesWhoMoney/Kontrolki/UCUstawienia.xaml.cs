using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WhoOwesWhoMoney.Kontrolki
{
    public sealed partial class UCUstawienia : UserControl
    {
        public UCUstawienia()
        {
            this.InitializeComponent();
            UzupelnijListe();
        }

        private void UzupelnijListe()
        {
            listViewUstawienia.Items.Add("Ustaw Email");
            listViewUstawienia.Items.Add("Eksportuj dane");
            listViewUstawienia.Items.Add("Importuj dane");
        }

        private async void listViewUstawienia_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (listViewUstawienia.SelectedIndex != -1)
            {
                switch (listViewUstawienia.SelectedIndex)
                {
                    case 0:                        
                        ObjEmail staryEmail = Database.PobierzEmail();
                        if (staryEmail != null)
                        {
                            string tekst = await InputTextDialogAsync(staryEmail.Email);
                            if (tekst != "")
                            {
                                staryEmail.Email = tekst;
                                Database.Update(staryEmail);
                            }
                        }
                        if (staryEmail == null)
                        {
                            string tekst = await InputTextDialogAsync("");
                            if (tekst != "")
                            {
                                ObjEmail email = new ObjEmail
                                {
                                    ID = 1,
                                    Email = tekst
                                };
                                Database.Insert(email);
                            }
                        }

                        break;
                    case 1:
                        GlobalVariables.EksportDoPliku();
                        break;
                    case 2:
                        GlobalVariables.ImportZPliku();
                        break;
                }

            }
        }

        private async Task<string> InputTextDialogAsync(string email)
        {
            TextBox inputTextBox = new TextBox();
            inputTextBox.AcceptsReturn = false;
            inputTextBox.Height = 32;
            ContentDialog dialog = new ContentDialog();
            dialog.Content = inputTextBox;
            dialog.Title = "Email";
            dialog.IsSecondaryButtonEnabled = true;
            dialog.PrimaryButtonText = "Zapisz";
            dialog.SecondaryButtonText = "Anuluj";
            inputTextBox.Text = email;
            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
                return inputTextBox.Text;
            else
                return "";
        }
    }
}
