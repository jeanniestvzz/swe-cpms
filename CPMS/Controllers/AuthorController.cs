using Microsoft.AspNetCore.Mvc;
using CPMS.Data;
using CPMS.Models;
using CPMS.Controllers;
using System.Data;
using System.Data.Entity;

namespace CPMS.Controllers
{
    public class AuthorController : Controller
    {
        private readonly CPMSContext _context;

        public AuthorController(CPMSContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Author> authors = _context.Authors.ToList();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Edit(int Id) 
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Author author = _context.Authors.Where(p => p.AuthorId == Id).FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            return View(author);
        }

        [HttpGet]
        public IActionResult Edit(Author author)
        {
            _context.Attach(author);
            _context.Entry(author).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id) 
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Author author = _context.Authors.Where(p => p.AuthorId == Id).FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            return View(author);
        }

        [HttpPost]
        public IActionResult Delete(Author author)
        {
            _context.Attach(author);
            _context.Entry(author).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            var authorid = _context.Authors.Max(authid => authid.AuthorId);
            author.AuthorId = authorid;
            _context.Attach(author);
            _context.Entry(author).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
