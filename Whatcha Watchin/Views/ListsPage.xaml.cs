using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Whatcha_Watchin.ViewModels
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListsPage : Page
    {
        public LibraryViewModel Library { get; set; }
        public ListsPage()
        {
            InitializeComponent();
            Library = new LibraryViewModel();
            DataContext = Library;
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        private void buttonWatchLater_Click(object sender, RoutedEventArgs e)
        {
            //Library.isHistory = false;
        }

        private void buttonWatched_Click(object sender, RoutedEventArgs e)
        {
            //Library.isHistory = true;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
