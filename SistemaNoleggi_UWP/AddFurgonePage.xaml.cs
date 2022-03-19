using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using SistemaNoleggi_UWP.Client;
using Noleggio_Library.DTOs;

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina per aggiungere un nuovo furgone
    /// </summary>
    public sealed partial class AddFurgonePage : Page
    {
        public AddFurgonePage()
        {
            this.InitializeComponent();
        }

        private async void OnBtnSalva_Click(object sender, RoutedEventArgs e)
        {
            // Valori numerici da assegnare successivamente
            decimal costoVeicolo;
            decimal tariffaGiornaliera;
            int capacita;

            // Verifica input dell'utente
            if (txtTarga.Text == "" || txtModello.Text == "" 
                || !decimal.TryParse(txtCostoVeicolo.Text, out costoVeicolo) || !decimal.TryParse(txtTariffa.Text, out tariffaGiornaliera)
                || !int.TryParse(txtCapacita.Text, out capacita))
            {
                new ErrorDialog().Show();
                return;
            }

            string targa = txtTarga.Text;
            string modello = txtModello.Text;

            // Aggiunta di un furgone e ritorno alla Page precedente
            SistemaNoleggi.Instance.AggiungiFurgone(targa, modello, costoVeicolo, tariffaGiornaliera, capacita);

            if (SistemaNoleggi.Instance.IsDatabaseSynchronized)
            {
                await SistemaNoleggiClient.Instance.AddFurgoneAsync(new FurgoneDTO()
                {
                    Capacita = capacita,
                    CostoVeicolo = costoVeicolo,
                    Modello = modello,
                    Targa = targa,
                    TariffaGiornaliera = tariffaGiornaliera
                });
            }
            
            Frame.GoBack();
        }

        private void OnBtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
