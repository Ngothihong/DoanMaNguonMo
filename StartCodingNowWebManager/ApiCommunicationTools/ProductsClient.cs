using StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {
        public List<ProductModel> GetAllProducts()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Product/GetAllProducts"));
            return  GetAsync<List<ProductModel>>(requestUrl);
        }
        public Message<ProductModel> GetProduct(string id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Product/GetProduct"));
            return  PostAsync<ProductModel,string>(requestUrl, id);
        }
        public Message<ProductModel> AddProduct(ProductModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Product/AddProduct"));
            return  PostAsync<ProductModel>(requestUrl, model);
        }
        public Message<ProductModel> UpdateProduct(ProductModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Product/UpdateProduct"));
            return  PostAsync<ProductModel>(requestUrl, model);
        }
        public Message<ProductModel> RemoveProduct(string id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Product/RemoveProduct"));
            return PostAsync<ProductModel, string>(requestUrl, id);
        }
    }
}
