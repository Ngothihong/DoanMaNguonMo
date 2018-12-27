using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.Areas.GIAOVIEN.Models;



namespace StartCodingNowWebManager.DAO.GIAOVIEN
{
    public class DAO_Lop
    {
        QL_SCN db = new QL_SCN();

        public IEnumerable<Class_model> GetByIDTeacher(int IDteacher)
        {
            // return db.Class.ToList();
            var list = (from x in db.Phanbo
                        join y in db.Class
                        on x.Idclass equals y.Idclass
                        join z in db.Course
                        on y.Idcourse equals z.Idcourse
                        where x.Idteacher == IDteacher
                        orderby y.Idclass ascending
                        select new Class_model
                        {
                            IDClass = y.Idclass,
                            NameCourse = z.Name,
                            NameClass = y.NameClass,
                            StartDay = y.StartDay,
                            FinishDay = y.FinishDay,
                            Number = y.Number,
                            State = y.State
                        }).Distinct();
            return list.ToList().Distinct();
        }
        public IEnumerable<Class_model> GetByIDTeacherandNameCourse(int IDteacher, string nameCouser)
        {
            // return db.Class.ToList();
            var list = (from x in db.Phanbo
                        join y in db.Class
                        on x.Idclass equals y.Idclass
                        join z in db.Course
                        on y.Idcourse equals z.Idcourse
                        where x.Idteacher == IDteacher && z.Name == nameCouser
                        orderby y.Idclass ascending
                        select new Class_model
                        {
                            IDClass = y.Idclass,
                            NameCourse = z.Name,
                            NameClass = y.NameClass,
                            StartDay = y.StartDay,
                            FinishDay = y.FinishDay,
                            Number = y.Number,
                            State = y.State
                        }).Distinct();
            return list.ToList().Distinct();
        }

        public List<Class_model> GetClassModels(string searchNameCourse , int IDteacher)
        {
            List<Class_model> list = (from x in db.Phanbo
                                      join y in db.Class
                                     on x.Idclass equals y.Idclass
                                      join z in db.Course
                                     on y.Idcourse equals z.Idcourse
                                     where x.Idteacher == IDteacher && z.Name == searchNameCourse
                                      orderby y.Idclass ascending
                                     select new Class_model
                                     {
                                         IDClass = y.Idclass,
                                         NameCourse = z.Name,
                                         NameClass = y.NameClass,
                                         StartDay = y.StartDay,
                                         FinishDay = y.FinishDay,
                                         Number = y.Number,
                                         State = y.State
                                     }).Distinct().ToList();
            return list;
        }


    }
}