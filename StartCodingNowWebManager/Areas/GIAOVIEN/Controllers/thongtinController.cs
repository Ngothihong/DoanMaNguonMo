using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using StartCodingNowWebManager.Common;
using StartCodingNowWebManager.DAO;
using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.Helpers;

namespace StartCodingNowWebManager.Areas.GIAOVIEN.Controllers
{
    [Area("GIAOVIEN")]
    public class thongtinController : Controller
    {
        // GET: GIAOVIEN/thongtin
        DAO_GIAOVIEN dao = new DAO_GIAOVIEN();
        public ActionResult Index()
        {
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {
                var giaovien = dao.GetbyID(SessionHelper.GetObjectFromJson<int>(HttpContext.Session, CommonConstant.ID_SESSION));
                return View(giaovien);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult Update( Teacher tEACHER)
        {
           if(dao.Update(tEACHER))
            {
                TempData["msg"] = "<script>alert('Sửa thông tin thành công');</script>";
                return RedirectToAction("Index", "thongtin");
            }
           else
            {
                TempData["msg"] = "<script>alert('Sửa thông tin không thành công');</script>";
                return RedirectToAction("Index", "thongtin");
            }

        }

    }
}