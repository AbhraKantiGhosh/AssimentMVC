using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        DXCDBEntities db = new DXCDBEntities();
        [OutputCache(Duration =30)]
        public ActionResult Index()
        {
            //ViewBag.name = "Abhra";
            //ViewBag.city = "Ghatal";

            ViewBag.Countries = new List<string> { "India", "Japan", "England", "China" };
            ViewData["name"] = "abhra";
            ViewData["Countries"] = new List<string> { "India", "Japan", "England", "China" };
            var res = db.Users.ToList();
            return View(res);
        }
        [HttpGet]
        public ActionResult AddNewUser()
        {
            return View();
        }
        [HttpPost]
        [HandleError(View ="Error.aspx")]
        public ActionResult AddNewUser(User u1)
        {
            db.Users.Add(u1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            User u = db.Users.Find(id);
            return View(u);
        }
        [HttpPost]
        public ActionResult DeleteUser(int id,FormCollection frm)
        {
            User u = db.Users.Find(id);
            if (u != null)
            {
                db.Users.Remove(u);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
            
        }

        public ActionResult UserDetails(int id)
        {
            User u = db.Users.Find(id);
            return View(u);
        }

        [HttpPost]
        public ActionResult UpdateUser(int id, FormCollection frm)
        {
            User u = db.Users.Find(id);
            if (u != null)
            {
                u.username = frm[2].ToString();
                u.password = frm[3].ToString();
                u.email = frm[4].ToString();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();

        }
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            User u = db.Users.Find(id);
            return View(u);
        }

        public ActionResult Careers()
        {
            DXCDBEntities db = new DXCDBEntities();
            ViewBag.userids = new SelectList(db.Users,"userid","userid");
            return View();
        }
        public ActionResult MyHeader()
        {
            return View();
        }


        public ActionResult Print()
        {
            return Redirect("/webpage/page2.aspx");
        }




    }
}