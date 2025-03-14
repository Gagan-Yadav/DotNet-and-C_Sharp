using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Models;
using System.Runtime.InteropServices;
using dotnetapp.Exception;

namespace dotnetapp.Controllers
{
    // [Route("[controller]")]
    public class ProjectTestController : Controller
    {
        AppDbContext1 db = null;

        public ProjectTestController(AppDbContext db1){
            db = db1;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
         public IActionResult TestForm(int ProjectID)
        {
            var res = db.Projects.Find(ProjectID); // use directly if primary key no need of lamda expression
                if(res==null){
                    return NotFound();
                }
                 ProjectTest p = new ProjectTest();
                p.ProjectID = ProjectID;
            return View(p);
        }

         [HttpPost]
         public IActionResult TestForm(int ProjectID, ProjectTest projectTest)
        {
            var res = db.Projects.Include(t=>t.ProjectTests).FirstOrDefault(f=>f.ProjectID == ProjectID);
                if(res==null){
                    return NotFound();
                }
                projectTest.ProjectID = ProjectID;

                if(!ModelState.ISValid){
                    return View(projectTest);
                }
                if(projectTest.Rating>1 || projectTest.Rating<10){
                    throw new ProjectTestException("The rating must be between 1 and 10");
                }
                db.ProjectTests.Add(projectTest);
                db.SaveChanges();
               

            return RedirectToAction("AvailableProjects", "Project"); // calling Action method named AvailableProjects which is present in Project Controller
        }

       
    }
}
