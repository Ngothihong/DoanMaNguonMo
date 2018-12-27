using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public partial class ApiClient
    {

        private readonly HttpClient _httpClient;
        private Uri BaseEndpoint { get; set; }

        public ApiClient(Uri baseEndpoint)
        {
            if (baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }
            BaseEndpoint = baseEndpoint;
            _httpClient = new HttpClient();
        }

        /// <summary>  
        /// Common method for making GET calls  
        /// </summary>  
        private T GetAsync<T>(Uri requestUrl)
        {
          //  addHeaders();
            var response =  _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            
            var data =  response.Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>  
        /// Common method for making POST calls  
        /// </summary>  
        private Message<T> PostAsync<T>(Uri requestUrl, T content)
        {
            //  addHeaders();
            try
            {
                var response =  _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
               
                var data =  response.Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Message<T>>(data);
            }
            catch(Exception ex)
            {
                Message<T> exmgs = new Message<T>();
                exmgs.IsSuccess = false;
                exmgs.ReturnMessage = ex.Message;
                return exmgs;
            }
           
            
        }
       
        private Message<T1> PostAsync<T1, T2>(Uri requestUrl, T2 content)
        {
            //   addHeaders();
            try
            {
                var response =  _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T2>(content));
               
                var data =  response.Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Message<T1>>(data);
            }
            catch (Exception ex)
            {
                Message<T1> exmgs = new Message<T1>();
                exmgs.IsSuccess = false;
                exmgs.ReturnMessage = ex.Message;
                return exmgs;
            }
           
        }
   

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

        private void addHeaders()
        {
            _httpClient.DefaultRequestHeaders.Remove("userIP");
            _httpClient.DefaultRequestHeaders.Add("userIP", "192.168.1.1");
        }
    }
}
