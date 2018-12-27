using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using StartCodingNowWebManager.ApiCommunicationTools;

namespace StartCodingNowWebManager.ApiCommunicationTools
{
    public static class ApiClientFactory
    {
        private static Uri ThanhDatApiUri;
        private static Lazy<ApiClient> ThanhDatRestClient = new Lazy<ApiClient>(
            () => new ApiClient(ThanhDatApiUri),
            LazyThreadSafetyMode.ExecutionAndPublication);

        private static Uri HongHeoApiUri;
        private static Lazy<ApiClient> HongHeoRestClient = new Lazy<ApiClient>(
            () => new ApiClient(HongHeoApiUri),
            LazyThreadSafetyMode.ExecutionAndPublication);

        private static Uri KimAnhApiUri;
        private static Lazy<ApiClient> KimAnhRestClient = new Lazy<ApiClient>(
            () => new ApiClient(KimAnhApiUri),
            LazyThreadSafetyMode.ExecutionAndPublication);

        static ApiClientFactory()
        {
            if (!string.IsNullOrEmpty(ApplicationSettings.ThanhDatApiUrl))
            {
                ThanhDatApiUri = new Uri(ApplicationSettings.ThanhDatApiUrl);
            }
            if (!string.IsNullOrEmpty(ApplicationSettings.HongHeoApiUrl))
            {
                HongHeoApiUri = new Uri(ApplicationSettings.HongHeoApiUrl);
            }
            if (!string.IsNullOrEmpty(ApplicationSettings.KimAnhApiUrl))
            {
                KimAnhApiUri = new Uri(ApplicationSettings.KimAnhApiUrl);
            }


        }

        public static ApiClient ThanhDatInstance
        {

            get { return ThanhDatRestClient.Value; }
        }

        public static ApiClient HongHeoInstance
        {
            get { return HongHeoRestClient.Value; }
        }

        public static ApiClient KimAnhInstance
        {
            get { return KimAnhRestClient.Value; }
        }
    }
}
