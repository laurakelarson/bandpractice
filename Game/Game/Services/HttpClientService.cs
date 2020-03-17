using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Game.Services
{
    public class HttpClientService
    {
        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static HttpClientService _instance;

        // Local Instance of the Client
        private HttpClient _httpClientInstance;

        // client
        private HttpClient _httpClient
        {
            get
            {
                if (_httpClientInstance == null)
                {
                    _httpClientInstance = new HttpClient();
                }
                return _httpClientInstance;
            }
            //set
            //{
            //    _httpClientInstance = _httpClient;
            //}
        }

        // this instance
        public static HttpClientService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HttpClientService();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Set the client
        /// 
        /// Used by UT to swap out clients for testing
        /// 
        /// </summary>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public HttpClient SetHttpClient(HttpClient httpClient)
        {
            _httpClientInstance = httpClient;
            return _httpClientInstance;
        }

        /// <summary>
        /// Returns the current client
        /// </summary>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public HttpClient GetHttpClient()
        {
            return _httpClientInstance;
        }
    }
}
