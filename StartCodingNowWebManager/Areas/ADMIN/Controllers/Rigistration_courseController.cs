using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Net;
using System.Web;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StartCodingNowWebManager.Common;
using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.Helpers;

namespace StartCodingNowWebManager.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class Rigistration_courseController : Controller
    {
        private QL_SCN db = new QL_SCN();

        // GET: ADMIN/Rigistration_course
        public ActionResult Index()
        {
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {
                var rIGISTRATION_COURSE = db.RigistrationCourse;
                return View(rIGISTRATION_COURSE.AsQueryable());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: ADMIN/Rigistration_course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View();
            }
            RigistrationCourse rIGISTRATION_COURSE = db.RigistrationCourse.Find(id);
            if (rIGISTRATION_COURSE == null)
            {
                return View();
            }
            return View(rIGISTRATION_COURSE);
        }

        // GET: ADMIN/Rigistration_course/Create
        public ActionResult Create()
        {
            ViewBag.IDCourse = new SelectList(db.Course, "IDCourse", "Name");
            return View();
        }

        // POST: ADMIN/Rigistration_course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RigistrationCourse rIGISTRATION_COURSE)
        {
            if (ModelState.IsValid)
            {
                db.RigistrationCourse.Add(rIGISTRATION_COURSE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCourse = new SelectList(db.Course, "IDCourse", "Name", rIGISTRATION_COURSE.Idcourse);
            return View(rIGISTRATION_COURSE);
        }

        // GET: ADMIN/Rigistration_course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            RigistrationCourse rIGISTRATION_COURSE = db.RigistrationCourse.Find(id);
            if (rIGISTRATION_COURSE == null)
            {
                return View();
            }
            ViewBag.IDCourse = new SelectList(db.Course, "IDCourse", "Name", rIGISTRATION_COURSE.Idcourse);
            return View(rIGISTRATION_COURSE);
        }

        // POST: ADMIN/Rigistration_course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( RigistrationCourse rIGISTRATION_COURSE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rIGISTRATION_COURSE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCourse = new SelectList(db.Course, "IDCourse", "Name", rIGISTRATION_COURSE.Idcourse);
            return View(rIGISTRATION_COURSE);
        }

        // GET: ADMIN/Rigistration_course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View();
            }
            RigistrationCourse rIGISTRATION_COURSE = db.RigistrationCourse.Find(id);
            if (rIGISTRATION_COURSE == null)
            {
                return View();
            }
            return View(rIGISTRATION_COURSE);
        }

        // POST: ADMIN/Rigistration_course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RigistrationCourse rIGISTRATION_COURSE = db.RigistrationCourse.Find(id);
            db.RigistrationCourse.Remove(rIGISTRATION_COURSE);
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
