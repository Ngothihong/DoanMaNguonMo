using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {
        public List<RegistrationCourseModel> GetAllRegister()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Register/GetAllRegister"));
            return GetAsync<List<RegistrationCourseModel>>(requestUrl);
        }
        

        public Message<RegistrationCourseModel> AddRegister(RegistrationCourseModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Register/AddRegister"));
            return PostAsync<RegistrationCourseModel>(requestUrl, model);
        }

        public Message<RegistrationCourseModel> UpdateRegister(RegistrationCourseModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Register/UpdateCourse"));
            return PostAsync<RegistrationCourseModel>(requestUrl, model);
        }

        
    }
}
