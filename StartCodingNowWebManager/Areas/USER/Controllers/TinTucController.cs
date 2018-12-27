using System;
using System.Collections.Generic;

using System.Linq;

using StartCodingNowWebManager.FF;
using Sakura.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartCodingNowWebManager.ApiCommunicationModels.HongHeoAPI;
using StartCodingNowWebManager.ApiCommunicationTools;

namespace StartCodingNowWebManager.Areas.USER.Controllers
{
    [Area("USER")]
    public class TinTucController : Controller
    {
        // GET: USER/TinTuc
        //  QL_SCN db = new QL_SCN();
        public ActionResult ListAr()
        {

            return View();
        }
        public ActionResult PartialListAr()
        {
            var data = new List<ArticleModel>();
            try
            {
                data = ApiClientFactory.HongHeoInstance.GetAllArticles();
                if (data != null)
                {
                    var model = data.Where(x => x.IdArticle > 0).ToList();
                    return PartialView("PartialListAr", model);
                }
                else return PartialView("PartialListAr", null);
            }
            catch
            {
                return PartialView("PartialListAr", null);
            }


        }
        public ActionResult Showar(string id)
        {
            int arid = int.Parse(id);
            var data = new List<ArticleModel>();
            try
            {
                data = ApiClientFactory.HongHeoInstance.GetAllArticles();
                if (data != null)
                {
                    var cate = data.FirstOrDefault(x => x.IdArticle == arid);
                    return View(cate);
                }
                else return View();
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Aredit(string id)
        {
            int cateid = int.Parse(id);
            var data = new List<ArticleModel>();
            try
            {
                data = ApiClientFactory.HongHeoInstance.GetAllArticles();
                var cate = data.FirstOrDefault(x => x.IdArticle == cateid);
                return View(cate);
            }
            catch
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult Aredit(ArticleModel model)
        {

            var data = new Message<ArticleModel>();
            try
            {
                data = ApiClientFactory.HongHeoInstance.UpdateArticle(model);
                return View("ListAr");
            }
            catch
            {
                return View("ListAr");
            }

        }
        public ActionResult EditAr()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditAr(ArticleModel ar)
        {
            if (ModelState.IsValid)
            {
                var data = new Message<ArticleModel>();
                try
                {
                    data = ApiClientFactory.HongHeoInstance.AddArticle(ar);
                    return View("ListAr");
                }
                catch
                {
                    return View("ListAr");
                }
            }
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TrangChu()
        {
            return View();
        }
        public ActionResult ListNews()
        {
            var data = new List<ArticleModel>();
            var data1 = new List<MenuArticleModel>();
            try
            {
                data = ApiClientFactory.HongHeoInstance.GetAllArticles();               
                var model = data.Where(x => x.IdArticle > 1).ToList();
              
                return View(model);
            }
            catch
            {
                return View();
            }

        }

        public ActionResult ListNews_1()
        {
            var data = new List<ArticleModel>();
            try
            {
                data = ApiClientFactory.HongHeoInstance.GetAllArticles();
                var model = data.Where(x => x.IdArticle > 1).ToList();
                return View(model);
            }
            catch
            {
                return View();
            }

        }


        public ActionResult InNewscate(string cateid, int? page)
        {
            if (cateid != null)
            {
                ViewBag.cateid = cateid;
                int idcate = int.Parse(cateid);
                var data = new List<ArticleModel>();
                var data1 = new List<MenuArticleModel>();
                try
                {
                    data = ApiClientFactory.HongHeoInstance.GetAllArticles();
                    data1 = ApiClientFactory.HongHeoInstance.GetAllMenuArticles();
                    var model = data.Where(x => x.IdMenu == idcate).ToList();
                    var cate = data1.FirstOrDefault(x => x.IdMenu == idcate);
                    ViewBag.cateName = cate.NameMenu;
                    int pagesize = 3;
                    int pagenumber = (page ?? 1);
                    return View(model.ToPagedList(pagesize, pagenumber));
                }
                catch
                {
                    return View();
                }

            }
            else
            {
                return View("Index", "TinTuc");
            }

        }

        [HttpGet]
        public ActionResult Detail(long id)
        {
            if (id > 0)
            {
                var data = new List<ArticleModel>();
                try
                {
                    data = ApiClientFactory.HongHeoInstance.GetAllArticles();
                    var cate = data.Where(x => x.IdArticle == id).FirstOrDefault();
                    ViewBag.tieude = cate.Title;
                    ViewBag.summary = cate.Summary;
                    ViewBag.content = cate.Contents;
                    ViewBag.img = cate.Image;
                    ViewBag.date = cate.Day;
                    return View();
                }
                catch
                {
                    return View();
                }

            }
            else
            {
                return Content("Error !!!");
            }

        }
        public ActionResult Menu()
        {
            var data1 = new List<MenuArticleModel>();
            try
            {
                data1 = ApiClientFactory.HongHeoInstance.GetAllMenuArticles();

                var model = data1.Where(x => x.IdMenu > 0).ToList();
                return View(model);
            }
            catch
            {
                return View();
            }

        }



    }
}