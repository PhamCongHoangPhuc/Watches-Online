using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace DoAn1.Controllers
{
    public class LoginController : Controller
    {
        DB_ShopEntities _db = new DB_ShopEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authen(User _user)
        {
            var obj = _db.Users.Where(s => s.Email.Equals(_user.Email) && s.Password.Equals(_user.Password)).FirstOrDefault();
            if (obj == null)
            {
                _user.LogInErrorMessage = "Error Email or Password ! Try Again please!";
                return View("Index", _user);
            }
            else
            {
                var test = _db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (test.Email != "admin@gmail.com")
                {
                    Session["IDUser"] = _user.IDUser;
                    Session["Email"] = _user.Email;
                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    Session["IDUser"] = _user.IDUser;
                    Session["Email"] = _user.Email;
                    return RedirectToAction("Index", "Product");
                }
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = _db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.Users.Add(_user);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.error = "Email already exists !";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("HomePage", "Home");
        }
    }
}