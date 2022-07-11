using Microsoft.AspNetCore.Mvc;
using CPMS.Data;
using CPMS.Models;
using System.Data;


namespace CPMS.Controllers
{
    public class ReviewController : Controller
    {
        private CPMSContext _context;

        public IActionResult Index() // Gets a list of all the reviews from the database
        {
            List<Review> reviews = _context.Reviews.ToList();
            return View(reviews);
        }

        public IActionResult Index2()
        {
            List<Review> reviews = _context.Reviews.ToList();
            return View(reviews);
        }

        public ReviewController(CPMSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Edit(int Id) // Get request for the review from database with id = Id
        {
            Review? review = _context.Reviews.Where(p => p.ReviewId == Id).FirstOrDefault();
            return View(review);
        }

        [HttpPost]
        public IActionResult Edit(Review review) // Post modifications for review to save in database
        {
            _context.Attach(review);
            _context.Entry(review).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id) // Get request for the review from database with id = Id
        {
            Review? review = _context.Reviews.Where(p => p.ReviewId == Id).FirstOrDefault();
            return View(review);
        }

        [HttpPost]
        public IActionResult Delete(Review review) // Post delete for review to remove from database
        {
            _context.Attach(review);
            _context.Entry(review).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Create() // Get request for a new review
        {
            Review review = new Review();
            return View(review);
        }

        [HttpPost]
        public IActionResult Create(Review review) // Post new data for review in database
        {
            _context.Attach(review);
            _context.Entry(review).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(int Id) // Retrieves details from database for review with id = Id
        {
            Review? review = _context.Reviews.Where(p => p.ReviewId == Id).FirstOrDefault();
            return View(review);
        }
    }
}
