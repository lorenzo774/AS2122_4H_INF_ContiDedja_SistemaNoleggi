using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;

namespace SistemaNoleggi_UWP
{
    public sealed partial class AddFurgonePage : Page
    {
        public AddFurgonePage()
        {
            this.InitializeComponent();
        }

        private void OnBtnSalva_Click(object sender, RoutedEventArgs e)
        {
            string targa = txtTarga.Text;
            string modello = txtModello.Text;
            decimal costoVeicolo = Convert.ToDecimal(txtCostoVeicolo.Text);
            decimal tariffaGiornaliera = Convert.ToDecimal(txtTariffa.Text);
            int capacita = int.Parse(txtCapacita.Text);

            SistemaNoleggi.Instance.AggiungiFurgone(targa, modello, costoVeicolo, tariffaGiornaliera, capacita);

            Frame.GoBack();
        }

        private void OnBtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}