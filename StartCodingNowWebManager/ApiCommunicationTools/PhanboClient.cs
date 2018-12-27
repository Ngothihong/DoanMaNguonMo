using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {
        public List<PhanboModel> GetAllPhanphoi()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Phanbo/GetAllPhanphoi"));
            return GetAsync<List<PhanboModel>>(requestUrl);
        }
        public List<ClassModel> GetAllClass()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Phanbo/GetAllClass"));
            return GetAsync<List<ClassModel>>(requestUrl);
        }
        public List<TeacherModel> getAllTeacher()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Phanbo/GetAllTeacher"));
            return GetAsync<List<TeacherModel>>(requestUrl);
        }
        public Message<PhanboModel> GetphabobyIdlopandIdteacher(int idclass, int idteacher)
        {
            int[] id= null;
            id[0] = idclass;
            id[1] = idteacher;
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Phanbo/GetphabobyIdlopandIdteacher"));
            return PostAsync<PhanboModel, int[]>(requestUrl, id);
        }
        public Message<PhanboModel> GetphabobyIDlop(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Phanbo/GetphabobyIDlop"));
            return PostAsync<PhanboModel, int>(requestUrl, id);
        }
        public Message<PhanboModel> AddPhanbo(int Idclass, int IdTeacher)
        {
            int[] id = null;
            id[0] = Idclass;
            id[1] = IdTeacher;
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Phanbo/AddPhanbo"));
            return PostAsync<PhanboModel,int[]>(requestUrl, id);
        }
        public Message<PhanboModel> RemovePhanbo(int Idclass, int IdTeacher)
        {
            int[] id = null;
            id[0] = Idclass;
            id[1] = IdTeacher;
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Phanbo/RemovePhanbo"));
            return PostAsync<PhanboModel, int[]>(requestUrl, id);
        }
    }
}
