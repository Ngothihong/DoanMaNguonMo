using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//using StartCodingNowWebManager.DAO;
using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.Common;
using StartCodingNowWebManager.DAO;
using Microsoft.AspNetCore.Mvc;
using StartCodingNowWebManager.ApiCommunicationModels.HongHeoAPI;
using StartCodingNowWebManager.Helpers;

namespace StartCodingNowWebManager.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class LoginController : Controller
    {
        // GET: ADMIN/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminArticleModel objUser)
        {

            if (ModelState.IsValid) // kiem tra rong
            {
                var dao = new DAO_Admin();
                var obj = dao.Login(objUser.Idadmin.ToString(), Encryptor.MD5Hash(objUser.Pass).ToString());
                if (obj == 1)
                {

                    var userSession = new UserLogin();
                    userSession.IDuser = objUser.Idadmin;
                    SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.USER_SESSION, userSession.IDuser);

                    return RedirectToAction("Index", "Home");
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

        public ActionResult UserDashBoard()
        {
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}