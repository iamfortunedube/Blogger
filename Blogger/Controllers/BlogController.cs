using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogger.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadAll()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Blog b)
        {
            if (ModelState.IsValid)
            {
                using(var ctx = new ApplicationDbContext())
                {
                    ctx.Blogs.Add(b);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                return View(ctx.Blogs.Where(m => m.Id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Blog blog)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Entry(blog).State = EntityState.Modified;
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return View(ctx.Blogs.Where(m => m.Id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Blog blog)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    blog = ctx.Blogs.Where(m => m.Id == id).FirstOrDefault();
                    ctx.Blogs.Remove(blog);
                    ctx.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Generic()
        {
            return View();
        }
    }
}