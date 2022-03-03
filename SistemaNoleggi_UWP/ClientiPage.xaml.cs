using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using System.Collections.ObjectModel;

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
            listViewClienti.ItemsSource = new ObservableCollection<Cliente>(SistemaNoleggi.Instance.Clienti);
        }

        private void removeCliente_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var cliente = (sender as Button).DataContext as Cliente; // Ricava il cliente presente nell'elemento grafico
            // Rimuovi il cliente e aggiorna la lista
            SistemaNoleggi.Instance.RimuoviCliente(cliente);
            listViewClienti.ItemsSource = new ObservableCollection<Cliente>(SistemaNoleggi.Instance.Clienti);
        }
    }
}
