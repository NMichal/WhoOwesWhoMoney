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
            textBoxEmail.PlaceholderText = "(opcjonalne)";
            textBoxKto.PlaceholderText = "Kto ...";
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
            checkBoxPozyczamKomus.IsEnabled = false;
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
            checkBoxPozyczamKomus.IsEnabled = true;
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


        internal bool ValidateData()
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

        internal void WyswietlWpis(ObjWpis wpis)
        {
            Data.Date = DateTime.Parse(wpis.Data);
            if (wpis.DataOddania != null && wpis.DataOddania != "")
                DataOddania.Date = DateTime.Parse(wpis.DataOddania);
            textBoxKto.Text = wpis.Kto;
            if (wpis.Miejsce != null && wpis.Miejsce != "")
                textBoxMiejsce.Text = wpis.Miejsce;
            textBoxZaCo.Text = wpis.ZaCo;
            textBoxKwota.Text = wpis.Kwota;
            if (wpis.Email != null && wpis.Email != "")
                textBoxEmail.Text = wpis.Email;
            if (wpis.DodatkoweInfo != null && wpis.DodatkoweInfo != "")
                textBoxDodatkoweInfo.Text = wpis.DodatkoweInfo;
            checkBoxPozyczamKomus.IsChecked =  Convert.ToBoolean(wpis.PokzyczamKomus);
        }

        /// <summary>
        /// Metoda która ponownie pobiera obiekt i aktualizuje go nowymi
        /// danymi z kontrolki.
        /// </summary>
        /// <returns>Zwraca zaktualizowany obiekt z danymi z kontrolki</returns>
        internal ObjWpis AktualizujWpis(ObjWpis wpis)
        {
            wpis.Data = Data.Date.ToString();
            wpis.DataOddania = DataOddania.Date.ToString();
            wpis.DodatkoweInfo = textBoxDodatkoweInfo.Text;
            wpis.Email = textBoxEmail.Text;
            wpis.Kto = textBoxKto.Text;
            wpis.Kwota = textBoxKwota.Text;
            wpis.Miejsce = textBoxMiejsce.Text;
            wpis.ZaCo = textBoxZaCo.Text;
            wpis.PokzyczamKomus = checkBoxPozyczamKomus.IsChecked.ToString();

            return wpis;
        }

        internal bool Zapis()
        {
            if (!ValidateData())
            {
                ObjWpis wpis = new ObjWpis()
                {                   
                    Aktywne = "1",
                    Data = Data.Date.ToString(),
                    DataOddania = DataOddania.Date.ToString(),
                    DodatkoweInfo = textBoxDodatkoweInfo.Text,
                    Email = textBoxEmail.Text,
                    Kto = textBoxKto.Text,
                    Kwota = textBoxKwota.Text,
                    Miejsce = textBoxMiejsce.Text,
                    ZaCo = textBoxZaCo.Text,
                    PokzyczamKomus = checkBoxPozyczamKomus.IsChecked.ToString()
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
