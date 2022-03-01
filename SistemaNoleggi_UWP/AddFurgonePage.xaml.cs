using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=234238

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class AddFurgonePage : Page
    {
        public AddFurgonePage()
        {
            this.InitializeComponent();
        }

        private void OnBtnSalva_Click(object sender, RoutedEventArgs e)
        {
            decimal costoVeicolo;
            decimal tariffaGiornaliera;
            int capacita;
            
            if(txtTarga.Text == "" || txtModello.Text == "" 
                || !decimal.TryParse(txtCostoVeicolo.Text, out costoVeicolo) || !decimal.TryParse(txtTariffa.Text, out tariffaGiornaliera)
                || !int.TryParse(txtCapacita.Text, out capacita))
            {
                new ErrorDialog().Show();
                return;
            }

            string targa = txtTarga.Text;
            string modello = txtModello.Text;

            SistemaNoleggi.Instance.AggiungiFurgone(targa, modello, costoVeicolo, tariffaGiornaliera, capacita);

            Frame.GoBack();
        }

        private void OnBtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
