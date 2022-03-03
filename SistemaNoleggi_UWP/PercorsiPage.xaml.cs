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
using Noleggio_Library;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=234238

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class PercorsiPage : Page
    {
        public PercorsiPage()
        {
            this.InitializeComponent();
            txtboxClienti.Text = "Percorso: " + ResourceManager.Instance.PathClienti;
            txtboxVeicoli.Text = "Percorso: " + ResourceManager.Instance.PathVeicoli;
            txtboxNoleggi.Text = "Percorso: " + ResourceManager.Instance.PathNoleggi;
        }

        private void OnPercorsoClienti_Click(object sender, RoutedEventArgs e)
        {
            ResourceManager.Instance.LoadClienti();
        }

        private void OnPercorsoVeicoli_Click(object sender, RoutedEventArgs e)
        {
        }

        private void OnPercorsoNoleggi_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
