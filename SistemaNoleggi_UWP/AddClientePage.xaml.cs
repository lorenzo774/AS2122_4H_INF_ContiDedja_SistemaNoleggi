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

            Cliente = new Cliente(txtbox_Nome.Text, txtbox_Cognome.Text, txtbox_Cf.Text);
            
            Frame.Navigate(typeof(MainPage), Cliente);
        }

        private void OnbtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}