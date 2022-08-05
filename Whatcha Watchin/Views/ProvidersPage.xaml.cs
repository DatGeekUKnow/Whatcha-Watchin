using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Whatcha_Watchin.Views
{
    public sealed partial class Providers : Page
    {
        public Providers()
        {
            this.InitializeComponent();
        }

        private void hbo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), "hbo");
        }

        private void disney_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), "disney");
        }

        private void netlfix_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), "netflix");
        }

        private void hulu_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), "hulu");

        }
    }
}
