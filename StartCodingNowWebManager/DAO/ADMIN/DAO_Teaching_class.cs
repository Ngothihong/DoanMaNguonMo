using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.Areas.ADMIN.Models;

namespace StartCodingNowWebManager.DAO.ADMIN
{
    public class DAO_Teaching_class
    {
        QL_SCN db = new QL_SCN();
        //cham cong
        public IEnumerable<Teaching_Model> GetAll()
        {
            var model = from a in db.Class
                        join b in db.TeachingClass
                        on a.Idclass equals b.Idclass
                        join c in db.Teacher
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
        public List<Class> GetAllClass()
        {
            return db.Class.ToList();
        }
        public List<Teacher> GetAllTeacher()
        {
            return db.Teacher.ToList();
        }
        public IEnumerable<Teaching_Model> GetbyIDClass( int IDclass)
        {
            var model = from a in db.Class
                        join b in db.TeachingClass
                        on a.Idclass equals b.Idclass
                        join c in db.Teacher
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
            var model = from a in db.Class
                        join b in db.TeachingClass
                        on a.Idclass equals b.Idclass
                        join c in db.Teacher
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
            var model = from a in db.Class
                        join b in db.TeachingClass
                        on a.Idclass equals b.Idclass
                        join c in db.Teacher
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

       public IEnumerable<Teaching_class_model> _GetAllPhanphoi()
        {
            var model = from a in db.Teacher
                        join b in db.Phanbo
                        on a.Idteacher equals b.Idteacher
                        join c in db.Class
                        on b.Idclass equals c.Idclass
                        join d in db.Course
                        on c.Idcourse equals d.Idcourse
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
        public IEnumerable<Teaching_class_model> _GetphabobyIDlopandIDteacher(int IDclass , int IDteacher)
        {
            var model = from a in db.Teacher
                        join b in db.Phanbo
                        on a.Idteacher equals b.Idteacher
                        join c in db.Class
                        on b.Idclass equals c.Idclass
                        join d in db.Course
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
        public IEnumerable<Teaching_class_model> _GetphabobyIDlop(int IDclass)
        {
            var model = from a in db.Teacher
                        join b in db.Phanbo
                        on a.Idteacher equals b.Idteacher
                        join c in db.Class
                        on b.Idclass equals c.Idclass
                        join d in db.Course
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

            var model = db.Phanbo.Where(x => x.Idclass == IDclass && x.Idteacher == IDteacher).SingleOrDefault();
            if (model != null)
                return true;
            else
                return false;

        }
        public bool Add_phanbo( int IDClass, int IDteacher)
        {
            if (!Exist_Teaching_class(IDClass, IDteacher))
            {
                Phanbo pb = new Phanbo();
                pb.Idclass = IDClass;
                pb.Idteacher = IDteacher;
                db.Phanbo.Add(pb);
                db.SaveChanges();
                if (Exist_Teaching_class(IDClass, IDteacher))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public bool Delete_phanbo(int IDClass, int IDteacher)
        {
           
                var model = db.Phanbo.Where(x => x.Idclass == IDClass && x.Idteacher == IDteacher).SingleOrDefault();
            db.Phanbo.Remove(model);
                db.SaveChanges();
                if (!Exist_Teaching_class(IDClass, IDteacher))
                    return true; 
                else
                    return false;
            
        }
    }
    
}