using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StartCodingNowWebManager.DAO;

using StartCodingNowWebManager.FF;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using StartCodingNowWebManager.Common;
using StartCodingNowWebManager.Helpers;
using Sakura.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace StartCodingNowWebManager.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class CourseController : Controller
    {
        // GET: ADMIN/Course
        private IHostingEnvironment _env;
        public CourseController(IHostingEnvironment env)
        {
            _env = env;
        }
        DAO_Admin dao = new DAO_Admin();
        public ActionResult Course(string Search, int? page)
        {
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {
                var model = dao.Get_Course();
                if (!string.IsNullOrEmpty(Search))
                {
                    model = dao.Search_Course(Search);
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
        [ValidateAntiForgeryToken]
        public ActionResult Them(Course course, IFormFile files)
        {
            var uploads = Path.Combine(_env.WebRootPath.Replace("\\wwwroot", ""), "Assets\\Image");
            // full path to file in temp location
            var filePath = Path.Combine(uploads, course.Idcourse + "1.jpg");/*"~/Assets/Image/" + course.Idcourse + "update.jpg";*/
                                                                                 //   var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (files.Length > 0)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    files.CopyTo(fileStream);
                }
            }


            course.Image = "~/Assets/Image/" + course.Idcourse + "1.jpg";
            if (dao.Insert_Course(course))
            {
                TempData["msg"] = "<script>alert('Thêm Thành Công!');</script>";
                return RedirectToAction("Course", "Course");
            }
            else
            {
                TempData["msg"] = "<script>alert('Thêm Thất Bại! Lỗi!');</script>";
                return RedirectToAction("Them", "Course");
            }
        }
        public ActionResult Sua(string id)
        {
            var bien = dao.Get_DetailCourse(id);
            return View(bien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sua(Course course, IFormFile files)
        {
            var filePath1 = Path.GetTempFileName();
            // long size = files.Sum(f => f.Length);
            var uploads = Path.Combine(_env.WebRootPath.Replace("\\wwwroot", ""), "Assets\\Image");
            // full path to file in temp location
            var filePath = Path.Combine(uploads, course.Idcourse + "update.jpg");/*"~/Assets/Image/" + course.Idcourse + "update.jpg";*/
                                                                                 //   var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (files.Length > 0)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    files.CopyTo(fileStream);
                }
            }


            course.Image = "~/Assets/Image/" + course.Idcourse + "update.jpg";
            if (dao.Update_Course(course))
            {
                TempData["msg"] = "<script>alert('Cập Nhật Thành Công!');</script>";
                return RedirectToAction("Course", "Course");
            }
            else
            {
                TempData["msg"] = "<script>alert('Cập Nhật Thất Bại! Lỗi!');</script>";
                return RedirectToAction("Sua", "Course");
            }
        }
        
        public ActionResult Xoa(string id)
        {
            if (dao.Delete_Course(id))
            {
                TempData["msg"] = "<script>alert('Xóa Thành Công!');</script>";
            }
            else
            {
                TempData["msg"] = "<script>alert('Xóa Không Thành Công! Lỗi');</script>";
            }

            return RedirectToAction("Course", "Course");
        }
    }
}