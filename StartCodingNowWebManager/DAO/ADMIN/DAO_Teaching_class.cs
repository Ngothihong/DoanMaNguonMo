using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.Areas.ADMIN.Models;
using StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI;
using StartCodingNowWebManager.ApiCommunicationTools;

namespace StartCodingNowWebManager.DAO.ADMIN
{
    public class DAO_Teaching_class
    {
       // QL_SCN db = new QL_SCN();
        //cham cong
        public IEnumerable<Teaching_Model> GetAll()
        {
            var model = from a in ApiClientFactory.KimAnhInstance.getAllClass()
                        join b in ApiClientFactory.KimAnhInstance.GetAll()
                        on a.Idclass equals b.Idclass
                        join c in ApiClientFactory.KimAnhInstance.getAllTeacher()
                        on b.Idteacher equals c.Idteacher
                        where a.State == 1
                        select new Teaching_Model
                        {
                            ID = b.Id,
                            IDClass = b.Idclass,
                            NameClass = a.NameClass,
                            IDTeacher = b.Idteacher,
                            Nameteacher = c.Name,
                            session = b.Session,
                            Day = b.Day,
                            State = a.State

                        };
            return model.Distinct().ToList();
        }
        public List<ClassModel> GetAllClass()
        {
            try
            {
                var model = ApiClientFactory.KimAnhInstance.getAllClass();
                return model;
            }
            catch
            {
                return null;
            }
        }
        public List<TeacherModel> GetAllTeacher()
        {
            try
            {
                var model = ApiClientFactory.KimAnhInstance.getAllTeacher();
                return model;
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<Teaching_Model> GetbyIDClass( int IDclass)
        {
            var model = from a in ApiClientFactory.KimAnhInstance.getAllClass()
                        join b in ApiClientFactory.KimAnhInstance.GetAll()
                        on a.Idclass equals b.Idclass
                        join c in ApiClientFactory.KimAnhInstance.getAllTeacher()
                        on b.Idteacher equals c.Idteacher
                        where a.State == 1 && b.Idclass == IDclass
                        select new Teaching_Model
                        {
                            ID = b.Id,
                            IDClass = b.Idclass,
                            NameClass = a.NameClass,
                            IDTeacher = b.Idteacher,
                            Nameteacher = c.Name,
                            session = b.Session,
                            Day = b.Day,
                            State = a.State

                        };
            return model.Distinct().ToList();
        }
        public IEnumerable<Teaching_Model> GetbyDAy(DateTime thoigian)
        {
            var model = from a in ApiClientFactory.KimAnhInstance.getAllClass()
                        join b in ApiClientFactory.KimAnhInstance.GetAll()
                        on a.Idclass equals b.Idclass
                        join c in ApiClientFactory.KimAnhInstance.getAllTeacher()
                        on b.Idteacher equals c.Idteacher
                        where a.State == 1 && b.Day.Month == thoigian.Month && b.Day.Year == thoigian.Year
                        select new Teaching_Model
                        {
                            ID = b.Id,
                            IDClass = b.Idclass,
                            NameClass = a.NameClass,
                            IDTeacher = b.Idteacher,
                            Nameteacher = c.Name,
                            session = b.Session,
                            Day = b.Day,
                            State = a.State

                        };
            return model.Distinct().ToList();
        }
        public IEnumerable<Teaching_Model> GetbyDAyAndIDClass(DateTime thoigian , int IDClass)
        {
            var model = from a in ApiClientFactory.KimAnhInstance.getAllClass()
                        join b in ApiClientFactory.KimAnhInstance.GetAll()
                        on a.Idclass equals b.Idclass
                        join c in ApiClientFactory.KimAnhInstance.getAllTeacher()
                        on b.Idteacher equals c.Idteacher
                        where a.State == 1 && b.Day.Month == thoigian.Month && b.Day.Year == thoigian.Year && b.Idclass == IDClass
                        select new Teaching_Model
                        {
                            ID = b.Id,
                            IDClass = b.Idclass,
                            NameClass = a.NameClass,
                            IDTeacher = b.Idteacher,
                            Nameteacher = c.Name,
                            session = b.Session,
                            Day = b.Day,
                            State = a.State

                        };
            return model.Distinct().ToList();
        }

        // phan bố giảng dạy

       public IEnumerable<TeachingClassModel> _GetAllPhanphoi()
        {
            try
            {
                return ApiClientFactory.KimAnhInstance.GetAll();
            }
            catch
            {
                return null;
            }
            
            
        }
        public List<Teaching_class_model> _GetphabobyIDlopandIDteacher(int IDclass , int IDteacher)
        {
            try
            {
               var model = from a in ApiClientFactory.KimAnhInstance.GetAllTeacher()
                        join b in ApiClientFactory.KimAnhInstance.GetAllPhanphoi()
                        on a.Idteacher equals b.Idteacher
                           join c in ApiClientFactory.KimAnhInstance.getAllClass()
                           on b.Idclass equals c.Idclass
                           join d in ApiClientFactory.KimAnhInstance.GetAllCourse()
                           on c.Idcourse equals d.Idcourse
                           where b.Idclass == IDclass && b.Idteacher == IDteacher
                           select new Teaching_class_model
                           {
                               IDClass = c.Idclass,
                               NameClass = c.NameClass,
                               NameCourse = d.Name,
                               IDteacher = b.Idteacher,
                               NameTeacher = a.Name,
                               Number = c.Number,
                               StartDay = c.StartDay,
                               FinishDay = c.FinishDay,
                           };
                return model.Distinct().ToList();
            }
            catch
            {
                return null;
            }
           
           
        }
        public IEnumerable<Teaching_class_model> _GetphabobyIDlop(int IDclass)
        {
            var model = from a in ApiClientFactory.KimAnhInstance.GetAllTeacher()
                        join b in ApiClientFactory.KimAnhInstance.GetAllPhanphoi()
                        on a.Idteacher equals b.Idteacher
                        join c in ApiClientFactory.KimAnhInstance.getAllClass()
                        on b.Idclass equals c.Idclass
                        join d in ApiClientFactory.KimAnhInstance.GetAllCourse()
                        on c.Idcourse equals d.Idcourse
                        where b.Idclass == IDclass 
                        select new Teaching_class_model
                        {
                            IDClass = c.Idclass,
                            NameClass = c.NameClass,
                            NameCourse = d.Name,
                            IDteacher = b.Idteacher,
                            NameTeacher = a.Name,
                            Number = c.Number,
                            StartDay = c.StartDay,
                            FinishDay = c.FinishDay,
                        };
            return model.Distinct().ToList();
        }
        public bool Exist_Teaching_class(int IDclass, int IDteacher)
        {
            try
            {
                var model = ApiClientFactory.KimAnhInstance.GetAllPhanphoi().Where(x => x.Idclass == IDclass && x.Idteacher == IDteacher).SingleOrDefault();
                if (model != null)
                    return true;
               else
                    return true;

            }
            catch
            {
                return false;
            }

           

        }
        public bool Add_phanbo( int IDClass, int IDteacher)
        {
            try
            {
                var a = ApiClientFactory.KimAnhInstance.AddPhanbo(IDClass, IDteacher);
                return a.IsSuccess;
             }
            catch
            {
                return false;
            }
        }
        public bool Delete_phanbo(int IDClass, int IDteacher)
        {
            try
            {
                var a = ApiClientFactory.KimAnhInstance.RemovePhanbo(IDClass, IDteacher);
                return a.IsSuccess;
            }
            catch
            {
                return false;
            }

        }
    }
    
}