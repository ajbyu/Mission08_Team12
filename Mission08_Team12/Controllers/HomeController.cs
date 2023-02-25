using Microsoft.AspNetCore.Mvc;
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
        private readonly ToDoContext _context;

        public HomeController(ToDoContext context)
        {
            _context = context;
        }

        //Home
        public IActionResult Index()
        {
            return View("QuadrantView");
        }

        //Create
        [HttpGet]
        public IActionResult CreateToDo()
        {
            ViewBag.ToDoCategories = _context.ToDoCategories.ToList();

            return View(new ToDo());
        }

        [HttpPost]
        public IActionResult CreateToDo(ToDo todo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todo);
                _context.SaveChanges();
                return View(todo);
            }
            else
            {
                return View();
            }
            
        }

        //Read
        [HttpGet]
        public IActionResult ViewToDos()
        {
            var todos = _context
                .ToDos
                .Where(t => t.Complete == false)
                .ToList();

            return View(todos);
        }

        //Update
        [HttpGet]
        public IActionResult EditToDo(int id)
        {
            var todo = _context
                .ToDos
                .SingleOrDefault(t => t.Id == id);

            return View("EnterToDo", todo);
        }

        [HttpPost]
        public IActionResult EditToDo(ToDo todo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(todo);
                _context.SaveChanges();

                return RedirectToAction("ViewToDos");
            }
            else
            {
                return View("EnterToDo", todo);
            }
        }

        //Delete
        [HttpGet]
        public ActionResult DeleteToDo(int id)
        {
            var todo = _context
                .ToDos
                .SingleOrDefault(todo => t.Id == id);

            return View(todo);
        }

        [HttpPost]
        public IActionResult DeleteToDo(ToDo todo)
        {
            _context.Remove(todo);
            _context.SaveChanges();

            return RedirectToAction("ViewToDos");
        }
    }
}
