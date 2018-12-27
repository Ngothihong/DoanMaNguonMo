using StartCodingNowWebManager.FF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace StartCodingNowWebManager.DAO
{
    public class DAO_GIAOVIEN
    {
        public QL_SCN db = new QL_SCN();
        public Account GetbyAccpunt(String user, string pass)
        {
            return db.Account.Where(x => x.Username == user && x.Password == pass).SingleOrDefault();
        }
        public int Login_Giaovien(string user, string pass)
        {
            var result = db.Account.SingleOrDefault(x => x.Username == user);
            if (result == null)
                return 0;
            else
            {
                if (result.Status == 0)
                    return -1;
                else
                {
                    if (result.Password == pass)
                        return 1;
                    else
                        return -2;
                }
            }

        }
        public Teacher GetbyID(int ID)
        {
            var a = db.Teacher.Where(x => x.Idteacher == ID).SingleOrDefault();
            return db.Teacher.Where(x => x.Idteacher == ID).SingleOrDefault();
        }

        public bool Update(Teacher tEACHER)
        {
            var tc = db.Teacher.Where(x => x.Idteacher == tEACHER.Idteacher).SingleOrDefault();
            if (tc != null)
            {
                tc.Name = tEACHER.Name;
                tc.Phone = tEACHER.Phone;
                tc.Address = tEACHER.Address;
                tc.Email = tEACHER.Email;
                tc.Knowledge = tEACHER.Knowledge;
                db.SaveChanges();
                return true;
            }
            return false;

        }

    }
}