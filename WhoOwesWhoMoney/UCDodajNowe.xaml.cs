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
        }
    }
}
