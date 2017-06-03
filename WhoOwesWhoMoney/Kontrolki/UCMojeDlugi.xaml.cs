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



        internal void PokazAktywneWpisyOdKogos()
        {
            List<ObjWpis> aktywneWpisyOdKogos;
            aktywneWpisyOdKogos = Database.ListaAkrywnychWpisowOdKogos();

            foreach (ObjWpis wpis in aktywneWpisyOdKogos)
            {
                ListViewItem item = new ListViewItem();
                string nazwa = wpis.Kto + " - " + wpis.ZaCo + " - " + wpis.Kwota;
                item.Content = nazwa;
                item.Tag = wpis;

                listViewMojeDlugi.Items.Add(item);
            }
        }

        internal void PokazAktywnePozyczoneKomus()
        {
            List<ObjWpis> pozyczoneKomus;
            pozyczoneKomus = Database.ListaAkrywnychWpisowPozyczonychKomus();

            foreach (ObjWpis wpis in pozyczoneKomus)
            {
                ListViewItem item = new ListViewItem();
                string nazwa = wpis.Kto + " - " + wpis.ZaCo + " - " + wpis.Kwota;
                item.Content = nazwa;
                item.Tag = wpis;

                listViewMojeDlugi.Items.Add(item);
            }
        }

        private void listViewMojeDlugi_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (listViewMojeDlugi.SelectedValue != null)
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
}
