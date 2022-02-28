using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Noleggio_Library;
using System;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=234238

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina usata dall'utente per l'inserimento di una nuova automobile
    /// </summary>
    public sealed partial class AddAutomobilePage : Page
    {

        public AddAutomobilePage()
        {
            this.InitializeComponent();
        }

        private void OnBtnSalva_Click(object sender, RoutedEventArgs e)
        {
            string targa = txtTarga.Text;
            string modello = txtModello.Text;
            decimal costoVeicolo = Convert.ToDecimal(txtCostoVeicolo.Text);
            decimal tariffaGiornaliera = Convert.ToDecimal(txtTariffa.Text);
            int numeroPosti = int.Parse(txtNumeroPosti.Text);

            SistemaNoleggi.Instance.AggiungiAutomobile(targa, modello, costoVeicolo, tariffaGiornaliera, numeroPosti);
            Frame.GoBack();
        }

        private void OnBtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
