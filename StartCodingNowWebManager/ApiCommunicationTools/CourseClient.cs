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

        public Message<CourseModel> GetCourse(string id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Course/GetCourse"));
            return PostAsync<CourseModel, string>(requestUrl, id);
        }

        public Message<CourseModel> AddCourse(CourseModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Course/AddCourse"));
            return PostAsync<CourseModel>(requestUrl, model);
        }

        public Message<CourseModel> UpdateCourse(CourseModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Course/UpdateCourse"));
            return PostAsync<CourseModel>(requestUrl, model);
        }

        public Message<CourseModel> DeleteCourse(String id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Course/DeleteCourse"));
            return PostAsync<CourseModel,String>(requestUrl,id);
        }

        public Message<CourseModel> SearchCourse(string search)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Course/SearchCourse"));
            return PostAsync<CourseModel, string>(requestUrl, search);
        }

        public Message<CourseModel> FilterCoursesByAge(string age)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Course/FilterCoursesByAge"));
            return PostAsync<CourseModel, string>(requestUrl, age);
        }

        public Message<CourseModel> FilterCoursesByPrice(string price)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Course/FilterCoursesByPrice"));
            return PostAsync<CourseModel, string>(requestUrl, price);
        }
    }
}
