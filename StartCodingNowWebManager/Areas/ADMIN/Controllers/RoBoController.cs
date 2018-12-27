using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StartCodingNowWebManager.DAO;

using StartCodingNowWebManager.FF;
using Microsoft.AspNetCore.Mvc;
using StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI;
using StartCodingNowWebManager.Helpers;
using StartCodingNowWebManager.Common;
using StartCodingNowWebManager.ApiCommunicationTools;

namespace StartCodingNowWebManager.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class RoBoController : Controller
    {
       // private QL_SCN db = new QL_SCN();
        DAO_Product dp = new DAO_Product();
        ProductModel pr = new ProductModel();
        private object list1;
        // GET: ADMIN/RoBo
        public ActionResult RoBo(string tk , int? Page)
        {
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {
                if (tk == null)
                {
                    list1 = dp.listpd(Page ?? 1, 5);
                }
                else
                {
                    list1 = dp.search(tk, 1, 5);
                }
                return View(list1);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: ADMIN/RoBo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ADMIN/RoBo/Create
        public ActionResult Them()
        {
            return View();
        }

        // POST: ADMIN/RoBo/Create
        [HttpPost]
        public ActionResult Them(ProductModel pd)
        {
            try
            {
                var addproduct = ApiClientFactory.ThanhDatInstance.AddProduct(pd);
               
                TempData["msg"] = "<script>alert('Thêm Thành Công');</script>";
                return RedirectToAction("Them", "Robo");
            }
            catch
            {
                TempData["msg"] = "<script>alert('Thêm Thất Bại! Lỗi!');</script>";
                return RedirectToAction("Them", "RoBo");
            }
        }

        // GET: ADMIN/RoBo/Edit/5
        public ActionResult Sua(string id)
        {
            var list = dp.ViewDetail(id);
            return View(list);
        }

        // POST: ADMIN/RoBo/Edit/5
        [HttpPost]
        public ActionResult Sua(ProductModel pd)
        {
            
                if (dp.Update(pd)) {
                    // TODO: Add update logic here
                    TempData["msg"] = "<script>alert('Cập Nhật Thành Công');</script>";
                    return RedirectToAction("RoBo", "RoBo"); 
            }
            else
            {
                TempData["msg"] = "<script>alert('Cập Nhật Thất Bại! Lỗi!');</script>";
                return RedirectToAction("Sua", "RoBo");
            }
        
        }

     

        public ActionResult Delete(string id)
        {
            try {
                var getproduct = ApiClientFactory.ThanhDatInstance.RemoveProduct(id);                
                return RedirectToAction("RoBo", "RoBo");
            }
            catch
            {
               
                return RedirectToAction("RoBo", "RoBo");
            }
           
        }

        // POST: ADMIN/RoBo/Delete/5
       
    }
}
