using Windows.UI.Xaml.Controls;
using Noleggio_Library;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=234238

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class VeicoliPage : Page
    {
        public VeicoliPage()
        {
            this.InitializeComponent();
            grdViewAutomobili.ItemsSource = SistemaNoleggi.Instance.Automobili;
            grdViewFurgoni.ItemsSource = SistemaNoleggi.Instance.Furgoni;
        }
    }
}
