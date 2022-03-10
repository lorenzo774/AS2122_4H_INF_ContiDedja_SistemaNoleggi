using System; 
using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;

namespace SistemaNoleggi_UWP
{
    internal class ErrorDialog
    {
        private ContentDialog messageDialog;

        public ErrorDialog(string errorMsg = "Dati non validi, riprova")
        {
            messageDialog = new ContentDialog()
            {
                Title = "Errore",
                Content = errorMsg,
                CloseButtonText = "OK",
                Width = 100
            };
        }

        public async Task Show()
        {
            await messageDialog.ShowAsync();
        }
    }
}
