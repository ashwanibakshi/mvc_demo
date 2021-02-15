using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc2.Controllers
{
    public class Default1Controller : Controller
    {
        bal blayer = new bal();

        // GET: Default1
        public ActionResult Index()
        {
            IEnumerable<user> usr =  blayer.getAll();
            if (usr != null)
            {
                ViewBag.user = usr;
                return View();
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult Index(user u)
        {   
            if (blayer.newUser(u)>0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            blayer.delUser(id); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            user u = blayer.editUser(id);
            ViewBag.user = u;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(user u)
        {
           blayer.updateUser(u);
           return RedirectToAction("Index");
        }
    }
}