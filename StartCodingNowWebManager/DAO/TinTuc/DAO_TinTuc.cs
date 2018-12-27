using StartCodingNowWebManager.ApiCommunicationModels.HongHeoAPI;
using StartCodingNowWebManager.ApiCommunicationTools;
using StartCodingNowWebManager.FF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartCodingNowWebManager.DAO.TinTuc
{
    public class DAO_TinTuc
    {
       // public QL_SCN dbb = new QL_SCN();
        public List<ArticleModel> Get_Article()
        {
            var data = new List<ArticleModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.GetAllArticles();
                if (data != null) return data;
                else return null;
            }
            catch
            {
                return null;
            }
           
        }
        public List<ArticleModel> Search_Article(string key)
        {
            var data = new List<ArticleModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.GetAllArticles();
                if (data != null) return data.Where(x => x.Title.Contains(key)).ToList();
                else return null;
            }
            catch
            {
                return null;
            }
          
        }
        public ArticleModel Get_DetailArticle(string id)
        {
            int change = int.Parse(id);
            var data = new List<ArticleModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.GetAllArticles();
                if (data != null) return data.Where(x => x.IdArticle == change).SingleOrDefault();
                else return null;
            }
            catch
            {
                return null;
            }
           
        }
        public bool Update_ARTICLEs(ArticleModel article)
        {
            var data = new List<ArticleModel>();
            var data1 = new Message<ArticleModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.GetAllArticles();
               

                var bien = data.Where(x => x.IdArticle == article.IdArticle).SingleOrDefault();
                if (bien != null)
                {
                    bien.Title = article.Title;
                    bien.Summary = article.Summary;
                    bien.Contents = article.Contents;
                    bien.Day = article.Day;
                    bien.Image = article.Image;
                    bien.Idadmin = article.Idadmin;
                    bien.IdMenu = article.IdMenu;
                    data1 = ApiClientFactory.ThanhDatInstance.UpdateArticle(bien);
                   
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
           
        }
        public bool check_id(string id)
        {
            int cateid = int.Parse(id);
            var data = new List<ArticleModel>();
            try
            {
                data = ApiClientFactory.ThanhDatInstance.GetAllArticles();
                var bien = data.Where(x => x.IdArticle == cateid);
                if (bien != null)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
           
        }
        public bool Insert_Article(ArticleModel article)
        {
            
                try
                {
                    var data = ApiClientFactory.ThanhDatInstance.AddArticle(article);               
                    return true;
                }
                catch
                {
                    return false;
                }
            

        }
        public bool ExitArticle(string id)
        {
            int cateid = int.Parse(id);
            try
            {
                var data = ApiClientFactory.ThanhDatInstance.GetAllArticles();
                var bien = data.Where(x => x.IdArticle == cateid).SingleOrDefault();
                if (bien != null)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
           
        }
        public bool Delete_Article(string id)
        {
            int cateid = int.Parse(id);
            try
            {
                var data = ApiClientFactory.ThanhDatInstance.GetAllArticles();
                var bien = data.Where(x => x.IdArticle == cateid).SingleOrDefault();
                if (bien != null)
                {

                    var data1 = ApiClientFactory.ThanhDatInstance.RemoveArticle(bien.IdArticle);
                    return true;


                }
                return false;
            }
            catch
            {
                return false;
            }
           
        }
    }
}