using StartCodingNowWebManager.ApiCommunicationModels.HongHeoAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {
        public List<ArticleModel> GetAllArticles()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Article/GetAllArticles"));
            return  GetAsync<List<ArticleModel>>(requestUrl);
        }
        public Message<ArticleModel> GetArticle(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Article/GetArticle"));
            return  PostAsync<ArticleModel,int>(requestUrl, id);
        }

        public Message<ArticleModel> RemoveArticle(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Article/RemoveArticle"));
            return PostAsync<ArticleModel, int>(requestUrl, id);
        }
        public Message<ArticleModel> AddArticle(ArticleModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Article/AddArticle"));
            return  PostAsync<ArticleModel>(requestUrl, model);
        }
        public Message<ArticleModel> UpdateArticle(ArticleModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Article/UpdateArticle"));
            return  PostAsync<ArticleModel>(requestUrl, model);
        }
       
    }
}
