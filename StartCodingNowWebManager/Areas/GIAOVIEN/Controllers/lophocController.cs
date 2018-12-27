using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StartCodingNowWebManager.DAO;
using StartCodingNowWebManager.Areas.GIAOVIEN.Models;
using StartCodingNowWebManager.DAO.GIAOVIEN;
using StartCodingNowWebManager.FF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StartCodingNowWebManager.Helpers;
using StartCodingNowWebManager.Common;

namespace StartCodingNowWebManager.Areas.GIAOVIEN.Controllers
{
    [Area("GIAOVIEN")]
    public class lophocController : Controller
    {
        DAO_Course dao_course = new DAO_Course();
        DAO_Lop dao_lop = new DAO_Lop();
        // GET: GIAOVIEN/lophoc
        public ActionResult Index(string search_table)
        {
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {                
                var a = dao_lop.GetByIDTeacher(SessionHelper.GetObjectFromJson<int>(HttpContext.Session, CommonConstant.ID_SESSION));
                SetViewBag();
                return View(a);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        private void SetViewBag ( string selectName = null)
        {
            ViewBag.search = new SelectList(dao_course.GetNamecouse(), "Name", "Name", selectName);
            var a = new SelectList(dao_course.GetNamecouse(), "Name", "Name", selectName);
        }
       
      
        public ActionResult Search(string search)
        {

            List<Class_model> list = dao_lop.GetClassModels(search, SessionHelper.GetObjectFromJson<int>(HttpContext.Session, CommonConstant.ID_SESSION));
            SetViewBag();
            return View("Index",list);
        }

    }
}