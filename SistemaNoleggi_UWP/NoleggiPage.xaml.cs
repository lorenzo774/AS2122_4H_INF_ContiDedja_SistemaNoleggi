using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using System.Collections.ObjectModel;


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
            listViewNoleggi.ItemsSource = new ObservableCollection<Noleggio>(SistemaNoleggi.Instance.Noleggi);
        }

        private void removeNoleggio_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var noleggio = (sender as Button).DataContext as Noleggio; // Ricava il noleggio presente nell'elemento grafico
            SistemaNoleggi.Instance.RimuoviNoleggio(noleggio);
            // Aggiorna l'interfaccia grafica per la lista dei noleggi
            listViewNoleggi.ItemsSource = new ObservableCollection<Noleggio>(SistemaNoleggi.Instance.Noleggi);
        }
    }
}
