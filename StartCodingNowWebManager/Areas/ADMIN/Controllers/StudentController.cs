using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StartCodingNowWebManager.DAO;

using StartCodingNowWebManager.FF;
using Microsoft.AspNetCore.Mvc;
using Sakura.AspNetCore;
using StartCodingNowWebManager.Helpers;
using StartCodingNowWebManager.Common;
using StartCodingNowWebManager.ApiCommunicationTools;
using StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI;

namespace StartCodingNowWebManager.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class StudentController : Controller
    {
       // private QL_SCN db = new QL_SCN();
        // GET: ADMIN/Student
        DAO_Admin dao = new DAO_Admin();
        public ActionResult Student(string Search, int? page)
        {
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {
                var model = dao.List_Student();
                ViewBag.Search = Search;
                if (!string.IsNullOrEmpty(Search))
                {
                    model = dao.Search_Student(Search);
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

        
        public ActionResult Them()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Them(StudentModel student)
        {
            if (dao.Insert_Student(student))
            {
                TempData["msg"] = "<script>alert('Thêm Thành Công !');</script>";
                return RedirectToAction("Student");
            }
            else
            {
                TempData["msg"] = "<script>alert('Thêm Không Thành Công !');</script>";
                return RedirectToAction("Student");
            }
        }

        public ActionResult Sua(int id)
        {
            var bien = dao.Get_student(id);
            return View(bien);
        }
        [HttpPost]
        public ActionResult Sua(StudentModel student)
        {
            if (dao.Update_Student(student))
            {
                TempData["msg"] = "<script>alert('Sửa Thành Công !');</script>";
                return RedirectToAction("Student");
            }
            else
            {
                TempData["msg"] = "<script>alert('Sửa Không Thành Công !');</script>";
                return RedirectToAction("Student");
            }
        }
        
        public ActionResult xoa(int id)
        {
            if (dao.Delete_Student(id))
            {
                TempData["msg"] = "<script>alert('Xóa Thành Công !');</script>";
                return RedirectToAction("Student");
            }
            else
            {
                TempData["msg"] = "<script>alert('Không Được Xóa Học Sinh !');</script>";
                return RedirectToAction("Student");
            }
        }

       
        
       
    }
}