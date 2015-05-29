using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstMVCApplication.Models;

namespace FirstMVCApplication.Controllers
{
    public class PeoplesController : Controller
    {
        private PeopleDBContext db = new PeopleDBContext();

        // GET: PeopleModels
        public ActionResult Index()
        {
            return View(db.peoples.ToList());
        }

        // GET: PeopleModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleModels peopleModels = db.peoples.Find(id);
            if (peopleModels == null)
            {
                return HttpNotFound();
            }
            return View(peopleModels);
        }

        // GET: PeopleModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeopleModels/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pid,Pname,Pbrith,Page,Psex")] PeopleModels peopleModels)
        {
            if (ModelState.IsValid)
            {
                db.peoples.Add(peopleModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peopleModels);
        }

        // GET: PeopleModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleModels peopleModels = db.peoples.Find(id);
            if (peopleModels == null)
            {
                return HttpNotFound();
            }
            return View(peopleModels);
        }

        // POST: PeopleModels/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pid,Pname,Pbrith,Page,Psex")] PeopleModels peopleModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peopleModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peopleModels);
        }

        // GET: PeopleModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleModels peopleModels = db.peoples.Find(id);
            if (peopleModels == null)
            {
                return HttpNotFound();
            }
            return View(peopleModels);
        }

        // POST: PeopleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PeopleModels peopleModels = db.peoples.Find(id);
            db.peoples.Remove(peopleModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
