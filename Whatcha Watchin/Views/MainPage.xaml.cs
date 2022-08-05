using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
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
using Whatcha_Watchin.ViewModels;
using Whatcha_Watchin.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Whatcha_Watchin
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly MediaViewModel media;
        private LibraryViewModel library;
        
        public MainPage()
        {
            InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;

            library = new LibraryViewModel();
            media = new MediaViewModel();
            Description.Text = "No Media Avaliable";
            ResultsInfo.Visibility = Visibility.Collapsed;
            DescriptionText.Visibility = Visibility.Collapsed;
            moreMenuOpened.Visibility = Visibility.Collapsed;
            buttonCloseMenu.Visibility = Visibility.Collapsed;
            buttonAbout.Visibility = Visibility.Collapsed;
            buttonOpenMenu.Visibility = Visibility.Visible;
            ResultsBorder.Margin = new Thickness(50, 0, 70, 0);
            media.selectedProvider = "netflix";
        }

        private async void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            _ = await media.FetchMedia((bool)CheckBoxMovie.IsChecked, (bool)CheckBoxSeries.IsChecked);

            if (media.MediaId == null)
            {
                // Send Error message
                Description.Text = "No Media Avaliable";
                ResultsInfo.Visibility = Visibility.Collapsed;
                DescriptionText.Visibility = Visibility.Collapsed;
            }
            else
            {
                Results.DataContext = null;
                Description.Text = "Description";
                ResultsInfo.Visibility = Visibility.Visible;
                DescriptionText.Visibility = Visibility.Visible;
                Results.DataContext = media;
            }
        }

        private void buttonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            moreMenuOpened.Visibility = Visibility.Collapsed;
            buttonCloseMenu.Visibility = Visibility.Collapsed;
            buttonAbout.Visibility = Visibility.Collapsed;
            buttonOpenMenu.Visibility = Visibility.Visible;
            ResultsBorder.Margin = new Thickness(50, 0, 70, 0);
        }

        private void buttonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            moreMenuOpened.Visibility = Visibility.Visible;
            buttonCloseMenu.Visibility = Visibility.Visible;
            buttonAbout.Visibility = Visibility.Visible;
            buttonOpenMenu.Visibility = Visibility.Collapsed;
            ResultsBorder.Margin = new Thickness(210, 0, 70, 0);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                String Parameter = (String)e.Parameter;
                media.selectedProvider = Parameter;
            }
        }

        private void buttonProvider_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Whatcha_Watchin.Views.Providers));
        }

        private void buttonLists_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListsPage));
        }

        private void buttonaddToWatchLater_Click(object sender, RoutedEventArgs e)
        {
            library.Medias.Add(media);
        }

        private void buttonAbout_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Whatcha_Watchin.Views.About));
        }
    }
}
