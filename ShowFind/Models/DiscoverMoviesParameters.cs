using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web;

namespace ShowFinder.Models
{
    public class DiscoverMoviesParameters
    {
        public string ApiKey { get; set; }

        [Display(Name = "Country Rated")]
        public string certificationCountry { get; set; }

        [Display(Name = "Rated")]
        public string certification { get; set; }

        [Display(Name = "Rated <")]
        public string certificationLte { get; set; }

        public bool? includeAdult { get; set; }

        public bool? includeVideo { get; set; }

        [Display(Name = "Language")]
        public string language { get; set; }

        public int? page { get; set; }

        [Display(Name = "Release Year")]
        public int? primaryReleaseYear { get; set; }

        [Display(Name = "Release Date >")]
        public DateTime? primaryReleaseDateGte { get; set; }

        [Display(Name = "Release Date <")]
        public DateTime? primaryReleaseDateLte { get; set; }

        public DateTime? releaseDateGte { get; set; }

        public DateTime? releaseDateLte { get; set; }

        [Display(Name = "Sort By")]
        public string sortBy { get; set; }

        [Display(Name = "Vote Count >")]
        [Range(0.0, float.MaxValue)]
        public int? voteCountGte { get; set; }

        [Display(Name = "Vote Count <")]
        [Range(0.0, float.MaxValue)]
        public int? voteCountLte { get; set; }

        [Display(Name = "Vote Average >")]
        public float? voteAverageGte { get; set; }

        [Display(Name = "Vote Average <")]
        public float? voteAverageLte { get; set; }

        public string withCast { get; set; }

        public string withCrew { get; set; }

        public string withCompanies { get; set; }

        [Display(Name = "With Genres")]
        public int[] withGenres { get; set; }

        public string withKeywords { get; set; }

        public string withPeople { get; set; }
        
        public int? year { get; set; }

        public string GetTmdbDiscoverMoviesQueryString()
        {
            string Endpoint = "https://api.themoviedb.org/3/discover/movie";
            var builder = new UriBuilder(Endpoint);
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["api_key"] = ApiKey;
            if (certificationCountry != "")
            {
                query["certification_country"] = certificationCountry;
            }
            if (certificationLte != "" || certificationCountry != "")
            {
                query["certification"] = certification;
            }
            if (certificationLte != "" || certificationCountry != "")
            {
                query["certification.lte"] = certificationLte;
            }
            if (includeAdult != null)
            {
                query["include_adult"] = includeAdult.ToString();
            }
            if (includeVideo != null)
            {
                query["include_video"] = includeVideo.ToString();
            }
            if (language != "")
            {
                query["language"] = language;
            }
            if (page != null)
            {
                query["page"] = page.ToString();
            }
            if (primaryReleaseYear != null)
            {
                query["primary_release_year"] = primaryReleaseYear.ToString();
            }
            if (primaryReleaseDateGte != null)
            {
                query["primary_release_date.gte"] = primaryReleaseDateGte != null ? primaryReleaseDateGte.Value.ToString("yyyy-MM-dd") : null;
            }
            if (primaryReleaseDateLte != null)
            {
                query["primary_release_date.lte"] = primaryReleaseDateLte != null ? primaryReleaseDateLte.Value.ToString("yyyy-MM-dd") : null;
            }
            if (releaseDateGte != null)
            {
                query["release_date.gte"] = releaseDateGte != null ? releaseDateGte.Value.ToString("yyyy-MM-dd") : null;
            }
            if (releaseDateLte != null)
            {
                query["release_date.lte"] = releaseDateLte != null ? releaseDateLte.Value.ToString("yyyy-MM-dd") : null;
            }
            if (sortBy != "")
            {
                query["sort_by"] = sortBy;
            }
            if (voteCountGte != null)
            {
                query["vote_count.gte"] = voteCountGte.ToString();
            }
            if (voteCountLte != null)
            {
                query["vote_count.lte"] = voteCountLte.ToString();
            }
            if (voteAverageGte != null)
            {
                query["vote_average.gte"] = voteAverageGte.ToString();
            }
            if (voteAverageLte != null)
            {
                query["vote_average.lte"] = voteAverageLte.ToString();
            }
            if (withCast != "")
            {
                query["with_cast"] = withCast;
            }
            if (withCrew != "")
            {
                query["with_crew"] = withCrew;
            }
            if (withCompanies != "")
            {
                query["with_companies"] = withCompanies;
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
            if (withKeywords != "")
            {
                query["with_keywords"] = withKeywords;
            }
            if (withPeople != "")
            {
                query["with_people"] = withPeople;
            }
            if (year != null)
            {
                query["year"] = year.ToString();
            }

            builder.Query = query.ToString();
            return builder.ToString();
        }

        public static readonly SortedList<string, string> SortBy = new SortedList<string, string>
        {
            {"","" },
            {"popularity.desc", "Popularity Desc" },
            {"popularity.asc", "Popularity Asc" },
            {"release_date.desc", "Release Date Desc" },
            {"release_date.asc", "Release Date Asc" },
            {"revenue.asc", "Revenue Asc" },
            {"revenue.desc", "Revenue Desc" },
            {"primary_release_date.asc", "Primary Release Date Asc"},
            {"primary_release_date.desc", "Primary Release Date Desc" },
            {"original_title.asc", "Original Title Asc"},
            {"original_title.desc", "Original Title Desc" },
            {"vote_average.asc", "Vote Average Asc" },
            {"vote_average.desc", "Vote Average Desc" },
            {"vote_count.asc", "Vote Count Asc" },
            {"vote_count.desc", "Vote Count Desc" }
        };
    }
}