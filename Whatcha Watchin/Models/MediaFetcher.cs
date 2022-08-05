using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Whatcha_Watchin.Models
{
    class MediaFetcher
    {
        public static async Task<API_Results> GetMedia(bool isMovie, string selectedProvider)
        {
            string type;
            Uri requestUrl;
            Random rnd = new Random();
            const string country = "us";
            const string language = "en";
            string service = selectedProvider;
            const string output_language = "en";
            const string apiKey = {API_KEY};
            const string baseUrl = "https://streaming-availability.p.rapidapi.com/search/basic?";
            int page = 0;

            if (isMovie)
                type = "movie";
            else
                type = "series";

            // remove line to actually use api
            //return new MovieCollection();

            if (isMovie)
                requestUrl = new Uri($"{baseUrl}country={country}&service={service}&type={type}&output_language={output_language}&language={language}&rapidapi-key={apiKey}");
            else
                requestUrl = new Uri($"{baseUrl}country={country}&service={service}&type={type}&output_language={output_language}&language={language}&rapidapi-key={apiKey}");
            
            API_Results media;

            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(requestUrl);
                media = JsonConvert.DeserializeObject<API_Results>(json);
                page = rnd.Next(1, media.total_pages);
            }

            if (isMovie)
                requestUrl = new Uri($"{baseUrl}country={country}&service={service}&type={type}&page={page}&output_language={output_language}&language={language}&rapidapi-key={apiKey}");
            else
                requestUrl = new Uri($"{baseUrl}country={country}&service={service}&type={type}&page={page}&output_language={output_language}&language={language}&rapidapi-key={apiKey}");

            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(requestUrl);
                media = JsonConvert.DeserializeObject<API_Results>(json);
            }

            return media;
        }
    }
}
