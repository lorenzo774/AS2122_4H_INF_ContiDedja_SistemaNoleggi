using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using System;
using SistemaNoleggi_UWP.Client;

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina per aggiungere un nuovo noleggio
    /// </summary>
    public sealed partial class AddNoleggioPage : Page
    {
        public AddNoleggioPage()
        {
            this.InitializeComponent();
            // Assegnamento dell'item source delle combox per poter visualizzare la lista di clienti e di veicoli
            cmbClienti.ItemsSource = SistemaNoleggi.Instance.Clienti;
            cmbVeicoli.ItemsSource = SistemaNoleggi.Instance.Veicoli;
        }

        private void OnbtnSalva_Click(object sender, RoutedEventArgs e)
        {
            int durata;

            // Verifica input dell'utente
            if (cmbClienti.SelectedItem == null || !int.TryParse(txtboxDurata.Text, out durata) 
                || !(cmbClienti.SelectedItem is Cliente) || !(cmbVeicoli.SelectedItem is Veicolo) || datepickerData.Date.DateTime == null || DateTime.Now.CompareTo(datepickerData.Date.DateTime) > 0)
            {
                new ErrorDialog().Show();
                return;
            }

            // Aggiunta di un noleggio e ritorno alla Page precedente
            SistemaNoleggi.Instance.AggiungiNoleggio(datepickerData.Date.DateTime, durata, (Cliente)cmbClienti.SelectedItem, (Veicolo)cmbVeicoli.SelectedItem);
            Frame.GoBack();
        }

        private void OnbtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}