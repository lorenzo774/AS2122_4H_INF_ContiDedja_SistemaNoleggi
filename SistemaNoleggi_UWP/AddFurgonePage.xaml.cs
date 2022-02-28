using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
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
