﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.UI;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x410

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SistemaNoleggi sistemaNoleggi;

        public MainPage()
        {
            this.InitializeComponent();

            sistemaNoleggi = new SistemaNoleggi();
            sistemaNoleggi.AggiungiAutomobile("al;kf", "nope", 23, 22, 4);
            sistemaNoleggi.AggiungiCliente("lollo", "conti", "a;lksdjf");
            sistemaNoleggi.AggiungiNoleggio("al;kf", "a;lksdjf", 1, DateTime.Now);
            sistemaNoleggi.AggiungiNoleggio("al;kf", "a;lksdjf", 1, DateTime.Now);
        }

        private void OnClienteMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddClientePage));
        }

        private void OnAutomobileMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddAutomobilePage));
        }
    }
}
