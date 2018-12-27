using StartCodingNowWebManager.ApiCommunicationModels.HongHeoAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {
        public List<AdminArticleModel> GetAllAdminArticles()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "AdminArticle/GetAllAdminArticles"));
            return  GetAsync<List<AdminArticleModel>>(requestUrl);
        }
        public Message<AdminArticleModel> GetAdminArticle(string id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "AdminArticle/GetAdminArticle"));
            return  PostAsync<AdminArticleModel,string>(requestUrl, id);
        }
        public Message<AdminArticleModel> AddAdminArticle(AdminArticleModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "AdminArticle/AddAdminArticle"));
            return  PostAsync<AdminArticleModel>(requestUrl, model);
        }
        public Message<AdminArticleModel> UpdateAdminArticle(AdminArticleModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "AdminArticle/UpdateAdminArticle"));
            return  PostAsync<AdminArticleModel>(requestUrl, model);
        }
        public Message<AdminArticleModel> RemoveAdminArticle(string id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "AdminArticle/RemoveAdminArticle"));
            return PostAsync<AdminArticleModel, string>(requestUrl, id);
        }
    }
}
