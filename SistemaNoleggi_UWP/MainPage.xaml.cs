using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.IO;
using System;
using System.Collections.Generic;
using Noleggio_Library;

namespace SistemaNoleggi_UWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        #region MenuBar buttons

        private void OnClienteMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddClientePage));
        }

        private void OnAutomobileMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddAutomobilePage));
        }

        private void OnFurgoneMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddFurgonePage));
        }
        
        private void OnNoleggioMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddNoleggioPage));
        }
        


        private void OnCsvFileSalva_Click(object sender, RoutedEventArgs e)
        {
            ResourceManager.Instance.Refresh(PathType.Cliente);
        }

        private void OnCsvFileAggiorna_Click(object sender, RoutedEventArgs e)
        {
            ResourceManager.Instance.Refresh(PathType.Cliente);
        }

        private void OnCsvFileCarica_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(PercorsiPage));
        }
        #endregion

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(NoleggiPage));
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {

            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                switch (item.Tag.ToString())
                {
                    case "noleggi":
                        ContentFrame.Navigate(typeof(NoleggiPage));
                        break;
                    case "clienti":
                        ContentFrame.Navigate(typeof(ClientiPage));
                        break;
                    case "veicoli":
                        ContentFrame.Navigate(typeof(VeicoliPage));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}