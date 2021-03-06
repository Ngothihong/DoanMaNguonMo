﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.Common;
using StartCodingNowWebManager.Areas.GIAOVIEN.Models;
using StartCodingNowWebManager.ApiCommunicationTools;
using StartCodingNowWebManager.ApiCommunicationModels.KimAnhAPI;

namespace StartCodingNowWebManager.DAO
{
    public class DAO_Admin
    {
        public QL_SCN db = new QL_SCN();
        //public ADMIN Getby(String user, string pass)
        //{
        //    return db.ADMINs.Where(x => x.IDAmin == user && x.Password == pass).SingleOrDefault();
        //}
        public int Login(string user, string pass)
        {
            try
            {
                var data = ApiClientFactory.HongHeoInstance.GetAllAdminArticles();
                var result = data.SingleOrDefault(x => x.Idadmin == user);
                if (result == null)
                    return 0;
                else
                {
                    if (result.Status == 0)
                        return -1;
                    else
                    {
                        if (result.Pass == pass)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
            catch
            {
                return 0;
            }
            

        }

        


        //TEACHER-------------------------------------------------
        public List<TeacherModel> List_Teacher()
        {
            var data = new List<TeacherModel>();
            try
            {
               return data = ApiClientFactory.KimAnhInstance.getAllTeacher();
                
            }
            catch
            {
                return null;
            }
            
        }
        public int Exist_Teacher( string email)
        {
            var _teacher = db.Teacher.Where(x => x.Email == email).SingleOrDefault();
            if (_teacher != null)
            {
                return _teacher.Idteacher;
            }
            return -1;
        }
        public bool Insert_Teacher(TeacherModel tc)
        {

               var m =ApiClientFactory.KimAnhInstance.AddTeacher(tc);
               return m.IsSuccess;
           
            
        }
        public TeacherModel Get_Teacher(int id)
        {
            try
            {
              return ApiClientFactory.KimAnhInstance.GetTeacher(id).Data;
            }
            catch
            {
                return null;
            }
            
        }
        public bool Update_Teacher(TeacherModel tc)
        {
            var m = ApiClientFactory.KimAnhInstance.UpdateTeacher(tc);
            return m.IsSuccess;
            
        }

       
        public bool Delete_Teacher(int id)
        {
            var m = ApiClientFactory.KimAnhInstance.DeleteTeacher(id);
            return m.IsSuccess;
        }
         public List<TeacherModel> Search_Teacher(string key)
        {
            var data = new List<TeacherModel>();
            return data = ApiClientFactory.KimAnhInstance.SearchTeacher(key).Data;
            //return db.Teacher.Where(x => x.Name.Contains(key) || x.Address.Contains(key) || x.Knowledge.Contains(key)).ToList();       
            
        }


        //STUDENT--------------------------------------------------------
        public List<StudentModel> List_Student()
        {
            try
            {
                var students = ApiClientFactory.KimAnhInstance.GetAllStudent();
                return students.ToList();
            }
            catch
            {
                return null;
            }
           
        }
        public List<StudentModel> Search_Student(string key)
        {
            try
            {
                var students = ApiClientFactory.KimAnhInstance.Search_Student(key);
                return students;
            }
            catch
            {
                return null;
            }
           

        }
        public bool Insert_Student(StudentModel student)
        {
            try
            {
                var addstudent = ApiClientFactory.KimAnhInstance.Insert_Student(student);              
                return addstudent.IsSuccess;
            }
            catch
            {
                return false;
            }
        }

        public StudentModel Get_student(int id)
        {
            try
            {
                var addstudent = ApiClientFactory.KimAnhInstance.GetAllStudent().Where(r => r.Idstudent == id).FirstOrDefault();
                return addstudent;
            }
            catch
            {
                return null;
            }
           
        }
        public bool Update_Student(StudentModel student)
        {
            try
            {
                var updatestudent = ApiClientFactory.KimAnhInstance.Update_Student(student);
                return updatestudent.IsSuccess;
            }
            catch
            {
                return false;
            }
      }
         public bool Delete_Student(int id)
        {
            try
            {
                return ApiClientFactory.KimAnhInstance.Delete_Student(id).IsSuccess;
            }
            catch
            {
                return false;
            }

        }

        public bool Exit_Idstudent(int id)
        {
            try
            {
                var a = ApiClientFactory.KimAnhInstance.GetAllStudent().Where(t=>t.Idstudent==id).FirstOrDefault();
                if (a != null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
          
        }

        public bool Check(int id_student, int id_class)
        {
            var bien = db.ClassStudent.Where(x => x.Idstudent == id_student && x.Idclass == id_class).SingleOrDefault();
            if (bien != null)
                return true;
            else
                return false;
        }
        public bool ClassStudent(int id_student, int id_class)
        {
            var a = ApiClientFactory.KimAnhInstance.;
            if (Exit_Idstudent(id_student))
            {
                for (int i = 1; i <= 12; i++)
                {
                    ClassStudent add_class = new ClassStudent();
                    add_class.Idclass = id_class;
                    add_class.Idstudent = id_student;
                    add_class.Session = i;
                    add_class.Day = null;
                    add_class.State = 0;
                    db.ClassStudent.Add(add_class);
                    db.SaveChanges();

                    var bien = db.Class.Find(id_class);
                    if (bien != null)
                    {
                        bien.Number = bien.Number + 1;
                        db.SaveChanges();
                    }
                    
                    
                }
                return true;
            }   
            else
                return false;
        }

        //Class----------------------------------------------------------------------------
        public IEnumerable<Class_model> Get_Class()
        {
            try
            {
                var classp = ApiClientFactory.KimAnhInstance.getAllClass();
                var coursep = ApiClientFactory.KimAnhInstance.GetAllCourse();
                var list = (from x in classp
                            join y in coursep
                                 on x.Idcourse equals y.Idcourse
                                 select new Class_model
                                 {
                                     IDClass = x.Idclass,
                                     NameClass = x.NameClass,
                                     NameCourse = y.Name,
                                     StartDay = x.StartDay,
                                     FinishDay = x.FinishDay,
                                     Number = x.Number,
                                     State = x.State
                                 }
                        );
                return list.ToList();
            }
            catch
            {
                return null;
            }
           
        }

        public List<Class_model> Search_Class(string key)
        {
            var bien1 = Get_Class();
            return bien1.Where(x => x.NameClass.Contains(key) || x.NameCourse.Contains(key)).ToList();
        }

        public IEnumerable<CourseModel> GetName_Course()
        {
            try
            {
                var coursep = ApiClientFactory.KimAnhInstance.GetAllCourse();
                var bien = (from a in coursep
                            select a);
                return bien.ToList().Distinct();
            }
            catch
            {
                return null;
            }
            
        }
         public bool Insert_Class(ClassModel lop)
        {
            try
            {
                var a = ApiClientFactory.KimAnhInstance.AddClass(lop);
              
                return a.IsSuccess;
            }
            catch
            {
                return false;
            }
        }
        
        public ClassModel Get_DetailClass(int id)
        {
            try
            {
                var a = ApiClientFactory.KimAnhInstance.getAllClass();
                return a.Where(v=>v.Idclass==id).FirstOrDefault();
               
            }
            catch
            {
                return null;
            }
            
        }
        public bool Update_Class(ClassModel lop)
        {
            try
            {
                var a = ApiClientFactory.KimAnhInstance.UpdateClass(lop);
                return a.IsSuccess;

            }
            catch
            {
                return false;
            }
        }
        
        public bool Delete_Class(int id)
        {
            try
            {
                var a = ApiClientFactory.KimAnhInstance.RemoveClass(id);
                return a.IsSuccess;

            }
            catch
            {
                return false;
            }
        }

        //COURSE------------------------------------------------------------------
        public List<CourseModel> Get_Course()
        {
            try
            {
                var course = ApiClientFactory.KimAnhInstance.GetAllCourse();
                return course;
            }
            catch
            {
                return null;
            }
        }
        public List<CourseModel> Search_Course(string key)
        {
            try
            {
                var course = ApiClientFactory.KimAnhInstance.GetAllCourse();
                return course.Where(x => x.Name.Contains(key)).ToList();
            }
            catch
            {
                return null;
            }
           
        }

        public bool check_id(string id)
        {
            var bien = db.Course.Where(x => x.Idcourse == id);
            if (bien != null)
                return true;
            else
                return false;
        }
        public bool Insert_Course(Course course)
        {
            try
            {
                if (check_id(course.Idcourse) == true)
                {
                    db.Course.Add(course);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
                
            }
            catch
            {
                return false;
            }
        }
        public Course Get_DetailCourse(string id)
        {
            var bien = db.Course.Where(x => x.Idcourse == id).SingleOrDefault();
            return bien;
        }

         public bool Update_Course(Course course)
        {
            var bien = db.Course.Where(x => x.Idcourse == course.Idcourse).SingleOrDefault();
            if (bien != null)
            {
                bien.Name = course.Name;
                bien.Age = course.Age;
                bien.Maxnumber = course.Maxnumber;
                bien.Time = course.Time;
                bien.Contents = course.Contents;
                bien.Fee = course.Fee;
                bien.Image = course.Image;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Exitclass(string id)
        {
            var bien = db.Class.Where(x => x.Idcourse == id).SingleOrDefault();
            if (bien != null)
                return true;
            else
                return false;
        }
        public bool Delete_Course(string id)
        {
            var bien = db.Course.Where(x => x.Idcourse == id).SingleOrDefault();
            if(bien != null)
            {
                if (Exitclass(id) == false)
                {
                    db.Course.Remove(bien);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            return false;
        }
    }
}