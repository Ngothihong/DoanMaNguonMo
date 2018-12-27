using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using StartCodingNowWebManager.FF;
using Sakura.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI;
using StartCodingNowWebManager.ApiCommunicationTools;

namespace StartCodingNowWebManager.Areas.USER.Controllers
{
    [Area("USER")]
    public class XemDonHangController : Controller
    {
       // QL_SCN db = new QL_SCN();
        // GET: USER/XemDonHang
        public ActionResult Index(string timkiem)
        {
            var data = new List<OrdersModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.GetAllOrders();
                if (data != null)
                {
                    var list = data.Where(x => x.Email == timkiem).OrderByDescending(x => x.Idorders).ToPagedList(5, 1);
                    return View(list);
                }
                else return View();
            }
            catch
            {
                return View();
            }
            

            
            
        }
        public ActionResult ViewDetail(int id)
        {
            var dto = new List<DetailOrdersModel>();
            var pd = new List<ProductModel>();
            try
            {
                dto = ApiClientFactory.ThanhDatInstance.GetAllDetailOrders();
                pd = ApiClientFactory.ThanhDatInstance.GetAllProducts();
            }
            catch
            {
                dto = null;
                pd = null;
            }

            var query = (from a in dto
                         join b in pd on a.Idrobot equals b.Idrobot
                         where a.Idorders == id
                         select new StartCodingNowWebManager.Areas.USER.Models.ViewDonHang()
                         {
                             Number = a.Number,
                             Price = a.Price,
                             IDRobot = a.Idrobot,
                             Image = b.Image,
                             Name = b.Name,
                             Contents = b.Contents,
                         }).ToList();
            return View(query);
        }
        
        public ActionResult Huy(int id)
        {
            var odm = new List<OrdersModel>();
            var dto = new List<DetailOrdersModel>();
            var pdm = new List<ProductModel>();
            try
            {
                odm = ApiClientFactory.ThanhDatInstance.GetAllOrders();
                dto = ApiClientFactory.ThanhDatInstance.GetAllDetailOrders();
                pdm = ApiClientFactory.ThanhDatInstance.GetAllProducts();
            }
            catch
            {
                odm = null;
                dto = null;
                pdm = null;
            }



            var od = odm.SingleOrDefault(x => x.Idorders == id);
            od.State = 0;
            try
            {
                var addor = ApiClientFactory.ThanhDatInstance.UpdateOrder(od);
            }
            catch
            {
                throw;
            }           
           
            List<DetailOrdersModel> dod = dto.Where(x => x.Idorders == od.Idorders).ToList();

            foreach (var item in dod)
            {
                var pd = pdm.SingleOrDefault(x => x.Idrobot == item.Idrobot);

                pd.Number = pd.Number + item.Number;
                try
                {
                    var addor = ApiClientFactory.ThanhDatInstance.UpdateProduct(pd);
                }
                catch
                {
                    throw;
                }
               
            }
            

            return RedirectToAction("Index", "XemDonHang",new { area="USER"});
        }
    }
}