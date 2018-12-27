using System;
using System.Collections.Generic;
using System.Linq;
using Sakura.AspNetCore;
using Microsoft.AspNetCore.Mvc;

using StartCodingNowWebManager.Areas.USER.Models;
//using PagedList;
using StartCodingNowWebManager.FF;
using Microsoft.AspNetCore.Http;

namespace StartCodingNowWebManager.Areas.USER.Controllers
{
    [Area("USER")]
    public class KhoaHocController : Controller
    {
        // GET: USER/KhoaHoc
        public ActionResult Index(string searchString, int? page, string age, string PriceSort, string AgeSort)
        {
            var dao = new KhoaHocModel();
            var model = dao.GetCOURSEs();
            //page
            if (searchString != null && page <= 1)
            {
                page = 1;
            }
            if (PriceSort != null && page <= 1)
            {
                page = 1;
            }
            if (AgeSort != null && page <= 1)
            {
                page = 1;
            }
            ViewBag.AgeSort = AgeSort;
            ViewBag.PriceSort = PriceSort;
            ViewBag.searchString = searchString;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = dao.SearchCOURSEs(searchString);
            }
            if (!string.IsNullOrEmpty(PriceSort))
            {
                model = dao.FilterCOURSEsByPrice(PriceSort);
            }
            if (!string.IsNullOrEmpty(AgeSort))
            {
                model = dao.FilterCOURSEsByAge(AgeSort);
            }
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageSize, pageNumber ));
            //return View(model);
        }
        [HttpGet]
        public ActionResult ChiTiet(string ID)
        {
            if (string.IsNullOrEmpty(ID))
                return Redirect("Index");
            var dao = new KhoaHocModel();
            var model = dao.GetCOURSE(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(string ADDRESS, string BIRTHDAY, string Email, string IDCourse, string NameParent, string NameStudent, string Phone,string Name)
        {
            if (string.IsNullOrEmpty(ADDRESS) || string.IsNullOrEmpty(BIRTHDAY)
                || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(IDCourse)
                || string.IsNullOrEmpty(NameParent) || string.IsNullOrEmpty(NameStudent)
                || string.IsNullOrEmpty(Phone) )
            {
                ViewBag.ErrorMsg = "Đăng kí thất bại, vui lòng thử lại sau";
                ViewBag.IDCourse = IDCourse;
                ViewBag.Name = Name;
                return View("Register");
            }
            RigistrationCourse rc = new RigistrationCourse();
            var model = new KhoaHocModel();
            rc.Address = ADDRESS;
            rc.Birthday = DateTime.Parse(BIRTHDAY);
            rc.Email = Email;
            rc.Idcourse = IDCourse;
            rc.NameParent = NameParent;
            rc.NameStudent = NameStudent;
            rc.Phone = Phone;

            //const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            //rc.IDRegist = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            //rc.DayRegist = DateTime.Today;
            rc.State = "Chưa Duyệt";
            bool rs = model.Insert(rc);
            if (rs)
            {
                return RedirectToAction("Index", "KhoaHoc");
            }
            else
            {
                ViewBag.IDCourse = IDCourse;
                ViewBag.Name = Name;
                ViewBag.ErrorMsg = "Đăng kí thất bại, vui lòng thử lại sau";
                return View("Register");
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            if (string.IsNullOrEmpty(Request.Query["Name"]) || string.IsNullOrEmpty(Request.Query["Id"]))
                return RedirectToAction("Index", "KhoaHoc");
            return View();

        }
    }
}