using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartCodingNowWebManager.DAO.GIAOVIEN;
using StartCodingNowWebManager.Areas.GIAOVIEN.Models;
using Microsoft.AspNetCore.Mvc;
using StartCodingNowWebManager.Helpers;
using StartCodingNowWebManager.Common;

namespace StartCodingNowWebManager.Areas.GIAOVIEN.Controllers
{
    [Area("GIAOVIEN")]
    public class matkhauController : Controller
    {
        DAO_Acount dao = new DAO_Acount();
        // GET: GIAOVIEN/matkhau
        public ActionResult Index()
        {
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {
               
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public ActionResult ChangePassword( Acount_model model)
            
        {
           
            model.IDTeacher = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, CommonConstant.ID_SESSION);
            if(dao.Change_Pass(model) == 0)
            {
                TempData["msg"] = "<script>alert('Thay đổi mật khẩu thành công');</script>";
            }
            else
            {
                if(dao.Change_Pass(model) == 1)
                {
                    TempData["msg"] = "<script>alert('Mật khẩu cũ không đúng');</script>";
                }
                else
                {
                    TempData["msg"] = "<script>alert('Không tồn tại tài khoản');</script>";
                }
            }
            return RedirectToAction("Index", "matkhau");
        }
    }
}