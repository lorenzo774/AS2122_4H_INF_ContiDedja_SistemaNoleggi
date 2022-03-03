using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina per aggiungere un nuovo cliente
    /// </summary>
    public sealed partial class AddClientePage : Page
    {
        public AddClientePage()
        {
            this.InitializeComponent();
        }

        private void OnbtnSalva_Click(object sender, RoutedEventArgs e)
        {
            // Verifica input dell'utente
            if (txtbox_Nome.Text == "" || txtbox_Cognome.Text == "" || txtbox_Cf.Text == "")
            {
                new ErrorDialog().Show();
                return;
            }

            // Aggiunta di un cliente e ritorno alla Page precedente
            SistemaNoleggi.Instance.AggiungiCliente(txtbox_Nome.Text, txtbox_Cognome.Text, txtbox_Cf.Text);
            Frame.GoBack();
        }

        private void OnbtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}