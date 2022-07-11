using Microsoft.AspNetCore.Mvc;
using CPMS.Data;
using CPMS.Models;
using CPMS.Controllers;
using System.Data;
using System.Data.Entity;

namespace CPMS.Controllers
{
    public class ReviewerController : Controller
    {
        private readonly CPMSContext _context;

        public ReviewerController(CPMSContext context)
        {
            _context = context;
        }

        public IActionResult Index()
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
        public IActionResult Edit(int Id)
        {
            Reviewer? reviewer = _context.Reviewers.Where(p => p.ReviewerId == Id).FirstOrDefault();
            return View(reviewer);
        }

        [HttpPost]
        public IActionResult Edit(Reviewer reviewer)
        {
            _context.Attach(reviewer);
            _context.Entry(reviewer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Reviewer? reviewer = _context.Reviewers.Where(p => p.ReviewerId == Id).FirstOrDefault();
            return View(reviewer);
        }

        [HttpPost]
        public IActionResult Delete(Reviewer reviewer)
        {
            _context.Attach(reviewer);
            _context.Entry(reviewer).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Reviewer reviewer)
        {
            //var authorid = _context.Reviewers.Max(authid => authid.ReviewerId);
            //reviewer.ReviewerId = authorid;
            _context.Attach(reviewer);
            _context.Entry(reviewer).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(int Id)
        {
            Reviewer? reviewer = _context.Reviewers.Where(p => p.ReviewerId == Id).FirstOrDefault();
            return View(reviewer);
        }
    }
}
