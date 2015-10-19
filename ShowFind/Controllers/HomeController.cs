using ShowFinder.Models;
using ShowFinder.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace ShowFind.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Movies");
        }

        public ActionResult Movies()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Movies(DiscoverMoviesParameters model)
        {
            model.ApiKey = Tmdb.ApiKey;
            model.page = 1;
            Session["currentMovieSearch"] = model;

            var queryResult = model.GetTmdbDiscoverMoviesQueryString();
            var tmdb = new Tmdb();
            var movieResults = tmdb.DiscoverMovies(queryResult);

            return View("MovieList", movieResults);
        }

        public ActionResult MovieList(int? id)
        {
            if (Session["currentMovieSearch"] == null || id == null)
            {
                return Redirect("Movies");
            }
            DiscoverMoviesParameters model = Session["currentMovieSearch"] as DiscoverMoviesParameters;
            model.page = id;

            var queryResult = model.GetTmdbDiscoverMoviesQueryString();
            var tmdb = new Tmdb();
            var movieResults = tmdb.DiscoverMovies(queryResult);

            return View("MovieList", movieResults);
        }

        public ActionResult Tv()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Tv(DiscoverTvShowsParameters model)
        {
            model.ApiKey = Tmdb.ApiKey;
            model.page = 1;
            Session["currentTvSearch"] = model;

            var queryResult = model.GetTmdbDiscoverTvShowsQueryString();
            var tmdb = new Tmdb();
            var tvShowResults = tmdb.DiscoverTvShows(queryResult);

            return View("TvList", tvShowResults);

        }

        public ActionResult TvList(int? id)
        {
            if (Session["currentTvSearch"] == null || id == null)
            {
                return Redirect("Tv");
            }
            DiscoverTvShowsParameters model = Session["currentTvSearch"] as DiscoverTvShowsParameters;
            model.page = id;

            var queryResult = model.GetTmdbDiscoverTvShowsQueryString();
            var tmdb = new Tmdb();
            var tvShowResults = tmdb.DiscoverTvShows(queryResult);

            return View("TvList", tvShowResults);
        }
    }
}