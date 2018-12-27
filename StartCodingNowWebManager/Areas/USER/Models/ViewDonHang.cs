using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartCodingNowWebManager.Areas.USER.Models
{
    public class ViewDonHang
    {
        public int ID_Order { get; set; }
        public string NameCustomer { get; set; }

        public string Phone { get; set; }

        public string ADDRESS { get; set; }

        public string Email { get; set; }

        public int? NumberProduct { get; set; }

        public decimal PriceTotal { get; set; }

        public DateTime? DATE { get; set; }


        public string Payment { get; set; }


        public string Note { get; set; }

        public int? State { get; set; }

        public string IDRobot { get; set; }

        public string Name { get; set; }

        public int? Number { get; set; }

        public decimal? Price { get; set; }

        public string Contents { get; set; }

        public string Image { get; set; }
    }
}