using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using System.Collections.ObjectModel;
using SistemaNoleggi_UWP.Client;

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

        private void removeCliente_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var cliente = (sender as Button).DataContext as Cliente; // Ricava il cliente presente nell'elemento grafico
            
            SistemaNoleggi.Instance.RimuoviCliente(cliente);
            
            listViewClienti.ItemsSource = new ObservableCollection<Cliente>(SistemaNoleggi.Instance.Clienti);
        }

        private async void ClientiPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var clienti = SistemaNoleggi.Instance.Clienti;
            
            if (SistemaNoleggi.Instance.IsDatabaseSynchronized)
            {
                clienti = await SistemaNoleggiClient.Instance.GetAllClientiAsync();
            }

            listViewClienti.ItemsSource = new ObservableCollection<Cliente>(clienti);
        }
    }
}