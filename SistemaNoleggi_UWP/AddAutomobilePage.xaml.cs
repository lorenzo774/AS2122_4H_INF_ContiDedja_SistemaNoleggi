using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;

namespace SistemaNoleggi_UWP
{
    public sealed partial class AddAutomobilePage : Page
    {
        public AddAutomobilePage()
        {
            this.InitializeComponent();
        }

        private void OnBtnSalva_Click(object sender, RoutedEventArgs e)
        {
            decimal costoVeicolo;
            decimal tariffaGiornaliera;
            int numeroPosti;

            if(txtTarga.Text == "" || txtModello.Text == "" 
                || !decimal.TryParse(txtCostoVeicolo.Text, out costoVeicolo) || !decimal.TryParse(txtTariffa.Text, out tariffaGiornaliera) 
                || !int.TryParse(txtNumeroPosti.Text, out numeroPosti))
            {
                new ErrorDialog().Show();
                return;
            }

            string targa = txtTarga.Text;
            string modello = txtModello.Text;

            SistemaNoleggi.Instance.AggiungiAutomobile(targa, modello, costoVeicolo, tariffaGiornaliera, numeroPosti);
            Frame.GoBack();
        }

        private void OnBtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}