﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WhoOwesWhoMoney.Formatki
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormPozyczoneKomus : Page
    {
        public FormPozyczoneKomus()
        {
            this.InitializeComponent();
            UCMojeDlugi2.DoubleTapped += new DoubleTappedEventHandler(UserControl_DoubleTapped);
            UCMojeDlugi2.PokazAktywnePozyczoneKomus();
        }

        protected void UserControl_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            //Dorobic przekazywanie obiektu i jego wyswietlanie
            this.Frame.Navigate(typeof(Formatki.FormWpisPodglad), UCMojeDlugi2.WybranyWpis);
        }
    }
}