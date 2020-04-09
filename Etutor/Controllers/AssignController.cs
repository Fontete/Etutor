using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Etutor.DAL;
using Etutor.Models;

namespace Etutor.Controllers
{
    [Authorize]
    public class AssignController : Controller
    {
        private EtutorContext db = new EtutorContext();

        // GET: Assigns
        public ActionResult Index()
        {
            var assigns = db.Assigns.Include(a => a.Student);
            return View(assigns.ToList());
        }

        // GET: Assigns/CreateMultiple
        public ActionResult CreateMultiple()
        {
            ViewBag.Tutors = db.Tutors.ToList();
            ViewBag.Staff = db.Staffs.ToList();
            ViewBag.Students = db.Students.ToList();
            return View();
        }

        // POST: Assigns/CreateMultiple
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMultiple([Bind(Include = "Id")] List<int> stdID, int tutorID, int? staffID)
        {
            for (int i=0; i < stdID.Count; i++)
            {
                Assign assign = new Assign();
                if (ModelState.IsValid)
                {
                    int index = stdID[i];
                    var student = db.Students.Where(m => m.Id == index).SingleOrDefault();
                    var tutor = db.Tutors.Where(m => m.Id == tutorID).SingleOrDefault();
                    var staff = db.Staffs.Where(m => m.Id == staffID).SingleOrDefault();
                    assign.Id = student.Id;
                    assign.Student = student;
                    assign.Tutor = tutor;
                    assign.Staff = staff;
                    db.Assigns.Add(assign);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Assigns/Edit/id
        public ActionResult Edit(int? id)
        {
            Assign assign = db.Assigns.Find(id);
            if (assign == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = db.Tutors.ToList();
            return View(assign);
        }

        // POST: Assigns/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] int stdID, int tutorID, int? staffID)
        {
            Assign assign = db.Assigns.Where(m=>m.Id==stdID).SingleOrDefault();
            if (ModelState.IsValid)
            {
                var student = db.Students.Where(m => m.Id == stdID).SingleOrDefault();
                var tutor = db.Tutors.Where(m => m.Id == tutorID).SingleOrDefault();
                var staff = db.Staffs.Where(m => m.Id == tutorID).SingleOrDefault();
                assign.Id = student.Id;
                assign.Student = student;
                assign.Tutor = tutor;
                assign.Staff = staff;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Students, "Name", "Phone", "Email", assign.Id);
            return View(assign);
        }

        // GET: Assigns/Delete/id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assign assign = db.Assigns.Find(id);
            if (assign == null)
            {
                return HttpNotFound();
            }
            return View(assign);
        }

        // POST: Assigns/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assign assign = db.Assigns.Find(id);
            db.Assigns.Remove(assign);
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
