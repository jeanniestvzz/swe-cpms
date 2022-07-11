using Microsoft.AspNetCore.Mvc;
using CPMS.Data;
using CPMS.Models;
using System.Data;


namespace CPMS.Controllers
{
    public class ReviewerController : Controller
    {
        private readonly CPMSContext _context;

        public ReviewerController(CPMSContext context)
        {
            _context = context;
        }

        public IActionResult Index() // Gets a list of all the reviewers from the database
        {
            List<Reviewer> reviewers = _context.Reviewers.ToList();
            return View(reviewers);
        }

        public IActionResult Index2()
        {
            List<Reviewer> reviewers = _context.Reviewers.ToList();
            return View(reviewers);
        }

        public IActionResult Index3()
        {
            List<Reviewer> reviewers = _context.Reviewers.ToList();
            return View(reviewers);
        }

        [HttpGet]
        public IActionResult Edit(int Id) // Get request for the reviewer from database with id = Id
        {
            Reviewer? reviewer = _context.Reviewers.Where(p => p.ReviewerId == Id).FirstOrDefault();
            return View(reviewer);
        }

        [HttpPost]
        public IActionResult Edit(Reviewer reviewer) // Post modifications for reviewer to save in database
        {
            _context.Attach(reviewer);
            _context.Entry(reviewer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id) // Get request for the reviewer from database with id = Id
        {
            Reviewer? reviewer = _context.Reviewers.Where(p => p.ReviewerId == Id).FirstOrDefault();
            return View(reviewer);
        }

        [HttpPost]
        public IActionResult Delete(Reviewer reviewer) // Post delete for reviewer to remove from database
        {
            _context.Attach(reviewer);
            _context.Entry(reviewer).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Create() // Get request for a new reviewer
        {
            Reviewer reviewer = new Reviewer();
            return View(reviewer);
        }

        [HttpPost]
        public IActionResult Create(Reviewer reviewer) // Post new data for reviewer in database
        {
            _context.Attach(reviewer);
            _context.Entry(reviewer).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(int Id) // Retrieves details from database for reviewer with id = Id
        {
            Reviewer? reviewer = _context.Reviewers.Where(p => p.ReviewerId == Id).FirstOrDefault();
            return View(reviewer);
        }
    }
}
