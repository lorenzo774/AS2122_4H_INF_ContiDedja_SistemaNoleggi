using System;
using Windows.UI.Xaml.Controls;

namespace SistemaNoleggi_UWP
{
    internal class ErrorDialog
    {
        private ContentDialog messageDialog;

        public ErrorDialog()
        {
            messageDialog = new ContentDialog()
            {
                Title = "Errore",
                Content = "Inserisci dati validi",
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
