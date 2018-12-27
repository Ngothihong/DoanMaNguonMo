using StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {
        public List<OrdersModel> GetAllOrders()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Orders/GetAllOrders"));
            return  GetAsync<List<OrdersModel>>(requestUrl);
        }
        public Message<OrdersModel> GetOrder(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Orders/GetOrder"));
            return  PostAsync<OrdersModel,int>(requestUrl, id);
        }
        public Message<OrdersModel> AddOrder(OrdersModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Orders/AddOrder"));
            return  PostAsync<OrdersModel>(requestUrl, model);
        }
        public Message<OrdersModel> UpdateOrder(OrdersModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Orders/UpdateOrder"));
            return  PostAsync<OrdersModel>(requestUrl, model);
        }
        public Message<OrdersModel> RemoveOrder(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Orders/RemoveOrder"));
            return PostAsync<OrdersModel, int>(requestUrl, id);
        }
    }
}
