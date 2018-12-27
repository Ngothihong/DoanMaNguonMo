using System;
using System.Collections.Generic;
using System.Linq;
using Sakura.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StartCodingNowWebManager.Helpers;
using StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI;
using StartCodingNowWebManager.ApiCommunicationTools;

namespace StartCodingNowWebManager.Areas.USER.Controllers
{
    [Area("USER")]
    public class HomeController : Controller
    {
      StartCodingNowWebManager.FF.QL_SCN db = new FF.QL_SCN();

        public ActionResult ListNews_Course()
        {
            var model = db.Course.Where(x => x.Idcourse != null).ToList();
            return View(model);
        }


        // GET: USER/Home
        public ActionResult Index()
        {
            return View();
        }

      
        public PartialViewResult Header_Cart()
        {
            var cart = SessionHelper.GetObjectFromJson<List<USER.Models.Cart_items>>(HttpContext.Session, Common.CommonConstant.CartSession);
           // var cart =Session[Common.CommonConstant.CartSession];
            var list = (List<USER.Models.Cart_items>)cart;
            if (cart != null)
            {
                list = (List<USER.Models.Cart_items>)cart;
            }
            return PartialView(list);
        }
        

        public ActionResult ListNews_SP()
        {
            var data = new List<ProductModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.GetAllProducts();
                if (data != null) return View(data.Where(x => x.Idrobot != null).ToList());
                else return View();
            }
            catch
            {
                return View();
            }
           
        }

        
       

    }


}