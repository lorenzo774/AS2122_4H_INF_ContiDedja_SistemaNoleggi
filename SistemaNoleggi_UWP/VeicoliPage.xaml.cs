using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using SistemaNoleggi_UWP.Client;
using System.Collections.ObjectModel;

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina che mostra la lista delle automobili e dei furgoni del sistema
    /// </summary>
    public sealed partial class VeicoliPage : Page
    {
        public VeicoliPage()
        {
            this.InitializeComponent();
            // Aggiorna l'interfaccia grafica per la lista dei furgoni e delle automobili
            if (SistemaNoleggi.Instance.Veicoli == null)
                return;

            listViewFurgoni.ItemsSource = SistemaNoleggi.Instance.Furgoni;
            listViewAutomobili.ItemsSource = SistemaNoleggi.Instance.Automobili;
        }

        private async void removeAutomobile_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var veicolo = (sender as Button).DataContext as Veicolo; // Ricava l'automobile (Veicolo) presente nell'elemento grafico
            SistemaNoleggi.Instance.RimuoviVeicolo(veicolo);
            // Aggiorna l'interfaccia grafica per la lista delle automobili
            if (SistemaNoleggi.Instance.Automobili == null)
            {
                ErrorDialog errorDialog = new ErrorDialog("Nessuna automobile");
                errorDialog.Show();
                return;
            }
            listViewAutomobili.ItemsSource = SistemaNoleggi.Instance.Automobili;
        }

        private async void removeFurgone_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var veicolo = (sender as Button).DataContext as Veicolo; // Ricava il furgone (Veicolo) presente nell'elemento grafico

            await SistemaNoleggiClient.Instance.RemoveFurgoneAsync(veicolo.Id);

            listViewFurgoni.ItemsSource = new ObservableCollection<Furgone>(await SistemaNoleggiClient.Instance.GetAllFurgoniAsync());

            //SistemaNoleggi.Instance.RimuoviVeicolo(veicolo);
            //// Aggiorna l'interfaccia grafica per la lista dei furgoni
            //if (SistemaNoleggi.Instance.Furgoni == null)
            //{
            //    ErrorDialog errorDialog = new ErrorDialog("Nessuna automobile");
            //    errorDialog.Show();
            //    return;
            //}
            //listViewFurgoni.ItemsSource = SistemaNoleggi.Instance.Furgoni;
        }

        private async void VeicoliPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var automobili = await SistemaNoleggiClient.Instance.GetAllAutomobiliAsync();
            listViewAutomobili.ItemsSource = new ObservableCollection<Automobile>(automobili);

            var furgoni = await SistemaNoleggiClient.Instance.GetAllFurgoniAsync();
            listViewFurgoni.ItemsSource = new ObservableCollection<Furgone>(furgoni);
        }
    }
}