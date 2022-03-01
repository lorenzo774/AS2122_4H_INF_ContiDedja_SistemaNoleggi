using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;

namespace SistemaNoleggi_UWP
{
    public sealed partial class AddClientePage : Page
    {
        public AddClientePage()
        {
            this.InitializeComponent();
        }

        private void OnbtnSalva_Click(object sender, RoutedEventArgs e)
        {
            if (txtbox_Nome.Text == "" || txtbox_Cognome.Text == "" || txtbox_Cf.Text == "")
            {
                new ErrorDialog().Show();
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