using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;
using System.Data;

namespace DoAn1.Controllers
{
    public class CategoryController : Controller
    {
        DB_ShopEntities _db = new DB_ShopEntities();
        // GET: Category
        public ActionResult Index()
        {
            return View(_db.Categories.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.Categories.Where(s => s.IDCategory == id).FirstOrDefault());
        }

        // GET: Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category cate)
        {
            try
            {
                // TODO: Add insert logic here
                _db.Categories.Add(cate);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_db.Categories.Where(s => s.IDCategory == id).FirstOrDefault());
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category cate)
        {
            try
            {
                // TODO: Add update logic here
                _db.Entry(cate).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_db.Categories.Where(s => s.IDCategory == id).FirstOrDefault());
        }
        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category cate)
        {
            try
            {
                // TODO: Add delete logic here
                cate = _db.Categories.Where(s => s.IDCategory == id).FirstOrDefault();
                _db.Categories.Remove(cate);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("IDCategory is use for other table");
            }
        }
    }
}
