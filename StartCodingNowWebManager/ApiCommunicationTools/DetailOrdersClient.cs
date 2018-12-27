using StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {
        public List<DetailOrdersModel> GetAllDetailOrders()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "DetailOrders/GetAllDetailOrders"));
            return GetAsync<List<DetailOrdersModel>>(requestUrl);
        }


        public Message<List<DetailOrdersModel>> GetDetailByOrderID(int idorder)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "DetailOrders/GetDetailByOrderID"));
            return PostAsync<List<DetailOrdersModel>, int>(requestUrl, idorder);
        }
        public Message<DetailOrdersModel> AddDetailOrder(DetailOrdersModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "DetailOrders/AddDetailOrder"));
            return  PostAsync<DetailOrdersModel>(requestUrl, model);
        }

        public Message<DetailOrdersModel> RemoveDetailOrders(int idorder)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "DetailOrders/RemoveDetailOrder"));
            return PostAsync<DetailOrdersModel, int>(requestUrl, idorder);
        }
    }
}
