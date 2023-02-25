using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission08_Team12.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_Team12.Controllers
{
    public class HomeController : Controller
    {
        private readonly ToDoDatabaseContext _context;

        public HomeController(ToDoDatabaseContext context)
        {
            _context = context;
        }

        //Home
        public IActionResult Index()
        {
            return View();
        }

        //Create
        [HttpGet]
        public IActionResult AddItem()
        {
            ViewBag.ToDoCategories = _context.Categories.ToList();
            ViewBag.Quadrants = _context.Quadrants.ToList();

            return View(new ToDo());
        }

        [HttpPost]
        public IActionResult AddItem(ToDo todo)
        {
            ViewBag.ToDoCategories = _context.Categories.ToList();
            ViewBag.Quadrants = _context.Quadrants.ToList();

            if (ModelState.IsValid)
            {
                _context.Add(todo);
                _context.SaveChanges();
                return RedirectToAction("AddItem");
            }
            else
            {
                return View();
            }
        }

        //Read
        [HttpGet]
        public IActionResult QuadrantView()
        {
            var todos = _context
                .ToDo
                .Where(t => t.Completed == false)
                .Include(t => t.Quadrant)
                .Include(t => t.Category)
                .ToList();

            return View(todos);
        }

        //Update
        [HttpGet]
        public IActionResult EditToDo(int id)
        {
            ViewBag.ToDoCategories = _context.Categories.ToList();
            ViewBag.Quadrants = _context.Quadrants.ToList();

            var todo = _context
                .ToDo
                .SingleOrDefault(t => t.ToDoID == id);

            return View("AddItem", todo);
        }

        //Mark complete
        [HttpGet]
        public IActionResult MarkComplete(int id)
        {
            var todo = _context
                .ToDo
                .Where(t => t.ToDoID.Equals(id))
                .FirstOrDefault();

            todo.Completed = true;
            _context.Update(todo);
            _context.SaveChanges();

            return RedirectToAction("QuadrantView");
        }

        [HttpPost]
        public IActionResult EditToDo(ToDo todo)
        {
            ViewBag.ToDoCategories = _context.Categories.ToList();
            ViewBag.Quadrants = _context.Quadrants.ToList();

            if (ModelState.IsValid)
            {
                _context.Update(todo);
                _context.SaveChanges();

                return RedirectToAction("QuadrantView");
            }
            else
            {
                return View("AddItem", todo);
            }
        }

        //Delete
        [HttpGet]
        public ActionResult DeleteToDo(int id)
        {
            var todo = _context
                .ToDo
                .SingleOrDefault(t => t.ToDoID == id);

            _context.Remove(todo);
            _context.SaveChanges();

            return RedirectToAction("QuadrantView");
        }
    }
}
