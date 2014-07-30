using BollywoodBoxOffice.Data;
using BollywoodBoxOffice.Data.Models;
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
            List<Movie> Movies = Db.Movies.ToList();
            return View(Movies);
        }
        public ActionResult Details(int id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            DetailReviews DetailAndReviews = new DetailReviews();
            DetailAndReviews.Movies = Db.Movies.Where(m => m.Id == id).FirstOrDefault();
            DetailAndReviews.Reviews = Db.Reviews.Where(r => r.Movies.Id == id).ToList();
            return View(DetailAndReviews);
        }
        
        public ActionResult AddReview(int id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Movie Movie = Db.Movies.Where(m => m.Id == id).FirstOrDefault();
            return View(Movie);   
        }
        [HttpPost]
        public ActionResult AddReview(int id, string name, string body, int stars)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Db.Reviews.Add(new Review(name, body, stars, id));
            Db.SaveChanges();
            return RedirectToAction("Details", new { id = id });
        }

        public ActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMovie(string name, string url, string gross, int year, string studio, string director)
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
        public ActionResult EditMovie(int id, string name, string url, string gross, int year, string studio, string director)
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