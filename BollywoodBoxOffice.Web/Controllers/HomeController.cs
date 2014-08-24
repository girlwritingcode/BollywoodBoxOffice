using BollywoodBoxOffice.Data;
using BollywoodBoxOffice.Data.Models;
using BollywoodBoxOffice.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BollywoodBoxOffice.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            List<MovieViewModel> Movies = Db.Movies.Select(
                m => new MovieViewModel {
                Id = m.Id,
                Name = m.Name,
                URL = m.URL,
                Gross = m.Gross,
                Crores = (Math.Round(((m.Gross * 60.92) / 10), 1))
                }).ToList();
            return View(Movies);
        }
        public ActionResult Details(int id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            DetailReviews DetailAndReviews = new DetailReviews(); //make new VM
            DetailAndReviews.Movie = Db.Movies.Where(m => m.Id == id).FirstOrDefault(); //identify the movie
            DetailAndReviews.Reviews = Db.Reviews.Where(r => r.Movies.Id == id).ToList(); //pull all the reviews
            return View(DetailAndReviews); //return the new VM
        }     
        public ActionResult AddReview(int id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Movie Movie = Db.Movies.Where(m => m.Id == id).FirstOrDefault();
            return View(Movie);   
        }
        [HttpPost]
        public ActionResult AddReview(string name, int stars, string body, int id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Db.Reviews.Add(new Review(name, stars, body, id));
            Db.SaveChanges();
            return RedirectToAction("Details", new { id = id });
        }
        public ActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMovie(string name, string url, int gross, int year, string studio, string director)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Movie Movie = new Movie(name, url, gross, year, studio, director);
            Db.Movies.Add(Movie);
            Db.SaveChanges();
            return RedirectToAction("Details", new { id = Movie.Id });
        }

        public ActionResult EditMovie(int id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Movie Movie = Db.Movies.Where(m => m.Id == id).FirstOrDefault();
            return View(Movie);
        }
        [HttpPost]
        public ActionResult EditMovie(int id, string name, string url, int gross, int year, string studio, string director)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Movie Movie = Db.Movies.Where(m => m.Id == id).FirstOrDefault();
            Movie.Name = name;
            Movie.URL = url;
            Movie.Gross = gross;
            Movie.Year = year;
            Movie.Studio = studio;
            Movie.Director = director;
            Db.SaveChanges();
            return RedirectToAction("Details", new { id = id });
        }
        public ActionResult DeleteMovie(int id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Movie Movie = Db.Movies.Where(m => m.Id == id).FirstOrDefault();
            Db.Movies.Remove(Movie);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}