using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartCodingNowWebManager.FF;

namespace StartCodingNowWebManager.DAO
{
    public class DAO_Course
    {
        QL_SCN db = new QL_SCN();
        public IEnumerable<Course> GetAll()
        {
            return db.Course.ToList();
        }
        public List<Course> GetNamecouse ()
        {
            var a = from x in db.Course
                    select x;
            return a.ToList();
        }
    }
}