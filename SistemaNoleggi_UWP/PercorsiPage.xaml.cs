using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SistemaNoleggi_UWP
{
    public sealed partial class PercorsiPage : Page
    {
        public PercorsiPage()   
        {
            this.InitializeComponent();
        }

        private void OnPercorsoClienti_Click(object sender, RoutedEventArgs e)
        {
            ResourceManager.Instance.LoadAsync(FileType.Cliente);
        }

        private void OnPercorsoVeicoli_Click(object sender, RoutedEventArgs e)
        {
            ResourceManager.Instance.LoadAsync(FileType.Veicolo);
        }

        private void OnPercorsoNoleggi_Click(object sender, RoutedEventArgs e)
        {
            ResourceManager.Instance.LoadAsync(FileType.Noleggio);
        }
    }
}
