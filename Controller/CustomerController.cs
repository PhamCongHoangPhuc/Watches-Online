using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        DB_ShopEntities _db = new DB_ShopEntities();
        // GET: Customer
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer cus)
        {
            _db.Customers.Add(cus);
            _db.SaveChanges();
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
    }
}