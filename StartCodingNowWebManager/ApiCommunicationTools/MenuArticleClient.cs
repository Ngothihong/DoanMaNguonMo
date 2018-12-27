using StartCodingNowWebManager.ApiCommunicationModels.HongHeoAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {
        public List<MenuArticleModel> GetAllMenuArticles()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "MenuArticle/GetAllMenuArticles"));
            return  GetAsync<List<MenuArticleModel>>(requestUrl);
        }
        public Message<MenuArticleModel> GetMenuArticle(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "MenuArticle/GetMenuArticle"));
            return  PostAsync<MenuArticleModel,int>(requestUrl, id);
        }

        public Message<MenuArticleModel> AddMenuArticle(MenuArticleModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "MenuArticle/AddMenuArticle"));
            return  PostAsync<MenuArticleModel>(requestUrl, model);
        }

        public Message<MenuArticleModel> UpdateMenuArticle(MenuArticleModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "MenuArticle/UpdateMenuArticle"));
            return  PostAsync<MenuArticleModel>(requestUrl, model);
        }
        public Message<MenuArticleModel> RemoveMenuArticle(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "MenuArticle/RemoveMenuArticle"));
            return PostAsync<MenuArticleModel, int>(requestUrl, id);
        }
    }
}
