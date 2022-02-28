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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SistemaNoleggi sistemaNoleggi = e.Parameter as SistemaNoleggi;
            
            cmbClienti.ItemsSource = sistemaNoleggi.Clienti;
            cmbVeicoli.ItemsSource = sistemaNoleggi.Veicoli;
        }
    }
}