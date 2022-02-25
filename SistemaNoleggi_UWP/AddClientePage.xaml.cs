using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Noleggio_Library;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Popups;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=234238

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class AddClientePage : Page
    {
        public Cliente Cliente { get; private set; }

        public AddClientePage()
        {
            this.InitializeComponent();
            
            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
        }

        private void btn_Save(object sender, RoutedEventArgs e)
        {
            if (txtbox_Nome.Text == "" || txtbox_Cognome.Text == "" || txtbox_Cf.Text == "")
            {
                MessageDialog messageDialog = new MessageDialog("Ok");
                return;
            }

            Cliente = new Cliente(txtbox_Nome.Text, txtbox_Cognome.Text, txtbox_Cf.Text);
        }
    }
}