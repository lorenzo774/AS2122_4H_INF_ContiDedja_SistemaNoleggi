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
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (SistemaNoleggi.Instance.IsDatabaseSynchronized)
            {
                SistemaNoleggi.Instance.Noleggi = await SistemaNoleggiClient.Instance.GetAllNoleggiAsync();
            }

            listViewNoleggi.ItemsSource = new ObservableCollection<Noleggio>(SistemaNoleggi.Instance.Noleggi);
        }

        private async void removeNoleggio_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var noleggio = (sender as Button).DataContext as Noleggio; // Ricava il noleggio presente nell'elemento grafico

            SistemaNoleggi.Instance.RimuoviNoleggio(noleggio);

            if (SistemaNoleggi.Instance.IsDatabaseSynchronized)
            {
                await SistemaNoleggiClient.Instance.RemoveNoleggioAsync(noleggio.Id);
            }

            listViewNoleggi.ItemsSource = new ObservableCollection<Noleggio>(SistemaNoleggi.Instance.Noleggi);
        }
    }
}