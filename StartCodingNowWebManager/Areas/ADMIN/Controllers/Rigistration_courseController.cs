using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Net;
using System.Web;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StartCodingNowWebManager.ApiCommunicationTools;
using StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI;
using StartCodingNowWebManager.Common;
using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.Helpers;

namespace StartCodingNowWebManager.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class Rigistration_courseController : Controller
    {
     //   private QL_SCN db = new QL_SCN();

        // GET: ADMIN/Rigistration_course
        public ActionResult Index()
        {
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {
                try
                {
                    var rigis = ApiClientFactory.KimAnhInstance.GetAllRegister();
                    var rIGISTRATION_COURSE = rigis;
                    return View(rIGISTRATION_COURSE.AsQueryable());
                }
                catch
                {
                    return View();
                }
               
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
            var rigis = ApiClientFactory.KimAnhInstance.GetAllRegister().Where(n=>n.Idregist==id).FirstOrDefault();
            RegistrationCourseModel rIGISTRATION_COURSE = rigis;
            if (rIGISTRATION_COURSE == null)
            {
                return View();
            }
            return View(rIGISTRATION_COURSE);
        }

        // GET: ADMIN/Rigistration_course/Create
        public ActionResult Create()
        {
            var a = ApiClientFactory.KimAnhInstance.GetAllCourse();
            ViewBag.IDCourse = new SelectList(a, "Idcourse", "Name");
            return View();
        }

        // POST: ADMIN/Rigistration_course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegistrationCourseModel rIGISTRATION_COURSE)
        {
            if (ModelState.IsValid)
            {
                var ba = ApiClientFactory.KimAnhInstance.AddRegister(rIGISTRATION_COURSE);
              
                return RedirectToAction("Index");
            }
            var a = ApiClientFactory.KimAnhInstance.GetAllCourse();
            ViewBag.IDCourse = new SelectList(a, "Idcourse", "Name", rIGISTRATION_COURSE.Idcourse);
            return View(rIGISTRATION_COURSE);
        }

        // GET: ADMIN/Rigistration_course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var rigis = ApiClientFactory.KimAnhInstance.GetAllRegister().Where(n => n.Idregist == id).FirstOrDefault();
            RegistrationCourseModel rIGISTRATION_COURSE = rigis;
           
            if (rIGISTRATION_COURSE == null)
            {
                return View();
            }
            var a = ApiClientFactory.KimAnhInstance.GetAllCourse();
            ViewBag.IDCourse = new SelectList(a, "Idcourse", "Name", rIGISTRATION_COURSE.Idcourse);
            return View(rIGISTRATION_COURSE);
        }

        // POST: ADMIN/Rigistration_course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RegistrationCourseModel rIGISTRATION_COURSE)
        {
            if (ModelState.IsValid)
            {
                var m = ApiClientFactory.KimAnhInstance.UpdateRegister(rIGISTRATION_COURSE);
                return RedirectToAction("Index");
            }
            var a = ApiClientFactory.KimAnhInstance.GetAllCourse();
            ViewBag.IDCourse = new SelectList(a, "Idcourse", "Name", rIGISTRATION_COURSE.Idcourse);
            return View(rIGISTRATION_COURSE);
        }

        // GET: ADMIN/Rigistration_course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var rigis = ApiClientFactory.KimAnhInstance.GetAllRegister().Where(n => n.Idregist == id).FirstOrDefault();
            RegistrationCourseModel rIGISTRATION_COURSE = rigis;
            if (rIGISTRATION_COURSE == null)
            {
                return View();
            }
            return View(rIGISTRATION_COURSE);
        }

        // POST: ADMIN/Rigistration_course/Delete/5
      

        
    }
}
