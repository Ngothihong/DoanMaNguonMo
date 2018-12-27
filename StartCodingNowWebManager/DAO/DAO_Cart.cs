using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.Net.Mail;
using StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI;
using Sakura.AspNetCore;
using StartCodingNowWebManager.ApiCommunicationTools;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.DAO
{
    public class DAO_Cart
    {
        //QL_SCN db = new QL_SCN();
        public int get_id(OrdersModel od)
        {
            var data = new Message<OrdersModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.AddOrder(od);
                if (data.IsSuccess == true) return data.Data.Idorders;
                else return -1;
            }
            catch
            {
                return -1;
            }
           
        }

        public OrdersModel getby_id(int id)
        {
            var data = new Message<OrdersModel>();
            try
            {
              
                data = ApiClientFactory.ThanhDatInstance.GetOrder(id);
                if (data.IsSuccess == true) return data.Data;
                else return null;
            }
            catch
            {
                return null;
            }
            
        }
        public void sendmail(string subject, string url, string to)
        {
            // 
            string link = "Vui lòng xác thực tài khoản của bạn .<br> Nhấn vào đây : <a href=\"" + url + "\">here</a>";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("testdemo2105@gmail.com", "duy12345678");
            var mail = new MailMessage("testdemo2105@gmail.com", to)
            {
                Subject = subject,
                Body = link,
                IsBodyHtml = true,
            };
            smtp.Send(mail);
            // thôi vâ cai úer cũng ok rô , h chơ cái admin

        }

        public IEnumerable<OrdersModel> listod(int page, int pagesize)
        {
            var data = new List<OrdersModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.GetAllOrders();
                if (data != null) return data.OrderByDescending(x => x.Idorders).ToPagedList(pagesize, page);
                else return null;
            }
            catch
            {
                return null;
            }
            
        }
        public IEnumerable<OrdersModel> search(string tk, int page, int pagesize)
        {
            var data = new List<OrdersModel>();
            try
            {
                var id = Convert.ToInt32(tk);
                data = ApiClientFactory.ThanhDatInstance.GetAllOrders();
                if (data != null) return data.Where(x => x.Idorders == id || x.Email == tk).OrderByDescending(x => x.Idorders).ToPagedList(pagesize, page);
                else return null;
            }
            catch
            {
                return null;
            }
           
           
        }

        public IEnumerable<OrdersModel> search_date(DateTime? nkq, int page, int pagesize)
        {
            var data = new List<OrdersModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.GetAllOrders();
                if (data != null) return data.Where(x => x.Date == nkq).OrderByDescending(x => x.Idorders).ToPagedList(pagesize, page);
                else return null;
            }
            catch
            {
                return null;
            }
           
        }
    }
}