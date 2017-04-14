using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WhoOwesWhoMoney
{
    public sealed partial class UCDodajNowe : UserControl
    {
        public UCDodajNowe()
        {
            this.InitializeComponent();
            Init();
        }


        private void Init()
        {
            textBoxDodatkoweInfo.PlaceholderText = "Wpisz dodatkowe informacje... \n(opcjonalne)";
            textBoxKwota.PlaceholderText = "Podaj kwotę...";
            textBoxMiejsce.PlaceholderText = "Miejsce... (opcjonalne)";
            textBoxZaCo.PlaceholderText = "Opis za co...";
            DataOddania.PlaceholderText = "(opcjonalne)";
            Data.Date = DateTime.Now;

        }

        /// <summary>
        /// Metoda umożliwia pokazanie kontrolki jako tylko do podglądu
        /// </summary>
        internal void ZablokujPola()
        {
            Data.IsEnabled = false;
            DataOddania.IsEnabled = false;
            textBoxKto.IsReadOnly = true;
            textBoxMiejsce.IsReadOnly = true;
            textBoxZaCo.IsReadOnly = true;
            textBoxKwota.IsReadOnly = true;
            textBoxEmail.IsReadOnly = true;
            textBoxDodatkoweInfo.IsReadOnly = true;
        }

        internal void OdblokujPola()
        {
            Data.IsEnabled = true;
            DataOddania.IsEnabled = true;
            textBoxKto.IsReadOnly = false;
            textBoxMiejsce.IsReadOnly = false;
            textBoxZaCo.IsReadOnly = false;
            textBoxKwota.IsReadOnly = false;
            textBoxEmail.IsReadOnly = false;
            textBoxDodatkoweInfo.IsReadOnly = false;
        }

        internal void Wyczysc()
        {
            DataOddania.Date = null;
            textBoxKto.Text = "";
            textBoxMiejsce.Text = "";
            textBoxZaCo.Text = "";
            textBoxKwota.Text = "";
            textBoxEmail.Text = "";
            textBoxDodatkoweInfo.Text = "";
        }


        private bool ValidateData()
        {
            if (textBoxKto.Text == null || textBoxKto.Text == "")
                return true;
            if (textBoxZaCo.Text == null || textBoxZaCo.Text == "")
                return true;
            if (textBoxKwota.Text == null || textBoxKwota.Text == "")
                return true;
            try
            {
                Double.Parse(textBoxKwota.Text);
            }
            catch
            {
                return true;
            }
                     
            return false;
        }
        internal bool Zapis()
        {
            if (!ValidateData())
            {
                StringBuilder dane = new StringBuilder();
                dane.Append(GlobalVariables.ID.ToString()); //to bedzie OID
                dane.Append(';');
                dane.Append(Data.Date.ToString());
                dane.Append(';');
                dane.Append(DataOddania.Date.ToString());
                dane.Append(';');
                dane.Append(textBoxKto.Text);
                dane.Append(';');
                dane.Append(textBoxMiejsce.Text);
                dane.Append(';');
                dane.Append(textBoxZaCo.Text);
                dane.Append(';');
                dane.Append(textBoxKwota.Text);
                dane.Append(';');
                dane.Append(textBoxEmail.Text);
                dane.Append(';');
                dane.Append(textBoxDodatkoweInfo.Text);
                dane.Append(';');
                dane.Append("1"); // Status czy aktywne, przy dodawaniu zawsze bedzie 1
                dane.Append('\n');
                GlobalVariables.ZapiszDoPliku(dane.ToString());
                GlobalVariables.PodniesID();

                ObjWpis wpis = new ObjWpis()
                {
                    //ID = 1,   //niepodajemy bo automatycznie na bazie jest podnoszone
                    Aktywne = "1",  // Status czy aktywne, przy dodawaniu zawsze bedzie 1
                    Data = Data.Date.ToString(),
                    DataOddania = DataOddania.Date.ToString(),
                    DodatkoweInfo = textBoxDodatkoweInfo.Text,
                    Email = textBoxEmail.Text,
                    Kto = textBoxKto.Text,
                    Kwota = textBoxKwota.Text,
                    Miejsce = textBoxMiejsce.Text,
                    ZaCo = textBoxZaCo.Text
                    
                };

                if (!Database.Insert(wpis))
                    return false;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
