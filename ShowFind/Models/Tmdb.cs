using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ShowFinder.Models
{
    public class Tmdb
    {

        const string Site = "http://api.themoviedb.org/";
        public const string ApiKey = "d584b7e6dd27e51b0873f2318034f87a";

        public DiscoverMoviesList DiscoverMovies(string parameter)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(parameter).Result;
            var responseData = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<DiscoverMoviesList>(responseData);
            
            return result;
        }

        public DiscoverTvShowsList DiscoverTvShows(string parameter)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(parameter).Result;
            var responseData = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<DiscoverTvShowsList>(responseData);

            return result;
        }
    }
}