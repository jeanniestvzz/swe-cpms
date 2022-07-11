using Microsoft.AspNetCore.Mvc;
using CPMS.Data;
using CPMS.Models;
using System.Data;


namespace CPMS.Controllers
{
    public class PaperController : Controller
    {
        private CPMSContext _context;

        public PaperController(CPMSContext context)
        {
            _context = context;
        }

        public IActionResult Index() // Gets a list of all the papers from the database
        {
            List<Paper> papers = _context.Papers.ToList();
            return View(papers);
        }


        public IActionResult Index2()
        {
            List<Paper> papers = _context.Papers.ToList();
            return View(papers);
        }

        [HttpGet]
        public IActionResult Edit(int Id) // Get request for the paper from database with id = Id
        {
            Paper? paper = _context.Papers.Where(p => p.PaperId == Id).FirstOrDefault();
            return View(paper);
        }

        [HttpPost]
        public IActionResult Edit(Paper paper) // Post modifications for paper to save in database
        {
            _context.Attach(paper);
            _context.Entry(paper).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id) // Get request for the paper from database with id = Id
        {
            Paper? paper = _context.Papers.Where(p => p.PaperId == Id).FirstOrDefault();
            return View(paper);
        }

        [HttpPost]
        public IActionResult Delete(Paper paper) // Post delete for paper to remove from database
        {
            _context.Attach(paper);
            _context.Entry(paper).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create() // Get request for a new paper
        {
            Paper paper = new Paper();
            return View(paper);
        }

        [HttpPost]
        public IActionResult Create(Paper paper) // Post new data for paper in database
        {
            _context.Attach(paper);
            _context.Entry(paper).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(int Id) // Retrieves details from database for paper with id = Id
        {
            Paper? paper = _context.Papers.Where(p => p.PaperId == Id).FirstOrDefault();
            return View(paper);
        }
    }
}
