using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sakura.AspNetCore;
using StartCodingNowWebManager.DAO;
using StartCodingNowWebManager.Common;
using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.Helpers;

namespace StartCodingNowWebManager.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class ClassController : Controller
    {
        // GET: ADMIN/Class
        DAO_Admin dao = new DAO_Admin();
        public ActionResult Index(string Search, int? page)
        {
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {
                var model = dao.Get_Class();
                ViewBag.Search = Search;
                if (!string.IsNullOrEmpty(Search))
                {
                    model = dao.Search_Class(Search);
                }
                int pagesize = 15;
                int pagenumber = (page ?? 1);
                return View(model.ToPagedList(pagesize,pagenumber ));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        private void set_viewbag()
        {
            var lop = dao.GetName_Course();
            ViewBag.IDCourse = new SelectList(lop.ToList(), "IDCourse", "Name");
        }
         public ActionResult Them()
        {
            set_viewbag();
            return View();
        }

        [HttpPost]
        public ActionResult Them(Class lop)
        {
            if (dao.Insert_Class(lop))
            {
                TempData["msg"] = "<script>alert('Thêm Thành Công');</script>";
                return RedirectToAction("Index", "Class");
            }
            else
            {
                TempData["msg"] = "<script>alert('Thêm Thất Bại! Lỗi!');</script>";
                return RedirectToAction("Them", "Class");
            }
        }

        public ActionResult Sua(int id)
        {
            var model = dao.Get_DetailClass(id);
            set_viewbag();
            return View(model);
        }

        [HttpPost]
        public ActionResult Sua(Class lop)
        {
            if (dao.Update_Class(lop))
            {
                TempData["msg"] = "<script>alert('Cập Nhật Thành Công');</script>";
                return RedirectToAction("Index", "Class");
            }
            else
            {
                TempData["msg"] = "<script>alert('Cập Nhật Thất Bại! Lỗi!');</script>";
                return RedirectToAction("Sua", "Class");
            }
        }

        public ActionResult Xoa(int id)
        {
            if (dao.Delete_Class(id))
            {
                TempData["msg"] = "<script>alert('Xóa Thành Công');</script>";
            }
            else
            {
                TempData["msg"] = "<script>alert('Không Thể Xóa Lớp!');</script>";
            }
            return RedirectToAction("Index", "Class");
        }
    }
}