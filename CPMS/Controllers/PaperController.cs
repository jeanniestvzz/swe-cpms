using Microsoft.AspNetCore.Mvc;
using CPMS.Data;
using CPMS.Migrations;
using CPMS.Models;
using CPMS.Controllers;
using System.Data;
using System.Data.Entity;

namespace CPMS.Controllers
{
    public class PaperController : Controller
    {
        private CPMSContext _context;

        public PaperController(CPMSContext context)
        {
            _context = context;
        }

        public IActionResult Index()
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
        public IActionResult Edit(int Id)
        {
            Paper? paper = _context.Papers.Where(p => p.PaperId == Id).FirstOrDefault();
            return View(paper);
        }

        [HttpPost]
        public IActionResult Edit(Paper paper)
        {
            _context.Attach(paper);
            _context.Entry(paper).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Paper? paper = _context.Papers.Where(p => p.PaperId == Id).FirstOrDefault();
            return View(paper);
        }

        [HttpPost]
        public IActionResult Delete(Paper paper)
        {
            _context.Attach(paper);
            _context.Entry(paper).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            Paper paper = new Paper();
            return View(paper);
        }

        [HttpPost]
        public IActionResult Create(Paper paper)
        {
            _context.Attach(paper);
            _context.Entry(paper).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(int Id)
        {
            Paper? paper = _context.Papers.Where(p => p.PaperId == Id).FirstOrDefault();
            return View(paper);
        }
    }
}
