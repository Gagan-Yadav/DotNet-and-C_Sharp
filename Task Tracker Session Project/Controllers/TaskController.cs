using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Controllers
{
    // [Route("[controller]")]
    public class TaskController : Controller
    {
        public ApplicationDbContext db = null;
        public TaskController(ApplicationDbContext db1){
            db = db1;
        }
       
       
         public IActionResult ShowTask()
        {
            ViewBag.un = HttpContext.Session.GetString("Uname");
            var res = db.TaskModels.ToList();
            return View(res);
        }
         public IActionResult AddTask()
        {

            return View();
        }
        [HttpPost]
         public IActionResult AddTask(TaskModel task)
        {
            db.TaskModels.Add(task);
            db.SaveChanges();
            return RedirectToAction("ShowTask");
        }

        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
