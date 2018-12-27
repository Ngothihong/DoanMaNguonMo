using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.Areas.GIAOVIEN.Models;

namespace StartCodingNowWebManager.DAO.GIAOVIEN
{
    public class DAO_Class_Student
    {
        QL_SCN db = new QL_SCN();
        public IEnumerable<Student_Attendance> GetALl(int IDclass)
        {
            var list = (from a in db.ClassStudent
                        join b in db.Student
                        on a.Idstudent equals b.Idstudent
                        where a.Idclass == IDclass
                        orderby b.Idstudent
                        select new Student_Attendance
                        {
                            IDClass = a.Idclass,
                            IDStudent = b.Idstudent,
                            NameStudent = b.Name,
                            Session = a.Session,
                            Day = (DateTime)a.Day,
                            State = a.State,
                        }).Distinct();
            return list.ToList().Distinct();

        }
        public Teacher_Attendance getByClassInfoByID(int ID)
        {
            var model = (from a in db.ClassStudent
                         where a.Idclass == ID
                        select new Teacher_Attendance
                        {
                            IDClass = ID,
                            session = a.Session,
                            Day = (DateTime)a.Day,
                            State = a.State
                        }).FirstOrDefault();
            return model;
        }
        public string GetName_student (int IDstudent)
        {
            var name = (from a in db.Student
                        where a.Idstudent == IDstudent
                        select a).SingleOrDefault();
            return name.Name.ToString();
        }
        
        public List<Student_Change__Attendance> _GetALL(int IDClass)
        {
            var model = (from b in db.ClassStudent
                         where b.Idclass == IDClass
                        orderby b.Idstudent
                        select b).ToList();
            List<Student_Change__Attendance> list = new List<Student_Change__Attendance>(); 
           for (int i = 0;  i< model.Count; i ++)
            {
                Student_Change__Attendance std = new Student_Change__Attendance();
                std.IDClass = model[i].Idclass;
                std.IDStudent = model[i].Idstudent;
                std.NameStudent = GetName_student(model[i].Idstudent).ToString();
                 // session = std.state[] + 1;
                for (int j = i; j < (i + 12); j ++)
                {
                    if ((int)model[j].State == 1)
                        std.state[model[j].Session - 1] = true;
                    else
                        std.state[model[j].Session - 1] = false;
                }
                list.Add(std);
                i = i + 11;
            }

            return list;
        }
        public List<Student_Change__Attendance> GetALL(int IDteacher)
        {
            var model = (from b in db.ClassStudent
                         join a in db.Phanbo
                         on b.Idclass equals a.Idclass
                         where a.Idteacher == IDteacher
                         orderby b.Idstudent
                         select b).Distinct().ToList();
            List<Student_Change__Attendance> list = new List<Student_Change__Attendance>();
            for (int i = 0; i < model.Count; i++)
            {
                Student_Change__Attendance std = new Student_Change__Attendance();
                std.IDClass = model[i].Idclass;
                std.IDStudent = model[i].Idstudent;
                std.NameStudent = GetName_student(model[i].Idstudent).ToString();
                // session = std.state[] + 1;
                for (int j = i; j < (i + 12); j++)
                {
                    if ((int)model[j].State == 1)
                        std.state[model[j].Session - 1] = true;
                    else
                        std.state[model[j].Session - 1] = false;
                }
                list.Add(std);
                i = i + 11;
            }

            return list;
        }

        public bool Update(ClassStudent model)
        {
            var bien = (from a in db.ClassStudent
                        where a.Idclass == model.Idclass && a.Idstudent == model.Idstudent && a.Session == model.Session
                       select a).SingleOrDefault();
            if (bien != null)
            {
                bien.State = model.State;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
        
    }
   
}