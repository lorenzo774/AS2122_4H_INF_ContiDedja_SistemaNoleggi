using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;


namespace SistemaNoleggi_UWP
{
    /// <summary>Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame</summary>
    public sealed partial class OptionPage : Page
    {
        public OptionPage()
        {
            this.InitializeComponent();
            checkBoxSincronizza.IsChecked = SistemaNoleggi.Instance.IsDatabaseSynchronized;
        }

        private void checkBoxSincronizza_Click(object sender, RoutedEventArgs e)
        {
            SistemaNoleggi.Instance.IsDatabaseSynchronized = (bool)checkBoxSincronizza.IsChecked;
        }
    }
}