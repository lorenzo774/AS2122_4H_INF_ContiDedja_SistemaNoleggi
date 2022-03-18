using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using Noleggio_Library.DTOs;
using SistemaNoleggi_UWP.Client;

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina per aggiungere una nuova automobile
    /// </summary>
    public sealed partial class AddAutomobilePage : Page
    {
        public AddAutomobilePage()
        {
            this.InitializeComponent();
        }

        private async void OnBtnSalva_Click(object sender, RoutedEventArgs e)
        {
            // Valori numerici da assegnare successivamente
            decimal costoVeicolo;
            decimal tariffaGiornaliera;
            int numeroPosti;

            // Verifica input dell'utente
            if(txtTarga.Text == "" || txtModello.Text == "" 
                || !decimal.TryParse(txtCostoVeicolo.Text, out costoVeicolo) || !decimal.TryParse(txtTariffa.Text, out tariffaGiornaliera) 
                || !int.TryParse(txtNumeroPosti.Text, out numeroPosti))
            {
                new ErrorDialog().Show();
                return;
            }

            string targa = txtTarga.Text;
            string modello = txtModello.Text;

            // Aggiunta di un automobile e ritorno alla Page precedente

            // TODO: Integrarlo con il sistema sincronizza
            //SistemaNoleggi.Instance.AggiungiAutomobile(targa, modello, costoVeicolo, tariffaGiornaliera, numeroPosti);

            await SistemaNoleggiClient.Instance.AddAutomobileAsync(new AutomobileDTO()
            {
                CostoVeicolo = costoVeicolo,
                Modello = modello,
                NumeroPosti = numeroPosti,
                Targa = targa,
                TariffaGiornaliera = tariffaGiornaliera
            });
            
            Frame.GoBack();
        }

        private void OnBtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}