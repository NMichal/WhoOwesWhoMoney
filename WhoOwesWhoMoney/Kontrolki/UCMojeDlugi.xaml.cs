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

namespace WhoOwesWhoMoney.Kontrolki
{
    public sealed partial class UCMojeDlugi : UserControl
    {
        public event DoubleTappedEventHandler DoubleTapped;
        internal ObjWpis WybranyWpis;

        public UCMojeDlugi()
        {
            this.InitializeComponent();
        }



        internal void PokazAktywneDlugi()
        {
            ////Jako że pisze długi to potem trzeba będze filtrować po kolumnie dlugi / pozyczka w DB
            //Na razie wyswietla wszyskie aktywne wpisy
            List<ObjWpis> aktywneWpisy;
            aktywneWpisy = Database.ListaAkrywnychWpisow();

            foreach (ObjWpis wpis in aktywneWpisy)
            {
                ListViewItem item = new ListViewItem();
                string nazwa = wpis.Kto + " - " + wpis.ZaCo + " - " + wpis.Kwota;
                item.Content = nazwa;
                item.Tag = wpis;


                listViewMojeDlugi.Items.Add(item);
            }
        }

        internal void Odswiez() /// Możliwe że ta funkcja bedzie nie potrzebna albo odswieżacnie po usubnięciu pozycji
        {

        }

        private void listViewMojeDlugi_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            WybranyWpis = (ObjWpis)((ListViewItem)listViewMojeDlugi.SelectedValue).Tag;
            if (WybranyWpis != null)
            {
                if (this.DoubleTapped != null)
                    this.DoubleTapped(this, e);

            }
        }
    }
}
