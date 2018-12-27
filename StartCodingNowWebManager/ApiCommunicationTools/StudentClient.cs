using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {
        public List<StudentModel> GetAllStudent()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Student/GetAllStudent"));
            return GetAsync<List<StudentModel>>(requestUrl);
        }
        public List<StudentModel> Search_Student(String id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Student/Search_Student"));
            return GetAsync<List<StudentModel>>(requestUrl);
        }
        public Message<StudentModel> Insert_Student(StudentModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Student/Insert_Student"));
            return PostAsync<StudentModel>(requestUrl, model);
        }
        public Message<StudentModel> Update_Student(StudentModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Student/Update_Student"));
            return PostAsync<StudentModel>(requestUrl, model);
        }
        public Message<StudentModel> Delete_Student(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Student/Delete_Student"));
            return PostAsync<StudentModel, int>(requestUrl, id);
        }
        public Message<StudentModel> Class_student(int idstudent, int idclass)
        {
            int[] id= null;
            id[0] = idstudent;
            id[1] = idclass;
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Student/Class_student"));
            return PostAsync<StudentModel, int[]>(requestUrl, id);
        }
    }
}
