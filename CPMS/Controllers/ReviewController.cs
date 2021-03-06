using Microsoft.AspNetCore.Mvc;
using CPMS.Data;
using CPMS.Migrations;
using CPMS.Models;
using CPMS.Controllers;
using System.Data;
using System.Data.Entity;

namespace CPMS.Controllers
{
    public class ReviewController : Controller
    {
        private CPMSContext _context;

        public IActionResult Index()
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
        public IActionResult Edit(int Id)
        {
            Review? review = _context.Reviews.Where(p => p.ReviewId == Id).FirstOrDefault();
            return View(review);
        }

        [HttpPost]
        public IActionResult Edit(Review review)
        {
            _context.Attach(review);
            _context.Entry(review).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Review? review = _context.Reviews.Where(p => p.ReviewId == Id).FirstOrDefault();
            return View(review);
        }

        [HttpPost]
        public IActionResult Delete(Review review)
        {
            _context.Attach(review);
            _context.Entry(review).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            //var authorid = _context.Authors.Max(authid => authid.AuthorId);
            //author.AuthorId = authorid;
            _context.Attach(review);
            _context.Entry(review).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(int Id)
        {
            Review? review = _context.Reviews.Where(p => p.ReviewId == Id).FirstOrDefault();
            return View(review);
        }
    }
}
