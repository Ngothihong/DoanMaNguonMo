using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartCodingNowWebManager.FF;



namespace StartCodingNowWebManager.DAO.GIAOVIEN
{
    public class DAO_Hocvien
    {
        QL_SCN db = new QL_SCN();
        public IEnumerable<Student> GetALL( int IDTeacher)
        {
            IEnumerable<Student> list = (from a in db.Phanbo
                                         join c in db.ClassStudent  on a.Idclass equals c.Idclass
                                         join d in db.Student on c.Idstudent equals d.Idstudent
                                         where a.Idteacher == IDTeacher
                                         select d).Distinct();

            return list.Distinct();
        }
        public IEnumerable<Student> GetbyIDClass (int IDclass)
        {
            IEnumerable<Student> list = (from a in db.ClassStudent
                       join b in db.Student
                       on a.Idstudent equals b.Idstudent
                       where a.Idclass == IDclass
                       select b).Distinct();

            return list.Distinct();

        }
    }
}
