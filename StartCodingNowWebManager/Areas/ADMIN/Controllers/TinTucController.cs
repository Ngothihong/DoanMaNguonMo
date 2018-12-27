using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StartCodingNowWebManager.FF;
using System.IO;

using StartCodingNowWebManager.DAO;
using StartCodingNowWebManager.DAO.TinTuc;
using Microsoft.AspNetCore.Mvc;
using Sakura.AspNetCore;
using StartCodingNowWebManager.Helpers;
using StartCodingNowWebManager.Common;
using StartCodingNowWebManager.ApiCommunicationTools;
using StartCodingNowWebManager.ApiCommunicationModels.HongHeoAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace StartCodingNowWebManager.Areas.ADMIN.Controllers
{
   
    [Area("ADMIN")]
    public class TinTucController : Controller
    {
        private IHostingEnvironment _env;
    public TinTucController(IHostingEnvironment env)
    {
        _env = env;
    }
        // GET: ADMIN/TinTuc
       // QL_SCN db = new QL_SCN();
        DAO_TinTuc dao = new DAO_TinTuc();
        public ActionResult ListAr(string Search,int? page)
        {
            var session = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, CommonConstant.USER_SESSION);
            if (!string.IsNullOrEmpty(session))
            {
                var model = dao.Get_Article();
                ViewBag.Search = Search;
                if (!string.IsNullOrEmpty(Search))
                {
                    model = dao.Search_Article(Search);
                    int pagesize = 10;
                    int pagenumber = (page ?? 1);

                    return View(model.ToPagedList(pagesize, pagenumber));
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }


        }
        public ActionResult PartialListAr()
        {
            try
            {
                var articles = ApiClientFactory.HongHeoInstance.GetAllArticles();
                var model = articles.Where(x => x.IdArticle > 0).ToList();
                return PartialView("PartialListAr", model);
            }
            catch
            {
                return PartialView("PartialListAr");
            }
           
        }
        public ActionResult ShowAr(string id)
        {
            try
            {
                var articles = ApiClientFactory.HongHeoInstance.GetAllArticles();
                int arid = int.Parse(id);
                var cate = articles.FirstOrDefault(x => x.IdArticle == arid);
                return View(cate);
            }
            catch
            {
                return View();
            }
            
        }

        public ActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddArticle(ArticleModel article, IFormFile files)
        {
            var uploads = Path.Combine(_env.WebRootPath.Replace("\\wwwroot", ""), "Assets\\Image\\IMGAR");
            // full path to file in temp location
            var filePath = Path.Combine(uploads, article.IdArticle + "_" + article.IdMenu + ".jpg");/*"~/Assets/Image/" + course.Idcourse + "update.jpg";*/
                                                                            //   var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (files.Length > 0)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    files.CopyTo(fileStream);
                }
            }
               
            article.Image = article.IdArticle + "_" + article.IdMenu + ".jpg";
            if (dao.Insert_Article(article))
            {
                TempData["msg"] = "<script>alert('Thêm Thành Công!');</script>";
                return RedirectToAction("ListAr", "TinTuc");
            }
            else
            {
                TempData["msg"] = "<script>alert('Thêm Thất Bại! Lỗi!');</script>";
                return RedirectToAction("AddArticle", "TinTuc");
            }
        }
        public ActionResult EditArticle(string id)
        {
            var bien = dao.Get_DetailArticle(id);
            return View(bien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArticle(ArticleModel article, IFormFile files)
        {
            var uploads = Path.Combine(_env.WebRootPath.Replace("\\wwwroot", ""), "Assets\\Image\\IMGAR");
            // full path to file in temp location
            var filePath = Path.Combine(uploads, article.IdArticle + "_" + article.IdMenu + ".jpg");/*"~/Assets/Image/" + course.Idcourse + "update.jpg";*/
                                                                                                    //   var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (files.Length > 0)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    files.CopyTo(fileStream);
                }
            }
            
            article.Image = article.IdArticle + "_" + article.IdMenu + ".jpg";
            if (dao.Update_ARTICLEs(article))
            {
                TempData["msg"] = "<script>alert('Cập Nhật Thành Công!');</script>";
                return RedirectToAction("ListAr", "TinTuc");
            }
            else
            {
                TempData["msg"] = "<script>alert('Cập Nhật Thất Bại! Lỗi!');</script>";
                return RedirectToAction("EditArticle", "TinTuc");
            }
        }

        //public ActionResult DeleteAr(string id)
        //{
        //    Delte(id);

        //    return View("ListAr");
        //}

        //[HttpPost]
        //private void Delte(string id)
        //{
        //    int cateid = int.Parse(id);
        //    var model = db.ARTICLEs.FirstOrDefault(x => x.ID_Article == cateid);
        //    db.ARTICLEs.Remove(model);
        //    db.SaveChanges();
        //}

        public ActionResult DeleteAr(string id)
        {
            if (dao.Delete_Article(id) == true)
            {
                TempData["msg"] = "<script>alert('Xóa Thành Công!');</script>";
                return RedirectToAction("ListAr", "TinTuc");
            }
            else
            {
                TempData["msg"] = "<script>alert('Xóa Không Thành Công! Lỗi');</script>";
                return RedirectToAction("ListAr", "TinTuc");
            }

        }




        public ActionResult Index()
        {
            return View();
        }
    }
}