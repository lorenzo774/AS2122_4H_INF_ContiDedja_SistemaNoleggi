using System;
using Windows.UI.Xaml.Controls;

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

        public async void Show()
        {
            await messageDialog.ShowAsync();
        }
    }
}
