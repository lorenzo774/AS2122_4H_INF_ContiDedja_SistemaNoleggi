using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.IO;
using Noleggio_Library;

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina principale del programma
    /// </summary>
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

        // Nel momento in cui la view della NavigationBar viene caricata naviga nella pagina della lista Noleggi
        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(NoleggiPage));
        }

        // Chiamato quando viene cliccato un elemento della NavigationView
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {

            }
            else
            {
                // Naviga in una page in base all'elemento selezionato (cliccato) nella NavigationView
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