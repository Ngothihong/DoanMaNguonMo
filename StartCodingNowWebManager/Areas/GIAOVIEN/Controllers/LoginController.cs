using StartCodingNowWebManager.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.Common;
using Microsoft.AspNetCore.Mvc;
using StartCodingNowWebManager.Helpers;

namespace StartCodingNowWebManager.Areas.GIAOVIEN.Controllers
{
    [Area("GIAOVIEN")]
    public class LoginController : Controller
    {
        // GET: GIAOVIEN/Login
        public ActionResult Index()
        {
            
            return View();
        }
        
        [HttpGet]
    
        public ActionResult Logout()
        {
           
                    SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.USER_SESSION, null);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.ID_SESSION, null);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.USER_STATE, null);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.ID_TEACHING_CLASS, null);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.ID_CLASS, null);
                    return RedirectToAction("Index", "Login");
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account objUser)
        {
            if (ModelState.IsValid) // kiem tra rong
            {
                var dao = new DAO_GIAOVIEN();
                var obj = dao.Login_Giaovien(objUser.Username, Encryptor.MD5Hash(objUser.Password).ToString());
                if (obj == 1)
                {
                    var _teacher = dao.GetbyAccpunt(objUser.Username, Encryptor.MD5Hash(objUser.Password).ToString());
                    var userTeacher = new SessionTeacher ();
                    userTeacher.IDuser = _teacher.Idteacher;
                    userTeacher.user = dao.GetbyID(_teacher.Idteacher).Name;
                    userTeacher.state = 1;
                    SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.USER_SESSION, userTeacher.user);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.ID_SESSION, userTeacher.IDuser);                  
                    SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.USER_STATE, userTeacher.state);                   
                    SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.ID_TEACHING_CLASS, 10);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.ID_CLASS, null);
                    return RedirectToAction("Index", "thongtin");
                }
                else if (obj == 0)
                {
                    ModelState.AddModelError("", "Tài Khoản Không Tồn Tại");
                }
                else if (obj == -1)
                {
                    ModelState.AddModelError("", "Tài Khoản Đang bị Khóa");
                }
                else if (obj == -2)
                {
                    ModelState.AddModelError("", "Mật Khẩu Không Đúng");
                }
                else
                    ModelState.AddModelError("", "Đăng Nhập Không Đúng");

            }
            return View("Index");
        }
    }
}