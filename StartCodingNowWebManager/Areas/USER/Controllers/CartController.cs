using StartCodingNowWebManager.Areas.USER.Models;
using StartCodingNowWebManager.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using StartCodingNowWebManager.Common;
using Sakura.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Newtonsoft.Json;
using System.Data;
using StartCodingNowWebManager.Helpers;
using StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI;
using StartCodingNowWebManager.ApiCommunicationTools;

namespace StartCodingNowWebManager.Areas.USER.Controllers
{
    [Area("USER")]
    public class CartController : Controller
    {
        // GET: USER/Cart
        // private string CartSession = "CartSession";
        // GET: USER/Cart
      //  private FF.QL_SCN db = new FF.QL_SCN();
        DAO_Cart dc = new DAO_Cart();
        public ActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Cart_items>>(HttpContext.Session, CommonConstant.CartSession);
           
            var list = new List<Cart_items>();
            if (cart != null)
            {
                list = (List<Cart_items>)cart;
            }
            return View(list);
        }
        
        public ActionResult AddItems(string product_id, int number)
        {
            var ProDuct = new DAO_Product().ViewDetail(product_id);
            var cart = SessionHelper.GetObjectFromJson<List<Cart_items>>(HttpContext.Session, CommonConstant.CartSession);

            List<Cart_items> ListCart = new List<Cart_items>();
            if (cart != null)
                ListCart = (List<Cart_items>)cart;
            if (ListCart.Any(a => a.product.Idrobot == product_id))
            {
                ListCart.Single(a => a.product.Idrobot == product_id).Quantity++;
            }
            else
            {
                ListCart.Add(new Cart_items() { product = new DAO_Product().ViewDetail(product_id), Quantity = number });
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.CartSession, ListCart);
            var v = SessionHelper.GetObjectFromJson<List<Cart_items>>(HttpContext.Session, CommonConstant.CartSession);

            return RedirectToAction("Index");          
        }
        public JsonResult Update(string cartModel)
        {
           
            var jsonCart = JsonConvert.DeserializeObject<List<StartCodingNowWebManager.Areas.USER.Models.Cart_items>>(cartModel);
          //  var sessionItem = (List<Cart_items>)Session[CommonConstant.CartSession];
            var sessionItem = SessionHelper.GetObjectFromJson<List<Cart_items>>(HttpContext.Session, CommonConstant.CartSession);
            foreach (var item in sessionItem)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.product.Idrobot == item.product.Idrobot);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.CartSession, sessionItem);
            return Json(new
            {
                stastus = true
            });
        }
        public JsonResult Delete(string id)
        {
            var sessionCart = SessionHelper.GetObjectFromJson<List<USER.Models.Cart_items>>(HttpContext.Session, CommonConstant.CartSession);
            //var sessionCart = (List<USER.Models.Cart_items>)Session[CommonConstant.CartSession];
            sessionCart.RemoveAll(x => x.product.Idrobot == id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.CartSession, sessionCart);
           // Session[CommonConstant.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        public ActionResult ThanhToan()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Cart_items>>(HttpContext.Session, CommonConstant.CartSession);
            //var cart = Session[CommonConstant.CartSession];
            var list = new List<Cart_items>();
            if (cart != null)
            {
                list = (List<Cart_items>)cart;
            }
            return View(list);
            
        }
        long tien;
        int count;

        [HttpPost]
        public ActionResult ThanhToan(string txt_hoten , 
            string txt_sdt , string txt_email , string txt_diachi , 
            string txt_ghichu , string txt_tt , string txt_km = "FCL000000")
        {
            int id;
            var cart = SessionHelper.GetObjectFromJson<List<Cart_items>>(HttpContext.Session, CommonConstant.CartSession);
            //var cart = (List<Cart_items>)Session[CommonConstant.CartSession];
            OrdersModel od = new OrdersModel();
            
            try
            {

               
                foreach (var item in cart)
                {
                    tien+= (int)item.product.Price * item.Quantity;
                    count += 1;
                }

                // long tong = tien * id.Value;
                
                od.NameCustomer = txt_hoten;
                od.Phone = txt_sdt;
                od.Address = txt_diachi;
                od.Email = txt_email;
                od.NumberProduct = count;
                od.Idpromotion = txt_km;
                od.PriceTotal = tien;
                od.Date = DateTime.Now;
                od.Payment = txt_tt;
                od.Note = txt_ghichu;
                od.State = 1;
                od.Verify = false;
                id = dc.get_id(od);
                if(id != -1)
                {
                    string url = Url.Action("ConfirmEmail", "Cart", new { ID = id }, HttpContext.Request.Scheme);
                    dc.sendmail("Xác nhận đơn hàng", url, od.Email);
                }
                else
                {
                    ViewBag.ErrorMgs = "Thêm Order thất bại!";
                    return RedirectToAction("Index", "Home");
                }
                
            }
            catch (DataException ex)
            {
               
                throw new DataException(ex.Message);
            }
            try
            {

                foreach (var item in cart)
                {
                    DetailOrdersModel d_od = new DetailOrdersModel();
                    d_od.Idorders = id;
                    d_od.Idrobot = item.product.Idrobot;
                    d_od.Number = item.Quantity;
                    d_od.Price = item.product.Price;

                    var data = new Message<DetailOrdersModel>();
                    try
                    {
                        data = ApiClientFactory.ThanhDatInstance.AddDetailOrder(d_od);                       
                        var getpr = ApiClientFactory.ThanhDatInstance.GetProduct(d_od.Idrobot);
                        getpr.Data.Number= getpr.Data.Number- item.Quantity;                       
                        var t = ApiClientFactory.ThanhDatInstance.UpdateProduct(getpr.Data);
                    }
                    catch
                    {
                        throw;
                    }
                  
                }
            }
            catch (Exception ex) { throw; }
            SessionHelper.SetObjectAsJson(HttpContext.Session, CommonConstant.CartSession, null);
          //  Session[CommonConstant.CartSession] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ConfirmEmail (int ID)
        {
            try
            {
               
                var or = ApiClientFactory.ThanhDatInstance.GetOrder(ID);               
                or.Data.Verify = true;
                var t = ApiClientFactory.ThanhDatInstance.UpdateOrder(or.Data);
                

            }
            catch (DataException ex)
            {

                throw new DataException(ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}