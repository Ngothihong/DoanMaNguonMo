using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using StartCodingNowWebManager.FF;
using StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI;
namespace StartCodingNowWebManager.Areas.USER.Models
{
    [Serializable]
    public class Cart_items
    {
        public ProductModel product { get; set; }
        public int Quantity { get; set; }
    }
}