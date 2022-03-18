using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using System.Collections.ObjectModel;
using SistemaNoleggi_UWP.Client;
using Windows.UI.Xaml.Navigation;

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina che mostra la lista di clienti nel sistema
    /// </summary>
    public sealed partial class ClientiPage : Page
    {
        public ClientiPage()
        {
            this.InitializeComponent();
            // Aggiorna l'interfaccia grafica per la lista dei clienti
            if (SistemaNoleggi.Instance.Clienti == null)
                return;
  
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var clienti = await SistemaNoleggiClient.Instance.GetAllClientiAsync();
            listViewClienti.ItemsSource = new ObservableCollection<Cliente>(clienti);
        }

        private async void removeCliente_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var cliente = (sender as Button).DataContext as Cliente; // Ricava il cliente presente nell'elemento grafico
            // Rimuovi il cliente e aggiorna la lista
            await SistemaNoleggiClient.Instance.RemoveClienteAsync(cliente.Id);
            var clienti = await SistemaNoleggiClient.Instance.GetAllClientiAsync();
            listViewClienti.ItemsSource = new ObservableCollection<Cliente>(clienti);
        }
    }
}
