using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {
        public List<TeachingClassModel> GetAll()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Class/GetAll"));
            return GetAsync<List<TeachingClassModel>>(requestUrl);
        }

        public List<TeachingClassModel> GetbyDayAndIDClass(DateTime thoigian, int IdClass)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Class/GetbyDayAndIDClass"));
            return GetAsync<List<TeachingClassModel>>(requestUrl);
        }

        public List<TeachingClassModel> GetAllClass1()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Class/GetAllClass"));
            return GetAsync<List<TeachingClassModel>>(requestUrl);
        }

        public List<TeachingClassModel> GetbyIDClass(int Idclass)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Class/GetbyIDClass"));
            return GetAsync<List<TeachingClassModel>>(requestUrl);
        }
    }
}
