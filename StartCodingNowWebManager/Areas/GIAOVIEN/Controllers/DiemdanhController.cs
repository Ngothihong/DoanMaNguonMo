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
    public class DiemdanhController : Controller
    {

        // GET: GIAOVIEN/Diemdanh
        DAO_Class_Student dao1 = new DAO_Class_Student();
        public ActionResult Index()
        {
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {
                SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.ID_CLASS,null);
              //  Session.Add(CommonConstant.ID_CLASS, null);
                var a = dao1.GetALL(SessionHelper.GetObjectFromJson<int>(HttpContext.Session, CommonConstant.ID_SESSION));
                SetViewBag1();
                return View(a);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Xem_Diemdanh(int id)
        {
            SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.ID_CLASS, id);
            //Session.Add(CommonConstant.ID_CLASS, id);
            List<Student_Change__Attendance> ds = dao1._GetALL(id);
            SetViewBag1();
            return View("Index", ds);
        }
        
        public ActionResult Xem_DiemdanhbyID(int lopsearch) // tim kiem
        {
            SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.ID_CLASS, lopsearch);
           // Session.Add(CommonConstant.ID_CLASS, lopsearch);
            List<Student_Change__Attendance> ds = dao1._GetALL(lopsearch);
            SetViewBag1();
            return View("Index", ds);
        }
        private void SetViewBag1(string selectName = null)// ma lop // dung de tim kiem
        {
            DAO_Lop daolop = new DAO_Lop();
            var lop1 = daolop.GetByIDTeacher(SessionHelper.GetObjectFromJson<int>(HttpContext.Session, CommonConstant.ID_SESSION));
            ViewBag.lopsearch = new SelectList(lop1.ToList(), "IDClass", "NameClass");
        }
        private void SetViewBag5(string selectName = null)// ma lop dung update
        {
            DAO_Lop daolop = new DAO_Lop();
            var lop1 = daolop.GetByIDTeacher(SessionHelper.GetObjectFromJson<int>(HttpContext.Session, CommonConstant.ID_SESSION));
            ViewBag.IDClass = new SelectList(lop1.ToList(), "IDClass", "NameClass");
        }
        private void SetViewBag2(int IDclass) // Ten hoc vien
        {
            DAO_Hocvien daohv = new DAO_Hocvien();
            var hocvien = daohv.GetbyIDClass(IDclass);
            ViewBag.IDStudent = new SelectList(hocvien.ToList(), "Idstudent", "Name");
        }
        private void SetViewBag6() // Ten hoc vien chung
        {
            DAO_Hocvien daohv = new DAO_Hocvien();
            var hocvien = daohv.GetALL(SessionHelper.GetObjectFromJson<int>(HttpContext.Session, CommonConstant.ID_SESSION));
            ViewBag.IDStudent = new SelectList(hocvien.ToList(), "Idstudent", "Name");
        }
        public List<Month> Create_Month()
        {
            List<Month> months = new List<Month>();
            for (int i = 1; i <= 12; i++)
            {
                Month month = new Month();
                month.ID = i;
                month.Name = "Tháng " + i.ToString();
                months.Add(month);
            }
            return months;
        }
        private void SetViewBag3() // session buoi hoc // khong rang buoc
        {
            ViewBag.Session = new SelectList(Create_Month(), "ID", "ID");
        }
        public void SetViewBag4 () // trang thai // khong rang buoc
        {
            List<SelectListItem> trangthai = new List<SelectListItem>()
                {
                new SelectListItem() {Text="Tham gia", Value="1"},
                new SelectListItem() { Text="Vắng", Value="0"}
                };
            ViewBag.State = new SelectList(trangthai, "Value", "Text");
        }
        [HttpGet]
        public ActionResult UpdateDiemdanh ()
        {
            int idclass=-1;
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.ID_CLASS);
            if (!string.IsNullOrEmpty(session))               
            {
                idclass = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, CommonConstant.ID_CLASS);
                SetViewBag2(SessionHelper.GetObjectFromJson<int>(HttpContext.Session, CommonConstant.ID_CLASS)); // ten hoc vien co ma lop
            }
            else
            {
                SetViewBag6(); // ten hoc vien chung
            }
            
            SetViewBag3(); // buoi hoc
            SetViewBag4(); // trang thai
            SetViewBag5(); // ma lop
          
            return View();
        }
        [HttpPost]
        public ActionResult Update(ClassStudent model)
        {
            if(dao1.Update(model))
            {
                TempData["msg"] = "<script>alert('Update thành công');</script>";
            }
            else
            {
                TempData["msg"] = "<script>alert('Update không thành công');</script>";
            }
            return Xem_Diemdanh(model.Idclass);
        }
        
    }
}