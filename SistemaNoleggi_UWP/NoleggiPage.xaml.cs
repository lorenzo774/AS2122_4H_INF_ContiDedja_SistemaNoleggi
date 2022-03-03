using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using System.Collections.ObjectModel;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=234238

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class NoleggiPage : Page
    {

        public NoleggiPage()
        {
            this.InitializeComponent();
            listViewNoleggi.ItemsSource = new ObservableCollection<Noleggio>(SistemaNoleggi.Instance.Noleggi);
        }

        private void removeNoleggio_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var noleggio = (sender as Button).DataContext as Noleggio;
            SistemaNoleggi.Instance.RimuoviNoleggio(noleggio);
            listViewNoleggi.ItemsSource = new ObservableCollection<Noleggio>(SistemaNoleggi.Instance.Noleggi);
        }
    }
}
