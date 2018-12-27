using System;
using System.Collections.Generic;

namespace StartCodingNowWebManager.FF
{
    public partial class Class
    {
        public Class()
        {
            ClassStudent = new HashSet<ClassStudent>();
            Phanbo = new HashSet<Phanbo>();
            TeachingClass = new HashSet<TeachingClass>();
        }

        public int Idclass { get; set; }
        public string Idcourse { get; set; }
        public string NameClass { get; set; }
        public DateTime? StartDay { get; set; }
        public DateTime? FinishDay { get; set; }
        public int? Number { get; set; }
        public int? State { get; set; }

        public virtual Course IdcourseNavigation { get; set; }
        public virtual ICollection<ClassStudent> ClassStudent { get; set; }
        public virtual ICollection<Phanbo> Phanbo { get; set; }
        public virtual ICollection<TeachingClass> TeachingClass { get; set; }
    }
}
