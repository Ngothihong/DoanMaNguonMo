using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.Areas.GIAOVIEN.Models;

namespace StartCodingNowWebManager.DAO.GIAOVIEN
{
    public class DAO_Teaching_class
    {
        QL_SCN db = new QL_SCN();
        public IEnumerable<Teacher_Attendance> GetALL( int Idteacher)
        {
            var list = (from a in db.Class
                        join b in db.TeachingClass
                        on a.Idclass equals b.Idclass
                        orderby a.NameClass descending
                        where b.Idteacher == Idteacher 
                        select new Teacher_Attendance
                        {
                            ID = b.Id,
                            IDClass = b.Idclass,
                            IDTeacher = b.Idteacher,
                            NameClass = a.NameClass,
                            session = b.Session,
                            Day = b.Day,
                            State = b.State,
                        }).Distinct();
            return list.OrderByDescending(x => x.NameClass).Distinct();
        }
      
        public List<Teacher_Attendance> GetALL_Idteacher_IDmonth(int Idteacher , int month)
        {
            var list = (from a in db.Class
                        join b in db.TeachingClass
                        on a.Idclass equals b.Idclass
                        orderby b.Day descending
                        where b.Idteacher == Idteacher && b.Day.Month == month 
                        select new Teacher_Attendance
                        {
                            ID = b.Id,
                            IDClass = b.Idclass,
                            IDTeacher = b.Idteacher,
                            NameClass = a.NameClass,
                            session = b.Session,
                            Day = b.Day,
                            State = b.State,
                        }).ToList().Distinct();
            return list.ToList();
        }
        public List<Teacher_Attendance> GetALL_Idteacher_IDLop(int Idteacher, int IDlop)
        {
            var list = (from a in db.Class
                        join b in db.TeachingClass
                        on a.Idclass equals b.Idclass
                        orderby b.Day descending
                        where b.Idteacher == Idteacher && b.Idclass == IDlop  
                        select new Teacher_Attendance
                        {
                            ID = b.Id,
                            IDClass = b.Idclass,
                            IDTeacher = b.Idteacher,
                            NameClass = a.NameClass,
                            session = b.Session,
                            Day = b.Day,
                            State = b.State,
                        }).ToList().Distinct();
            return list.ToList();
        }
        public TeachingClass getbyIdclass(int ID) // ID cua teaching_class
        {
            return db.TeachingClass.Where(x => x.Id == ID).SingleOrDefault();
        }
        public string get_NameClass( int ID)// ID cua teaching_class
        {
            var Nameclass = (from a in db.TeachingClass
                             join b in db.Class
                             on a.Idclass equals b.Idclass
                             where a.Id == ID
                             select b.NameClass).ToString();
            return Nameclass;
        }
        public bool Exist_Teaching_Class(TeachingClass model)
        {
            var x = db.TeachingClass.Where(a => a.Idteacher == model.Idteacher && a.Idclass == model.Idclass && a.Session == model.Session).SingleOrDefault();
            if (x != null)
                return true;
            return false;
        }
        public bool Kiemtrangaychamcong(TeachingClass model)
        {
            var mainclass = db.Class.Where(a => a.Idclass == model.Idclass).SingleOrDefault();
            if (model.Day >= mainclass.StartDay && model.Day <= mainclass.FinishDay)
            {
                return true;
            }
            else
                return false;
        }
        public int Add_TEaching_class1(TeachingClass model)
        {
            if (Kiemtrangaychamcong(model))
            {
                db.TeachingClass.Add(model);
                db.SaveChanges();
                if (Exist_Teaching_Class(model))
                    return 1; // them thanh cong
                else
                    return 2; // them ko thanh cong
            }
            else
                return 3;//  ngay trung
        }
        
