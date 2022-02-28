using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Noleggio_Library;

namespace SistemaNoleggi_UWP
{
    public sealed partial class AddNoleggioPage : Page
    {
        public AddNoleggioPage()
        {
            this.InitializeComponent();
            cmbClienti.ItemsSource = SistemaNoleggi.Instance.Clienti;
            cmbVeicoli.ItemsSource = SistemaNoleggi.Instance.Veicoli;
        }

        private void OnbtnSalva_Click(object sender, RoutedEventArgs e)
        {
            SistemaNoleggi.Instance.AggiungiNoleggio(datepickerData.Date.DateTime, int.Parse(txtboxDurata.Text), (Cliente)cmbClienti.SelectedItem, (Veicolo)cmbVeicoli.SelectedItem);

            Frame.GoBack();
        }

        private void OnbtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}