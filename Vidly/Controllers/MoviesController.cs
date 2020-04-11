using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using System.Threading.Tasks;
using Vidly.ViewModel;

namespace Vidly.Controllers {
    public class MoviesController : Controller {
        private ApplicationDbContext _context;
        public MoviesController() {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }
        // GET: Movies
        public async Task<ActionResult> Index() {
            var model = await _context.Movies.Include(g => g.Genre).ToListAsync();
            if (User.IsInRole(RolesName.CanManageMovies))
                return View("List");
            return View("ReadOnly");
        }

        [Authorize(Roles = RolesName.CanManageMovies)]
        public ActionResult Create() {
            var movieViewModel = new MovieFormViewModel() {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", movieViewModel);
        }

        public ActionResult Edit(int id) {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                return HttpNotFound("Not Found");
            var movieViewModel = new MovieFormViewModel(movie) {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", movieViewModel);
        }

        public ActionResult Save(MovieFormViewModel movie) {

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id) {
            var model = _context.Movies.Include(g => g.Genre).SingleOrDefault(x => x.Id == id);
            if (model == null)
                return HttpNotFound("Not Found");
            return View(model);
        }
    }
}