        public bool Update_Teaching_class(TeachingClass model)
        {
            var x = db.TeachingClass.Where(a => a.Idteacher == model.Idteacher && a.Idclass == model.Idclass && a.Session == model.Session && a.Day == model.Day).SingleOrDefault();
            if (x == null) // không ton tai
            {
                var bien = db.TeachingClass.Where(a => a.Id == model.Id).Single();
                bien.Idclass = model.Idclass;
                bien.Idteacher = model.Idteacher;
                bien.Session = model.Session;
                bien.Day = model.Day;
                bien.State = model.State;
                db.SaveChanges();
                return true;
            }
            else
            return false;
           
        }
        public int Update_Teaching_class1(TeachingClass model)
        {
            var x = db.TeachingClass.Where(a => a.Idteacher == model.Idteacher && a.Idclass == model.Idclass && a.Session == model.Session && a.Day == model.Day).SingleOrDefault();
            if (x == null) // không ton tai
            {
                if (Kiemtrangaychamcong(model))
                {
                    var bien = db.TeachingClass.Where(a => a.Id == model.Id).Single();
                    bien.Idclass = model.Idclass;
                    bien.Idteacher = model.Idteacher;
                    bien.Session = model.Session;
                    bien.Day = model.Day;
                    bien.State = model.State;
                    db.SaveChanges();
                    return 1; // update thanh cong
                }
                else
                {
                    return 2; // ngay cham cong khong nam trong thoi gian hoat dong cua lop học
                }
               
            }
            else
                return 3; // ngay cong da ton tai

        }
        public bool Delete_teaching_class( int ID)
        {
            var model = db.TeachingClass.Where(a => a.Id == ID).SingleOrDefault();
            db.TeachingClass.Remove(model);
            db.SaveChanges();
            var bien = db.TeachingClass.Where(a => a.Id == ID).SingleOrDefault();
            if ( bien == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<Luong_model> GetALLLuong( int Idteacher)
        {
            var model = from a in db.TeachingClass
                        where a.Idteacher == Idteacher && a.Day.Year == DateTime.Today.Year
                        group a by a.Day.Month into thang
                        select new Luong_model
                        {
                            month = thang.Key,
                            year = DateTime.Today.Year,
                            numbersessiong = thang.Count(),
                            monye = thang.Count() * 100 

                        };
            return model.ToList();

        }
        //public IEnumerable<Teacher_Attendance> GetTodayClasses()
        //{
        //    var list = (from a in db.CLASS_STUDENT
        //                join b in db.Class
        //                on a.Idclass equals b.Idclass
        //                where a.Day.Day == DateTime.Now.Day
        //                && a.Day.Month == DateTime.Now.Month
        //                && a.Day.Year == DateTime.Now.Year
        //                select new Teacher_Attendance
        //                {
        //                    Idclass = a.Idclass,
        //                    NameClass = b.NameClass,
        //                    session = a.Session,
        //                    Day = a.Day,
        //                    State = a.State
        //                }
        //                ).ToList();
        //    var list = (from a in db.CLASS_STUDENT
        //                from b in db.Class
        //                where a.Idclass == b.Idclass
        //                where a.Day.Day == DateTime.Now.Day
        //                 && a.Day.Month == DateTime.Now.Month
        //                 && a.Day.Year == DateTime.Now.Year
        //                where !(db.TEACHING_CLASS.Any(x => x.Idclass == a.Idclass))

        //                select new Teacher_Attendance
        //                {
        //                    Idclass = a.Idclass,
        //                    NameClass = b.NameClass,
        //                    session = a.Session,
        //                    Day = a.Day,
        //                    State = a.State
        //                }
        //                ).Distinct();
        //    return list.Distinct();
        //}
        public IEnumerable<Teacher_Attendance> GetTodayAdded(int Idteacher)
        {

            var list = (from a in db.Class
                        join b in db.TeachingClass
                        on a.Idclass equals b.Idclass
                        orderby b.Day descending
                        where b.Idteacher == Idteacher
                        where b.Day.Day == DateTime.Now.Day
                         && b.Day.Month == DateTime.Now.Month
                         && b.Day.Year == DateTime.Now.Year
                        select new Teacher_Attendance
                        {
                            IDClass = b.Idclass,
                            IDTeacher = b.Idteacher,
                            NameClass = a.NameClass,
                            session = b.Session,
                            Day = b.Day,
                            State = b.State,
                        }).Distinct();
            return list.Distinct();
        }
        public void Insert(TeachingClass tc)
        {
            db.TeachingClass.Add(tc);
            db.SaveChanges();
        }
        public void Delete(int Idclass, int Idteacher)
        {
            db.TeachingClass.RemoveRange(db.TeachingClass.Where(x => x.Idclass == Idclass).Where(x => x.Idteacher == Idteacher)
                                                            .Where(x => x.Day.Day == DateTime.Now.Day)
                                                            .Where(x => x.Day.Month == DateTime.Now.Month)
                                                            .Where(x => x.Day.Year == DateTime.Now.Year));
            db.SaveChanges();
        }
    }
}