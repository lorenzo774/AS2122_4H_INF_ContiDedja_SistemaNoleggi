using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using System.Collections.ObjectModel;
using SistemaNoleggi_UWP.Client;
using Noleggio_Library.DTOs;
using Windows.UI.Xaml.Navigation;

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina che mostra la lista di noleggi nel sistema
    /// </summary>
    public sealed partial class NoleggiPage : Page
    {

        public NoleggiPage()
        {
            this.InitializeComponent();
            // Aggiorna l'interfaccia grafica per la lista dei noleggi
            if (SistemaNoleggi.Instance.Noleggi == null)
                return;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var noleggi = await SistemaNoleggiClient.Instance.GetAllNoleggiAsync();
            listViewNoleggi.ItemsSource = new ObservableCollection<Noleggio>(noleggi);
        }

        private async void removeNoleggio_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var noleggio = (sender as Button).DataContext as Noleggio; // Ricava il noleggio presente nell'elemento grafico
            await SistemaNoleggiClient.Instance.RemoveNoleggioAsync(noleggio.Id);
            listViewNoleggi.ItemsSource = new ObservableCollection<Noleggio>(await SistemaNoleggiClient.Instance.GetAllNoleggiAsync());
        }
    }
}
