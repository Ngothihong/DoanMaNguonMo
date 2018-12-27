using System;
using System.Collections.Generic;

namespace StartCodingNowWebManager.FF
{
    public partial class Account
    {
        public int Idteacher { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Status { get; set; }

        public virtual Teacher IdteacherNavigation { get; set; }
    }
}
