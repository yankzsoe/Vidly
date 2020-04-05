using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers {
    public class MoviesController : Controller {
        // GET: Movies
        public ActionResult Index() {
            var model = GetMovies();
            return View(model);
        }

        private List<Movie> GetMovies() {
            return new List<Movie>() {
                new Movie(){Id = 1, Name = "Spider-Man" },
                new Movie(){Id = 2, Name = "Star War" }
            };
        }

        public ActionResult Create() {
            return View();
        }

        public ActionResult Edit(int id) {
            var model = GetMovies().SingleOrDefault(x => x.Id == id);
            if (model == null)
                return HttpNotFound("Not Found");
            return View(model);
        }

        public ActionResult Details(int id) {
            var model = GetMovies().SingleOrDefault(x => x.Id == id);
            if (model == null)
                return HttpNotFound("Not Found");
            return View(model);
        }
    }
}