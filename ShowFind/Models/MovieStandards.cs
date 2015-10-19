using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowFinder.Models
{
    public class Genre
    {
        public static readonly SortedList<int, string> TvShowGenres = new SortedList<int, string>
        {
            {10759, "Action & Adventure"},
            {16, "Animation"},
            {35, "Comedy"},
            {99, "Documentary"},
            {18, "Drama"},
            {10751, "Family"},
            {10762, "Kids"},
            {9648, "Mystery"},
            {10763, "News"},
            {10764, "Reality"},
            {10765, "Sci-Fi & Fantasy"},
            {10766, "Soap"},
            {10767, "Talk"},
            {10768, "War & Politics"},
            {37, "Western"}
        };

        public static readonly SortedList<int, string> MovieGenres = new SortedList<int, string>
        {
            {28, "Action"},
            {12, "Adventure"},
            {16, "Animation"},
            {35, "Comedy"},
            {80, "Crime"},
            {99, "Documentary"},
            {18, "Drama"},
            {10751, "Family"},
            {14, "Fantasy"},
            {10769, "Foreign"},
            {36, "History"},
            {27, "Horror"},
            {10402, "Music"},
            {9648, "Mystery"},
            {10749, "Romance"},
            {878, "Science Fiction"},
            {10770, "TV Movie"},
            {53, "Thriller"},
            {10752, "War"},
            {37, "Western"}
        };
    }
}