using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using System;

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
            int durata;

            if(cmbClienti.SelectedItem == null || !int.TryParse(txtboxDurata.Text, out durata) 
                || !(cmbClienti.SelectedItem is Cliente) || !(cmbVeicoli.SelectedItem is Veicolo) || datepickerData.Date.DateTime == null || DateTime.Now.CompareTo(datepickerData.Date.DateTime) > 0)
            {
                new ErrorDialog().Show();
                return;
            }

            SistemaNoleggi.Instance.AggiungiNoleggio(datepickerData.Date.DateTime, durata, (Cliente)cmbClienti.SelectedItem, (Veicolo)cmbVeicoli.SelectedItem);
            Frame.GoBack();
        }

        private void OnbtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}