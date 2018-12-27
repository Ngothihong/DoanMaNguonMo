using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartCodingNowWebManager.Common
{
    [Serializable]
    public class SessionTeacher
    {
        public int IDuser { get; set; }
        public string user { get; set; } // ten teacher
        public int? state { get; set; } // hoat dong them sua xoa 1: them , 2 sua

        public int ID_Teaching_class { get; set; }
        public int ID_class { get; set; }

    }
}