using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Controllers
{
    // [Route("[controller]")]
    public class UserController : Controller
    {
       
        public ApplicationDbContext db = null;
        public UserController(ApplicationDbContext db1){
            db = db1;
        }
        // public IActionResult Index()
        // {
        //     return View();
        // }
         public IActionResult ShowUser()
        {
            var res = db.Users.ToList();
            return View(res);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
         public IActionResult Login(User user)
        {
            var res = db.Users.Where(u=>u.UserName==user.UserName && u.Password == user.Password).ToList();
            if(res.Count>0){
                HttpContext.Session.SetString("Uname",user.UserName);
                return RedirectToAction("ShowTask","Task");
            }
            TempData["erre"] = "Invcalid username or password";
            return View();
        }

        [HttpGet]
         public IActionResult Register()
        {
        
            return View();
        }
         [HttpPost]
         public IActionResult Register(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
