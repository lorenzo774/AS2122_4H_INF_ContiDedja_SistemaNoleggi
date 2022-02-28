using Windows.UI.Xaml.Controls;
using Noleggio_Library;


namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class ClientiPage : Page
    {
        public ClientiPage()
        {
            this.InitializeComponent();
            grdView.ItemsSource = SistemaNoleggi.Instance.Clienti;
        }
    }
}
