using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartCodingNowWebManager.Areas.ADMIN.Models;
using StartCodingNowWebManager.Areas.GIAOVIEN.Models;
using StartCodingNowWebManager.DAO.ADMIN;
using Microsoft.AspNetCore.Mvc;
using Sakura.AspNetCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StartCodingNowWebManager.Areas.ADMIN.Controllers
{
    [Area("ADMIN")]
    public class Teaching_classController : Controller
    {
        // GET: ADMIN/Teaching_class
        DAO_Teaching_class dao = new DAO_Teaching_class();
        public ActionResult Index(int? page)
        {
            SetViewBagLop();
            SetViewBagSesssion();
            var list = dao.GetAll();
            //return View(list);
            int pagesize = 15;
            int pagenumber = (page ?? 1);
            return View(list.ToPagedList(pagesize,pagenumber ));

        }
        public void SetViewBagLop()
        {
            var list = dao.GetAllClass();
            ViewBag.lop = new SelectList(list.ToList(), "IDClass", "NameClass");
        }
        public List<GIAOVIEN.Models.Month> Create_Month()
        {
            List<Month> months = new List<Month>();
            for (int i = 1; i <= 12; i++)
            {
                Month month = new Month();
                month.ID = i;
                month.Name = "Tháng " + i.ToString();
                months.Add(month);
            }
            return months;
        }
        private void SetViewBagSesssion() // session
        {
            ViewBag.session = new SelectList(Create_Month(), "ID", "ID");
        }
        private void SetViewBagMonth() // session
        {
            ViewBag.month = new SelectList(Create_Month(), "ID", "ID");
        }
        public ActionResult Search(int lop,  DateTime? day , int ?page)
        {
                if (day != null)
                {
                    var model = dao.GetbyDAyAndIDClass((DateTime)day, lop);
                SetViewBagLop();
                int pagesize = 15;
                int pagenumber = (page ?? 1);
                return View("Index",model.ToPagedList(pagesize,pagenumber ));
               // return View("Index", model);
                }
                else
                {
                    var model = dao.GetbyIDClass(lop);
                SetViewBagLop();
                int pagesize = 15;
                int pagenumber = (page ?? 1);
                return View("Index", model.ToPagedList(pagesize,pagenumber ));
                //return View("Index", model);
            }
            
        }
    }
}