using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class CourseClient
    {
        public List<CourseModel> GetAllCourse()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Article/GetAllArticles"));
            return GetAsync<List<ArticleModel>>(requestUrl);
        }
    }
}
