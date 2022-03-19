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
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (SistemaNoleggi.Instance.IsDatabaseSynchronized)
            {
                SistemaNoleggi.Instance.Clienti = await SistemaNoleggiClient.Instance.GetAllClientiAsync();
            }
            
            listViewClienti.ItemsSource = new ObservableCollection<Cliente>(SistemaNoleggi.Instance.Clienti);
        }

        private async void removeCliente_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var cliente = (sender as Button).DataContext as Cliente; // Ricava il cliente presente nell'elemento grafico

            // Rimuovi il cliente e aggiorna la lista

            SistemaNoleggi.Instance.RimuoviCliente(cliente);

            if (SistemaNoleggi.Instance.IsDatabaseSynchronized)
            {
                await SistemaNoleggiClient.Instance.RemoveClienteAsync(cliente.Id);
                SistemaNoleggi.Instance.Clienti = await SistemaNoleggiClient.Instance.GetAllClientiAsync();
            }

            listViewClienti.ItemsSource = new ObservableCollection<Cliente>(SistemaNoleggi.Instance.Clienti);
        }
    }
}