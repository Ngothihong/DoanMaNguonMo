using Microsoft.AspNetCore.Mvc;
using StartCodingNowWebManager.Common;
using StartCodingNowWebManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace StartCodingNowWebManager.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class HomeController : Controller
    {
        // GET: ADMIN/Home
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
    }
}