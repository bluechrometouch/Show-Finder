using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShowFinder.Models
{
    public class DiscoverMoviesList
    {
        [Display(Name = "Page")]
        public int page { get; set; }

        public List<DiscoverMovies> results { get; set; }
        [Display(Name = "Total Pages")]
        public int total_pages { get; set; }

        [Display(Name = "Results")]
        public int total_results { get; set; }  

    }

    public class DiscoverMovies
    {
        [Display(Name = "Adult")]
        public bool adult { get; set; }

        public string backdrop_path { get; set; }

        public int[] genre_ids { get; set; }

        public int id { get; set; }

        [Display(Name = "Language")]
        public string original_language { get; set; }

        [Display(Name = "Original Title")]
        public string original_title { get; set; }

        [Display(Name = "Overview")]
        public string overview { get; set; }

        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? release_date { get; set; }

        public string poster_path { get; set; }

        [Display(Name = "Popularity")]
        public decimal popularity { get; set; }

        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Video")]
        public bool video { get; set; }

        [Display(Name = "Average User Score")]
        public float vote_average { get; set; }

        [Display(Name = "Vote Count")]
        public int vote_count { get; set; }

        [Display(Name = "Genres")]
        public List<string> genre
        {
            get
            {
                List<string> newGenre = new List<string>();

                foreach (int item in genre_ids)
                {
                    if (Genre.MovieGenres.ContainsKey(item))
                    {
                        newGenre.Add(Genre.MovieGenres[item]);
                    }
                };

                return newGenre;
            }
        }
    }

    public class DiscoverTvShowsList
    {
        [Display(Name = "Page")]
        public int page { get; set; }

        public List<DiscoverTvShows> results { get; set; }
        [Display(Name = "Total Pages")]
        public int total_pages { get; set; }

        [Display(Name = "Results")]
        public int total_results { get; set; }

    }

    public class DiscoverTvShows
    {
        public string backdrop_path { get; set; }

        public int[] genre_ids { get; set; }

        [Display(Name = "Country")]
        public string[] origin_country { get; set; }

        public int id { get; set; }

        [Display(Name = "Language")]
        public string original_language { get; set; }

        [Display(Name = "Original Name")]
        public string original_name { get; set; }

        [Display(Name = "Overview")]
        public string overview { get; set; }

        [Display(Name = "First Air Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? first_air_date { get; set; }

        public string poster_path { get; set; }

        [Display(Name = "Popularity")]
        public decimal popularity { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Average User Score")]
        public float vote_average { get; set; }

        [Display(Name = "Vote Count")]
        public int vote_count { get; set; }

        [Display(Name = "Genres")]
        public List<string> genre
        {
            get
            {
                List<string> newGenre = new List<string>();

                foreach (int item in genre_ids)
                {
                    if (Genre.TvShowGenres.ContainsKey(item))
                    {
                        newGenre.Add(Genre.TvShowGenres[item]);
                    }
                };

                return newGenre;
            }
        }
    }
}