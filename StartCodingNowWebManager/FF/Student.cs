using System;
using System.Collections.Generic;

namespace StartCodingNowWebManager.FF
{
    public partial class Student
    {
        public Student()
        {
            ClassStudent = new HashSet<ClassStudent>();
        }

        public int Idstudent { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime? Born { get; set; }
        public string NameParent { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public virtual ICollection<ClassStudent> ClassStudent { get; set; }
    }
}
