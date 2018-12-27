using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {
        public List<TeacherModel> GetAllTeacher()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Teacher/GetAllTeacher"));
            return GetAsync<List<TeacherModel>>(requestUrl);
        }
        public Message<TeacherModel> GetTeacher(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Teacher/GetTeacher"));
            return PostAsync<TeacherModel, int>(requestUrl, id);
        }
        public Message<TeacherModel> AddTeacher(TeacherModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Teacher/AddTeacher"));
            return PostAsync<TeacherModel>(requestUrl, model);
        }
        public Message<TeacherModel> UpdateTeacher(TeacherModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Teacher/UpdateTeacher"));
            return PostAsync<TeacherModel>(requestUrl, model);
        }
        public Message<TeacherModel> SearchTeacher(string id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Teacher/SearchTeacher"));
            return PostAsync<TeacherModel, string>(requestUrl, id);
        }
        public Message<TeacherModel> DeleteTeacher(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Teacher/DeleteTeacher"));
            return PostAsync<TeacherModel, int>(requestUrl, id);
        }
    }
}
