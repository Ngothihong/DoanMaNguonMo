using StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {
        public List<PromotionModel> GetAllPromotions()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Promotion/GetAllPromotions"));
            return  GetAsync<List<PromotionModel>>(requestUrl);
        }
        public Message<PromotionModel> GetPromotion(string id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Promotion/GetPromotion"));
            return  PostAsync<PromotionModel,string>(requestUrl, id);
        }
        public Message<PromotionModel> AddPromotion(PromotionModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Promotion/AddPromotion"));
            return  PostAsync<PromotionModel>(requestUrl, model);
        }
        public Message<PromotionModel> UpdatePromotion(PromotionModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Promotion/UpdatePromotion"));
            return  PostAsync<PromotionModel>(requestUrl, model);
        }
        public Message<PromotionModel> RemovePromotion(string id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Promotion/RemovePromotion"));
            return PostAsync<PromotionModel, string>(requestUrl, id);
        }
    }
}
