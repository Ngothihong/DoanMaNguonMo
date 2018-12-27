using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.DAO;
using StartCodingNowWebManager.Common;

using StartCodingNowWebManager.Helpers;
using Sakura.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI;

namespace StartCodingNowWebManager.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class GiaoVienController : Controller
    {
        // GET: ADMIN/GiaoVien

        DAO_Admin dao = new DAO_Admin();
        public ActionResult GiaoVien(string Search, int? page)
        {
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {
                var model = dao.List_Teacher();
                ViewBag.Search = Search;
                if (!string.IsNullOrEmpty(Search))
                {

                    model = dao.Search_Teacher(Search);
                }
                int pagesize = 15;
                int pagenumber = (page ?? 1);
                return View(model.ToPagedList(pagenumber, pagesize));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult Them()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Them(TeacherModel teacher)
        {

            if (dao.Insert_Teacher(teacher))
            {
                return RedirectToAction("GiaoVien");
            }
            else
            {
                TempData["msg"] = "<script>alert('Thêm Thất Bại! Lỗi!');</script>";
                return RedirectToAction("Them", "GiaoVien");
            }
        }



        public ActionResult Sua(int id)
        {
            var bien = dao.Get_Teacher(id);
            return View(bien);
        }
        [HttpPost]
        public ActionResult Sua(TeacherModel teacher)
        {
            if (ModelState.IsValid)
            {
                if (dao.Update_Teacher(teacher))
                {
                    TempData["msg"] = "<script>alert('Cập Nhật Thành Công !');</script>";
                    RedirectToAction("GiaoVien");
                }
                else
                    TempData["msg"] = "<script>alert('Cập Nhật Không Thành Công !');</script>";

            }
            return RedirectToAction("Sua","GiaoVien");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (dao.Delete_Teacher(id) == true)
            {
                TempData["msg"] = "<script>alert(' Thành Công !');</script>";
                return RedirectToAction("GiaoVien", "GiaoVien");
            }
            else
            {
                TempData["msg"] = "<script>alert('Lỗi Xóa Không Thành Công !');</script>";
                return RedirectToAction("GiaoVien", "GiaoVien");
            }


        }


    }
}