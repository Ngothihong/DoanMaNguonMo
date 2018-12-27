using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StartCodingNowWebManager.Areas.GIAOVIEN.Models;
using StartCodingNowWebManager.Common;
using StartCodingNowWebManager.DAO.GIAOVIEN;
using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.Helpers;

namespace StartCodingNowWebManager.Areas.GIAOVIEN.Controllers
{
    [Area("GIAOVIEN")]
    public class DShocvienController : Controller
    {
        DAO_Hocvien dao = new DAO_Hocvien();
        // GET: GIAOVIEN/DShocvien

        public ActionResult Index( )
        {
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {                
                var a = dao.GetALL(SessionHelper.GetObjectFromJson<int>(HttpContext.Session, CommonConstant.ID_SESSION));
                SetViewBag1();
                return View(a);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        
        public ActionResult Xem_DShocvien(int id)
        {            
            IEnumerable<Student> ds = dao.GetbyIDClass(id);
            SetViewBag1();
            return View("Index",ds);
        }

        public ActionResult Searchlop(int IDClass)
        {
            IEnumerable<Student> ds = dao.GetbyIDClass(IDClass);
            SetViewBag1();
            return View("Index", ds);
        }

        private void SetViewBag1(string selectName = null)// ma lop // dung de tim kiem
        {
            DAO_Lop daolop = new DAO_Lop();
            var lop1 = daolop.GetByIDTeacher(SessionHelper.GetObjectFromJson<int>(HttpContext.Session, CommonConstant.ID_SESSION));
            ViewBag.IDClass = new SelectList(lop1.ToList(), "IDClass", "NameClass");
        }
    }
}