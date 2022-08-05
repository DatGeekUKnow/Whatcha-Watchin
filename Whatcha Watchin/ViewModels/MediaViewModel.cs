using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatcha_Watchin.Models;

namespace Whatcha_Watchin.ViewModels
{
    public class MediaViewModel
    {
        public string selectedProvider { get; set; }

        public MediaViewModel(Media media = null)
        {
            if (media == null)
            {
                media = new Media();
            }
            Model = media;
        }
        public Media Model { get; private set; }
        public string MediaId
        {
            get { return Model.imdbID; }
        }
        public string Title
        {
            get { return Model.title; }
        }
        public int Rating
        {
            get { return Model.imdbRating; }
        }
        public string Synopsis
        {
            get { return Model.overview; }
        }
        public int Year
        {
            get { return Model.year; }
        }
        public int Length
        {
            get { return Model.runtime; }
        }
        public string Poster
        {
            get { return Model.posterURLs.original; }
        }

        public async Task<Media> FetchMedia(bool isMovie, bool isSeries)
        {
            int num;
            Random rnd = new Random();
            API_Results results;

            if (isMovie && isSeries)
            {
                // Pick Random between movie or series
                num = rnd.Next(0, 2);
                results = (num == 1) ? await MediaFetcher.GetMedia(true, selectedProvider) : await MediaFetcher.GetMedia(false, selectedProvider);
            }
            else if (!isMovie && !isSeries)
            {
                // Return Null Media as error message, nothing is selected
                Model = new Media();
                return Model;
            }
            else
            {
                // Sends true if isMovie is true and false if it is false
                // True returns a movie, false returns a series
                results = await MediaFetcher.GetMedia(isMovie, selectedProvider);
            }

            int rando;
            rando = rnd.Next(0, results.results.Length);
            Model = results.results[rando];
            return Model;
        }
    }
}
