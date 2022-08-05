using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Whatcha_Watchin.Models;

namespace Whatcha_Watchin.ViewModels
{
    public class LibraryViewModel : INotifyPropertyChanged
    {
        private Library library;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<MediaViewModel> Medias { get; set; }

        public LibraryViewModel()
        {
            library = new Library();
            Medias = new ObservableCollection<MediaViewModel>();

            // Create new ViewModels for each media in the database
            foreach (var media in library.MediaList)
            {
                Medias.Add(new MediaViewModel(media));
            }

            // If movies are changed, let me know {?}
            Medias.CollectionChanged += Medias_CollectionChanged;
        }

        private void Medias_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var mediaViewModel = e.NewItems[0] as MediaViewModel;
                library.AddMedia(mediaViewModel.Model);
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                // Replace Action is not being triggered when items in list are replaced
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                var mediaViewModel = e.OldItems[0] as MediaViewModel;
                library.DeleteMedia(mediaViewModel.Model);
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            library = new Library();
        }
    }
}
