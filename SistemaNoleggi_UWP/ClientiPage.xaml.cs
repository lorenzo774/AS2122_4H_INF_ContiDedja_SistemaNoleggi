using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using System.Collections.ObjectModel;

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class ClientiPage : Page
    {
        public ClientiPage()
        {
            this.InitializeComponent();
            listViewClienti.ItemsSource = new ObservableCollection<Cliente>(SistemaNoleggi.Instance.Clienti);
        }

        private void removeCliente_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var cliente = (sender as Button).DataContext as Cliente;
            SistemaNoleggi.Instance.RimuoviCliente(cliente);
            listViewClienti.ItemsSource = new ObservableCollection<Cliente>(SistemaNoleggi.Instance.Clienti);
        }
    }
}
