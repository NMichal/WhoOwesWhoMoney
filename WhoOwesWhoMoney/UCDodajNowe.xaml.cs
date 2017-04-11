using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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
            textBoxMiejsce.PlaceholderText = "Miejsce ... (opcjonalne)";
            textBoxZaCo.PlaceholderText = "Opis za co ...";
            DataOddania.PlaceholderText = "(opcjonalne)";
            Data.Date = DateTime.Now;
            
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



        internal void Zapis()
        {
            StringBuilder dane = new StringBuilder();
            dane.Append("1"); //to bedzie OID
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
            
        }
    }
}
