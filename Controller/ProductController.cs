using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Data.Entity;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        DB_ShopEntities _db = new DB_ShopEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View(_db.Products.ToList());
        }
        public ActionResult ProductPage()
        {
            return View(_db.Products.ToList());
        }
        public ActionResult Details(int id)
        {
            return View(_db.Products.Where(s => s.IDProduct == id).FirstOrDefault());
        }
        [HttpPost]
        public JsonResult AjaxMethod()
        {
            DB_ShopEntities _db = new DB_ShopEntities();
            List<Product> products = (from Product in _db.Products
                                      select Product).ToList();
            return Json(products);
        }
        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            Product pro = new Product();
            return View(pro);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            try
            {
                // TODO: Add insert logic here
                if (pro.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(pro.ImageUpload.FileName);
                    string extension = Path.GetExtension(pro.ImageUpload.FileName);
                    fileName = fileName + extension;
                    pro.Images = "/Content/images/" + fileName;
                    pro.ImageUpload.SaveAs(Path.Combine(Server.MapPath("/Content/images/"), fileName));
                }
                _db.Products.Add(pro);
                _db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_db.Products.Where(s => s.IDProduct == id).FirstOrDefault());
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product pro)
        {
            try
            {
                // TODO: Add update logic here
                if (pro.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(pro.ImageUpload.FileName);
                    string extension = Path.GetExtension(pro.ImageUpload.FileName);
                    fileName = fileName + extension;
                    pro.Images = "/Content/images/" + fileName;
                    pro.ImageUpload.SaveAs(Path.Combine(Server.MapPath("/Content/images/"), fileName));
                }
                _db.Entry(pro).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_db.Products.Where(s => s.IDProduct == id).FirstOrDefault());
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product pro)
        {
            try
            {
                // TODO: Add delete logic here
                pro = _db.Products.Where(s => s.IDProduct == id).FirstOrDefault();
                _db.Products.Remove(pro);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ChooseCategory()
        {
            Category cate = new Category();
            cate.CateCollection = _db.Categories.ToList<Category>();
            return PartialView(cate);
        }
    }
}
