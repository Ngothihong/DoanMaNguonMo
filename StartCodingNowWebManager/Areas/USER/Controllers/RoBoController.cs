using StartCodingNowWebManager.DAO;
using StartCodingNowWebManager.FF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sakura.AspNetCore;
using Microsoft.AspNetCore.Mvc;

using StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI;
using StartCodingNowWebManager.ApiCommunicationTools;

namespace StartCodingNowWebManager.Areas.USER.Controllers
{
    [Area("USER")]
    public class RoBoController : Controller
    {
        //có mà. với tui mlowis đổi cái chuỗi kết nối QL_SCN
        // GET: USER/RoBoK
       // private QL_SCN db = new QL_SCN();
        DAO_Product dp = new DAO_Product();
        private object list;

        public ActionResult Index(string txt_search,int page = 1, int pagesize = 9  )
        {
            
            if (txt_search == null)
            {
                list = dp.listpd(page, pagesize);
            }
            else
            {
                list = dp.search(txt_search,1,5);
            }
            return View(list);
        }

        public ActionResult Detail(string ID)
        {

            //List<object> listpd = new List<object>();
            //listpd.Add(dp.ViewDetail(ID));
            //listpd.Add(dp.top3_pd());
            var listpd = dp.ViewDetail(ID);
            return View(listpd);
        }
        
        public ActionResult Top3_Product()
        {
            var data = new List<ProductModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.GetAllProducts();
                if (data != null)
                {
                    ViewData["Top3"] = data.Take(3).ToList();
                    return PartialView();
                }
                else return PartialView();
            }
            catch
            {
                return PartialView();
            }
            
            
        }



    }
}