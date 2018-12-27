using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StartCodingNowWebManager.DAO;
using StartCodingNowWebManager.ApiCommunicationTools;

using Microsoft.AspNetCore.Mvc;
using StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI;
using StartCodingNowWebManager.Helpers;
using StartCodingNowWebManager.Common;
using Microsoft.AspNetCore.Http;

namespace StartCodingNowWebManager.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class OrderRoBoController : Controller
    {
       // private QL_SCN db = new QL_SCN();
        DAO_Cart dod = new DAO_Cart();
        OrdersModel d_od = new OrdersModel();
        private object list1;
        // GET: ADMIN/Order
        public ActionResult Index(string tk , Nullable<DateTime> nkq , int? Page )
        {

            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {
                if (tk == null && nkq == null)
                {
                    list1 = dod.listod(Page ?? 1, 6);
                }
                else if (nkq == null)
                {
                    list1 = dod.search(tk, Page ?? 1, 5);
                }
                else
                {
                    list1 = dod.search_date(nkq, Page ?? 1, 10);
                }
                return View(list1);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: ADMIN/Order/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var data1 = ApiClientFactory.ThanhDatInstance.GetAllDetailOrders();
                var data2 = ApiClientFactory.ThanhDatInstance.GetAllProducts();
                var query = (from a in data1
                             join b in data2 on a.Idrobot equals b.Idrobot
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
            catch
            {
                return View();
            }
            
        }
    

        // GET: ADMIN/Order/Create
        public ActionResult Huy(int id)
        {
            try
            {
                var Orders = ApiClientFactory.ThanhDatInstance.GetAllOrders();
                var DetailOrders = ApiClientFactory.ThanhDatInstance.GetAllDetailOrders();
                var Products = ApiClientFactory.ThanhDatInstance.GetAllProducts();
                var od = Orders.SingleOrDefault(x => x.Idorders == id);
                od.State = 0;
                var updateorder = ApiClientFactory.ThanhDatInstance.UpdateOrder(od);
               
                List<DetailOrdersModel> dod = DetailOrders.Where(x => x.Idorders == od.Idorders).ToList();
                foreach (var item in dod)
                {
                    var pd = Products.SingleOrDefault(x => x.Idrobot == item.Idrobot);

                    pd.Number = pd.Number + item.Number;
                    var updateproduct = ApiClientFactory.ThanhDatInstance.UpdateProduct(pd);
                }


                return RedirectToAction("Index", "OrderRoBo");
            }
            catch
            {
                return RedirectToAction("Index", "OrderRoBo");
            }
            
        }

        // POST: ADMIN/Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ADMIN/Order/Edit/5
        public ActionResult Edit(int id)
        {
            try {
                var Orders = ApiClientFactory.ThanhDatInstance.GetAllOrders();
                var od = Orders.SingleOrDefault(x => x.Idorders == id);
                if (od.State < 4)
                {
                    od.State += 1;
                    var updateorder = ApiClientFactory.ThanhDatInstance.UpdateOrder(od);
                }
                return RedirectToAction("Index", "OrderRoBo");
            }
            catch
            {
                return RedirectToAction("Index", "OrderRoBo");
            }
           
        }

        // POST: ADMIN/Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ADMIN/Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ADMIN/Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
