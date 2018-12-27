using System;
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
        public List<Teacher> List_Teacher()
        {
            return db.Teacher.ToList();
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
        public bool Insert_Teacher(Teacher tc)
        {
            var tmp = Exist_Teacher(tc.Email);
            if (tmp == -1)
            {
                db.Teacher.Add(tc);
                db.SaveChanges();
                var bien_tmp = Exist_Teacher(tc.Email);
                if (bien_tmp != -1)
                {
                    Account tk = new Account();
                    tk.Idteacher = bien_tmp;
                    tk.Username = tc.Email;
                    tk.Password = Encryptor.MD5Hash(tc.Email);
                    tk.Status = 1;
                    db.Account.Add(tk);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
                
            }
            else
                return false;
        }
        public Teacher Get_Teacher(int id)
        {
            return db.Teacher.Find(id);
        }
        public bool Update_Teacher(Teacher tc)
        {
            try
            {
                var bien = db.Teacher.Find(tc.Idteacher);
                if (bien != null)
                {
                    bien.Name = tc.Name;
                    bien.Sex = tc.Sex;
                    bien.Phone = tc.Phone;
                    bien.Address = tc.Address;
                    bien.Email = tc.Email;
                    bien.Knowledge = tc.Knowledge;
                    bien.Status = tc.Status;
                    db.SaveChanges();
                    var bien1 = db.Account.Find(tc.Idteacher);
                    if (bien1 != null)
                    {
                        bien1.Status = tc.Status;
                        db.SaveChanges();
                    }
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

       
        public bool Delete_Teacher(int id)
        {
            var bien = db.Teacher.Where(a => a.Idteacher == id).SingleOrDefault();
            var temp = db.TeachingClass.Where(a => a.Idteacher == id).SingleOrDefault();
            if (bien != null) // ton tai
            {
                if(temp != null) // ton tai
                {
                    return false;
                }
                else // khong ton tai
                {
                    var bien1 = db.Account.Where(a => a.Idteacher == id).SingleOrDefault();
                    db.Account.Remove(bien1);
                    db.SaveChanges();
                    db.Teacher.Remove(bien);
                    db.SaveChanges();
                    return true;
                }
            }
            else
                return false;
        }
         public List<Teacher> Search_Teacher(string key)
        {
            
              return db.Teacher.Where(x => x.Name.Contains(key) || x.Address.Contains(key) || x.Knowledge.Contains(key)).ToList();       
            
        }


        //STUDENT--------------------------------------------------------
        public List<Student> List_Student()
        {
            return db.Student.ToList();
        }
        public List<Student> Search_Student(string key)
        {

            return db.Student.Where(x => x.Name.Contains(key) || x.Address.Contains(key) || x.NameParent.Contains(key)).ToList();

        }
        public bool Insert_Student(Student student)
        {
            try
            {
                db.Student.Add(student);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Student Get_student(int id)
        {
            return db.Student.Find(id);
        }
        public bool Update_Student(Student student)
        {
            var bien = db.Student.Where(x => x.Idstudent == student.Idstudent).SingleOrDefault();
            if (bien != null)
            {
                bien.Name = student.Name;
                bien.Sex = student.Sex;
                bien.Born = student.Born;
                bien.NameParent = student.NameParent;
                bien.Phone = student.Phone;
                bien.Address = student.Address;
                bien.Email = student.Email;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
         public bool Delete_Student(int id)
        {
            var bien = db.Student.Find(id);
            if (bien != null)
            {
                ClassStudent bien1 = db.ClassStudent.Where(x => x.Idstudent == id).SingleOrDefault();
                if (bien1 != null)
                {
                    db.ClassStudent.Remove(bien1);
                    db.SaveChanges();
                    db.Student.Remove(bien);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    db.Student.Remove(bien);
                    db.SaveChanges();
                    return true;
                }
            }
            else
                return false;
        }

        public bool Exit_Idstudent(int id)
        {
            if (db.Student.Find(id) != null)
            {
                return true;
            }
            else
                return false;
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
            var list = (from x in db.Class
                        join y in db.Course
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

        public List<Class_model> Search_Class(string key)
        {
            var bien1 = Get_Class();
            return bien1.Where(x => x.NameClass.Contains(key) || x.NameCourse.Contains(key)).ToList();
        }

        public IEnumerable<Course> GetName_Course()
        {
            var bien = (from a in db.Course
                        select a);
            return bien.ToList().Distinct();
        }
         public bool Insert_Class(Class lop)
        {
            try
            {
                lop.Number = 0;
                db.Class.Add(lop);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public Class Get_DetailClass(int id)
        {
            return db.Class.Find(id);
        }
        public bool Update_Class(Class lop)
        {
            var bien = db.Class.Where(x => x.Idclass == lop.Idclass).SingleOrDefault();
            if (bien != null)
            {
                bien.Idcourse = lop.Idcourse;
                bien.NameClass = lop.NameClass;
                bien.StartDay = lop.StartDay;
                bien.FinishDay = lop.FinishDay;
                bien.State = lop.State;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
        
        public bool Delete_Class(int id)
        {
            var bien = db.Class.Find(id);
            if (bien != null)
            {
                if (bien.Number == 0)
                {
                    db.Class.Remove(bien);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
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