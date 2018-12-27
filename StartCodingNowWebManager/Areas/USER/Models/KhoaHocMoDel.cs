using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartCodingNowWebManager.FF;

namespace StartCodingNowWebManager.Areas.USER.Models
{
    public class KhoaHocModel
    {
        private QL_SCN db = new QL_SCN();

        public List<Course> GetCOURSEs()
        {
            return db.Course.ToList();
        }
        public List<Course> SearchCOURSEs(string searchString)
        {
            return db.Course.Where(x => x.Name.Contains(searchString)).ToList();
        }
        public List<Course> FilterCOURSEsByAge(string age)
        {
            int index = -1;
            index = age.IndexOf("-");
            if (index > -1)
            {
                int minage = 0;
                int maxage = 0;
                minage = int.Parse(age.Substring(0, index).Trim());
                maxage = int.Parse(age.Substring(index + 1).Trim());
                return db.Course.Where(x => x.Age <= maxage && x.Age >= minage).ToList();
            }
            else
            {
                int minage = int.Parse(age);
                return db.Course.Where(x => x.Age > minage).ToList();
            }
        }
        public List<Course> FilterCOURSEsByPrice(string price)
        {
            int index = -1;
            index = price.IndexOf("-");
            if (index > -1)
            {
                decimal minprice = 0;
                decimal maxprice = 0;
                minprice = decimal.Parse(price.Substring(0, index).Trim());
                maxprice = decimal.Parse(price.Substring(index + 1).Trim());
                return db.Course.Where(x => x.Fee < maxprice && x.Fee >= minprice).ToList();
            }
            else
            {
                decimal minprice = decimal.Parse(price);
                return db.Course.Where(x => x.Fee >= minprice).ToList();
            }
        }
        public Course GetCOURSE(string ID)
        {
            return db.Course.Where(x => x.Idcourse == ID).FirstOrDefault();
        }
        public bool Insert(FF.RigistrationCourse rc)
        {
            try
            {
                db.RigistrationCourse.Add(rc);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}