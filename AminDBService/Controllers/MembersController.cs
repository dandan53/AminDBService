using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AminDBService.Models;

namespace AminDBService.Controllers
{   
    public class MembersController : Controller
    {
        private AminDBServiceContext context = new AminDBServiceContext();

        //
        // GET: /Members/

        public ViewResult Index()
        {
            return View(context.Members.ToList());
        }

        //
        // GET: /Members/Details/5

        public ViewResult Details(int id)
        {
            Member member = context.Members.Single(x => x.MemberId == id);
            return View(member);
        }

        //
        // GET: /Members/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Members/Create

        [HttpPost]
        public ActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                context.Members.Add(member);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(member);
        }
        
        //
        // GET: /Members/Edit/5
 
        public ActionResult Edit(int id)
        {
            Member member = context.Members.Single(x => x.MemberId == id);
            return View(member);
        }

        //
        // POST: /Members/Edit/5

        [HttpPost]
        public ActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                context.Entry(member).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        //
        // GET: /Members/Delete/5
 
        public ActionResult Delete(int id)
        {
            Member member = context.Members.Single(x => x.MemberId == id);
            return View(member);
        }

        //
        // POST: /Members/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = context.Members.Single(x => x.MemberId == id);
            context.Members.Remove(member);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}