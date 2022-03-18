using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using System.Collections.ObjectModel;
using SistemaNoleggi_UWP.Client;

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
        }

        private async void removeNoleggio_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var noleggio = (sender as Button).DataContext as Noleggio; // Ricava il noleggio presente nell'elemento grafico

            await SistemaNoleggiClient.Instance.RemoveNoleggioAsync(noleggio.Id);

            listViewNoleggi.ItemsSource = new ObservableCollection<Noleggio>(await SistemaNoleggiClient.Instance.GetAllNoleggiAsync());
        }

        private async void NoleggiPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var noleggi = SistemaNoleggi.Instance.Noleggi;

            if (SistemaNoleggi.Instance.IsDatabaseSynchronized)
            {
                noleggi = await SistemaNoleggiClient.Instance.GetAllNoleggiAsync();
            }
            
            listViewNoleggi.ItemsSource = new ObservableCollection<Noleggio>(noleggi);
        }
    }
}