using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using Windows.UI.Xaml;
using Windows.UI.Popups;

namespace SistemaNoleggi_UWP
{
    public sealed partial class VeicoliPage : Page
    {
        public VeicoliPage()
        {
            this.InitializeComponent();

            listViewFurgoni.ItemsSource = SistemaNoleggi.Instance.Furgoni;
            listViewAutomobili.ItemsSource = SistemaNoleggi.Instance.Automobili;
        }

        private void removeAutomobile_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var veicolo = (sender as Button).DataContext as Veicolo;
            SistemaNoleggi.Instance.RimuoviVeicolo(veicolo);
            listViewAutomobili.ItemsSource = SistemaNoleggi.Instance.Automobili;
        }

        private void removeFurgone_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var veicolo = (sender as Button).DataContext as Veicolo;
            SistemaNoleggi.Instance.RimuoviVeicolo(veicolo);
            listViewFurgoni.ItemsSource = SistemaNoleggi.Instance.Furgoni;
        }
    }
}