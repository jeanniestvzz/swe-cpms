using Microsoft.AspNetCore.Mvc;
using CPMS.Data;
using CPMS.Migrations;
using CPMS.Models;
using CPMS.Controllers;
using System.Data;
using System.Data.Entity;


namespace CPMS.Controllers
{
    public class AuthorController : Controller
    {
        private CPMSContext _context;

        public AuthorController(CPMSContext context)
        {
            _context = context;
        }

        public IActionResult Index()
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
        public IActionResult Edit(int Id)
        {
            Author? author = _context.Authors.Where(p => p.AuthorId == Id).FirstOrDefault();
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            _context.Attach(author);
            _context.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Author? author = _context.Authors.Where(p => p.AuthorId == Id).FirstOrDefault();
            return View(author);
        }

        [HttpPost]
        public IActionResult Delete(Author author)
        {
            _context.Attach(author);
            _context.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            //var authorid = _context.Authors.Max(authid => authid.AuthorId);
            //author.AuthorId = authorid;
            _context.Attach(author);
            _context.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(int Id)
        {
            Author? author = _context.Authors.Where(p => p.AuthorId == Id).FirstOrDefault();
            return View(author);
        }
    }
}
