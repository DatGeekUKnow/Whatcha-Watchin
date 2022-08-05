using System.Collections.Generic;

namespace Whatcha_Watchin.Models
{
    class Library
    {
        private List<Media> mediaList;
        public List<Media> MediaList
        {
            get
            {
                return mediaList;
            }
        }

        public Library()
        {
            mediaList = new List<Media>();
            BuildMediaList();
        }

        // helper function to add movies currently in the database to the mediaList
        private void BuildMediaList()
        {
            mediaList.Clear();

            // Create new ViewModels for each media in the database
            using (var db = new LibraryContext())
            {
                foreach (var media in db.Watch_Later)
                {
                    mediaList.Add(media);
                }
            }
        }

        public void AddMedia(Media newMedia)
        {
            using (var db = new LibraryContext())
            {
                try
                {
                    // Make sure duplicates are never added.
                    db.Watch_Later.Add(newMedia);

                    db.SaveChanges();

                    BuildMediaList();
                }
                catch { }

            }
        }

        public void DeleteMedia(Media media)
        {
            using (var db = new LibraryContext())
            {
                db.Watch_Later.Remove(media);
                db.SaveChanges();
                BuildMediaList();
            }
        }
    }
}
