using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {
        public List<CourseModel> GetAllCourse()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Course/GetAllCourse"));
            return GetAsync<List<CourseModel>>(requestUrl);
        }
    }
}
