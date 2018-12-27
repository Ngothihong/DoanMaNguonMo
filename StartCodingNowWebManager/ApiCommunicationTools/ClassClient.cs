using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {
        public List<ClassModel> getAllClass()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Class/GetAllClass"));
            return GetAsync<List<ClassModel>>(requestUrl);
        }

        public List<ClassModel> Search_Class(string key)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Class/Search_Class"));
            return GetAsync<List<ClassModel>>(requestUrl);
        }

        public List<ClassModel> FindClassById(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Class/FindClassById"));
            return GetAsync<List<ClassModel>>(requestUrl);
        }

        public Message<ClassModel> AddClass(ClassModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Class/AddClass"));
            return PostAsync<ClassModel>(requestUrl, model);
        }

        public Message<ClassModel> UpdateClass(ClassModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Class/UpdateCourse"));
            return PostAsync<ClassModel>(requestUrl, model);
        }

        public Message<ClassModel> RemoveClass(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Class/RemoveClass"));
            return PostAsync<ClassModel, int>(requestUrl, id);
        }

        
    }
}
