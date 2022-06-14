using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.Models;

namespace ManagementSystem.Controllers
{
    public class ClassController : Controller
    {
        private ManagementSystemEntities db = new ManagementSystemEntities();

        // GET: Class
        public ActionResult Index()
        {
            var tb_class = db.tb_class.Include(t => t.tb_package).Include(t => t.tb_user).Include(t => t.tb_student);
            return View(tb_class.ToList());
        }

        // GET: Class/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_class tb_class = db.tb_class.Find(id);
            if (tb_class == null)
            {
                return HttpNotFound();
            }
            return View(tb_class);
        }

        // GET: Class/Create
        public ActionResult Create()
        {
            ViewBag.Package = new SelectList(db.tb_package, "ID", "Name");
            ViewBag.TutorID = new SelectList(db.tb_user, "ID", "IC");
            ViewBag.StudentID = new SelectList(db.tb_student, "ID", "Name");
            
            return View();
        }

        // POST: Class/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Duration,Package,TutorID,StudentID,verifyStatus")] tb_class tb_class)
        {
            if (ModelState.IsValid)
            {
                tb_class.verifyStatus = 2;
                db.tb_class.Add(tb_class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Package = new SelectList(db.tb_package, "ID", "Name", tb_class.Package);
            ViewBag.TutorID = new SelectList(db.tb_user, "ID", "IC", tb_class.TutorID);
            ViewBag.StudentID = new SelectList(db.tb_student, "ID", "Name", tb_class.StudentID);
            return View(tb_class);
        }

        // GET: Class/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_class tb_class = db.tb_class.Find(id);
            if (tb_class == null)
            {
                return HttpNotFound();
            }
            ViewBag.Package = new SelectList(db.tb_package, "ID", "Name", tb_class.Package);
            ViewBag.TutorID = new SelectList(db.tb_user, "ID", "IC", tb_class.TutorID);
            ViewBag.StudentID = new SelectList(db.tb_student, "ID", "Name", tb_class.StudentID);
            return View(tb_class);
        }

        // POST: Class/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Duration,Package,TutorID,StudentID")] tb_class tb_class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Package = new SelectList(db.tb_package, "ID", "Name", tb_class.Package);
            ViewBag.TutorID = new SelectList(db.tb_user, "ID", "IC", tb_class.TutorID);
            ViewBag.StudentID = new SelectList(db.tb_student, "ID", "Name", tb_class.StudentID);
            return View(tb_class);
        }

        // GET: Class/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_class tb_class = db.tb_class.Find(id);
            if (tb_class == null)
            {
                return HttpNotFound();
            }
            return View(tb_class);
        }




        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_class tb_class = db.tb_class.Find(id);
            db.tb_class.Remove(tb_class);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("verify")]
        public ActionResult Verify(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var c = new tb_class()
            {
                ID = (int)id,
                verifyStatus = 1
            };

            using (var db = new ManagementSystemEntities())
            {
                db.tb_class.Attach(c);
                db.Entry(c).Property(x => x.verifyStatus).IsModified = true;
                db.SaveChanges();
            }

            return Json(new { verify = 1 });
        }

        public ActionResult Rate(tb_class cls)
        {
            using (ManagementSystemEntities db = new ManagementSystemEntities())
            {

                db.Entry(cls).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RateTutor2([Bind(Include = "ID,Date,Duration,Package,TutorID,StudentID,RatingTutor")] tb_class tb_class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_class).State = EntityState.Modified;
                db.Entry(tb_class).Property(p => p.verifyStatus).IsModified = false;
                db.Entry(tb_class).Property(p => p.Description).IsModified = false;
                db.Entry(tb_class).Property(p => p.CheckOut).IsModified = false;
                db.Entry(tb_class).Property(p => p.CheckIn).IsModified = false;
                db.Entry(tb_class).Property(p => p.StartTime).IsModified = false;

                db.SaveChanges();
                return RedirectToAction("ViewClass", "Student", new { id = tb_class.StudentID });
            }
            ViewBag.Package = new SelectList(db.tb_package, "ID", "Name", tb_class.Package);
            ViewBag.TutorID = new SelectList(db.tb_user, "ID", "IC", tb_class.TutorID);
            ViewBag.StudentID = new SelectList(db.tb_student, "ID", "Name", tb_class.StudentID);
            return View(tb_class);
        }
        public ActionResult RateTutor2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_class tb_class = db.tb_class.Find(id);
            if (tb_class == null)
            {
                return HttpNotFound();
            }
            ViewBag.Package = new SelectList(db.tb_package, "ID", "Name", tb_class.Package);
            ViewBag.TutorID = new SelectList(db.tb_user, "ID", "IC", tb_class.TutorID);
            ViewBag.StudentID = new SelectList(db.tb_student, "ID", "Name", tb_class.StudentID);
            return View(tb_class);
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
