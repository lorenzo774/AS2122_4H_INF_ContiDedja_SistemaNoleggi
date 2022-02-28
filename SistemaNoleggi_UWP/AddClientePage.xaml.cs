using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using Windows.UI.Popups;

namespace SistemaNoleggi_UWP
{
    public sealed partial class AddClientePage : Page
    {
        public Cliente Cliente { get; private set; }

        public AddClientePage()
        {
            this.InitializeComponent();
        }

        private void OnbtnSalva_Click(object sender, RoutedEventArgs e)
        {
            if (txtbox_Nome.Text == "" || txtbox_Cognome.Text == "" || txtbox_Cf.Text == "")
            {
                MessageDialog messageDialog = new MessageDialog("Ok");
                return;
            }

            SistemaNoleggi.Instance.AggiungiCliente(txtbox_Nome.Text, txtbox_Cognome.Text, txtbox_Cf.Text);

            Frame.GoBack();
        }

        private void OnbtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}