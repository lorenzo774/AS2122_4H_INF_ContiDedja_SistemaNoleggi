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