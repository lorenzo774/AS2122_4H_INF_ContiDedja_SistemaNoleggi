using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using System;
using SistemaNoleggi_UWP.Client;
using Noleggio_Library.DTOs;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Navigation;

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
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            cmbClienti.ItemsSource = new ObservableCollection<Cliente>(await SistemaNoleggiClient.Instance.GetAllClientiAsync());
            cmbVeicoli.ItemsSource = new ObservableCollection<Veicolo>(SistemaNoleggi.Instance.Veicoli);
        }

        private async void OnbtnSalva_Click(object sender, RoutedEventArgs e)
        {
            int durata;

            // Verifica input dell'utente
            if (cmbClienti.SelectedItem == null || !int.TryParse(txtboxDurata.Text, out durata) 
                || !(cmbClienti.SelectedItem is Cliente) || !(cmbVeicoli.SelectedItem is Veicolo) || datepickerData.Date.DateTime == null || DateTime.Now.CompareTo(datepickerData.Date.DateTime) > 0)
            {
                new ErrorDialog().Show();
                return;
            }

            var cliente = (cmbClienti.SelectedItem as Cliente);
            var veicolo = (cmbVeicoli.SelectedItem as Veicolo);

            // Aggiunta di un noleggio e ritorno alla Page precedente
            // TODO: Integrarlo con il sistema sincronizza
            //SistemaNoleggi.Instance.AggiungiNoleggio(datepickerData.Date.DateTime, durata, (Cliente)cmbClienti.SelectedItem, (Veicolo)cmbVeicoli.SelectedItem);

            await SistemaNoleggiClient.Instance.AddNoleggioAsync(new NoleggioDTO()
            {
                DataInizio = datepickerData.Date.DateTime,
                DurataNoleggio = durata,
                ClienteId = cliente.Id,
                VeicoloId = veicolo.Id
            });
            
            Frame.GoBack();
        }

        private void OnbtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}