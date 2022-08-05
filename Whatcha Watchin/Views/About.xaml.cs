using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Whatcha_Watchin.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class About : Page
    {
        public About()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }
    }
}
