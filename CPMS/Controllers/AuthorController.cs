using Microsoft.AspNetCore.Mvc;
using CPMS.Data;
using CPMS.Models;
using System.Data;


namespace CPMS.Controllers
{
    public class AuthorController : Controller
    {
        private CPMSContext _context;

        public AuthorController(CPMSContext context)
        {
            _context = context;
        }

        public IActionResult Index() // Gets a list of all the authors from the database
        {
            List<Author> authors = _context.Authors.ToList();
            return View(authors);
        }

        public IActionResult Index1()
        {
            List<Author> authors = _context.Authors.ToList();
            return View(authors);
        }

        public IActionResult Index2()
        {
            List<Author> authors = _context.Authors.ToList();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Edit(int Id) // Get request for the author from database with id = Id
        {
            Author? author = _context.Authors.Where(p => p.AuthorId == Id).FirstOrDefault();
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author) // Post modifications for author to save in database
        {
            _context.Attach(author);
            _context.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id) // Get request for the author from database with id = Id
        {
            Author? author = _context.Authors.Where(p => p.AuthorId == Id).FirstOrDefault();
            return View(author);
        }

        [HttpPost]
        public IActionResult Delete(Author author) // Post delete for author to remove from database
        {
            _context.Attach(author);
            _context.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create() // Get request for a new author
        {
            Author author = new Author();
            return View(author);
        }

        [HttpPost]
        public IActionResult Create(Author author) // Post new data for author in database
        {
            _context.Attach(author);
            _context.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(int Id) // Retrieves details from database for author with id = Id
        {
            Author? author = _context.Authors.Where(p => p.AuthorId == Id).FirstOrDefault();
            return View(author);
        }
    }
}
