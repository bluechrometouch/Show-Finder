using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShowFinder.Models
{
    public class DiscoverTvShowsParameters
    {
        public string ApiKey { get; set; }

        public DateTime? airDateGte { get; set; }

        public DateTime? airDateLte { get; set; }

        [Display(Name = "Air Date >")]
        public DateTime? firstAirDateGte { get; set; }

        [Display(Name = "Air Date <")]
        public DateTime? firstAirDateLte { get; set; }

        [Display(Name = "Air Date Year")]
        public int? firstAirDateYear { get; set; }

        public string language { get; set; }

        public int? page { get; set; }

        public int? timezone { get; set; }

        [Display(Name = "Sort By")]
        public string sortBy { get; set; }

        [Display(Name = "Vote Count >")]
        [Range(0.0, float.MaxValue)]
        public int? voteCountGte { get; set; }

        [Display(Name = "Vote Average >")]
        public float? voteAverageGte { get; set; }

        public int[] withNetworks { get; set; }

        [Display(Name = "With Genres")]
        public int[] withGenres { get; set; }

        public string GetTmdbDiscoverTvShowsQueryString()
        {
            string Endpoint = "http://api.themoviedb.org/3/discover/tv";
            var builder = new UriBuilder(Endpoint);
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["api_key"] = ApiKey;
            if (airDateGte != null)
            {
                query["air_date.gte"] = airDateGte != null ? airDateGte.Value.ToString("yyyy-MM-dd") : null;
            }
            if (airDateLte != null)
            {
                query["air_date.lte"] = airDateLte != null ? airDateLte.Value.ToString("yyyy-MM-dd") : null;
            }
            if (firstAirDateGte != null)
            {
                query["first_air_date.gte"] = firstAirDateGte != null ? firstAirDateGte.Value.ToString("yyyy-MM-dd") : null;
            }
            if (firstAirDateLte != null)
            {
                query["first_air_date.lte"] = firstAirDateLte != null ? firstAirDateLte.Value.ToString("yyyy-MM-dd") : null;
            }
            if (firstAirDateYear != null)
            {
                query["first_air_date_year"] = firstAirDateYear.ToString();
            }
            if (language != "")
            {
                query["language"] = language;
            }
            if (page != null)
            {
                query["page"] = page.ToString();
            }
            if (timezone != null)
            {
                query["timezone"] = timezone.ToString();
            }
            if (sortBy != "")
            {
                query["sort_by"] = sortBy;
            }
            if (voteCountGte != null)
            {
                query["vote_count.gte"] = voteCountGte.ToString();
            }
            if (voteAverageGte != null)
            {
                query["vote_average.gte"] = voteAverageGte.ToString();
            }
            if (withNetworks != null)
            {
                query["with_networks"] = withNetworks.ToString();
            }
            if (withGenres != null)
            {
                string genreQuery = "";
                foreach (int item in withGenres)
                {
                    genreQuery += item.ToString() + ", ";
                }
                genreQuery = genreQuery.Remove(genreQuery.Length - 2, 2);
                query["with_genres"] = genreQuery;
            }

            builder.Query = query.ToString();
            return builder.ToString();
        }

        public static readonly SortedList<string, string> SortBy = new SortedList<string, string>
        {
            {"","" },
            {"popularity.desc", "Popularity Desc" },
            {"popularity.asc", "Popularity Asc" },
            {"vote_average.asc", "Vote Average Asc" },
            {"vote_average.desc", "Vote Average Desc" },
            {"first_air_date.desc", "First Air Date Desc" },
            {"first_air_date.asc", "First Air Date Asc" }
        };
    }
}
