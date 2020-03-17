using Game.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Parse the Json Result
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public async Task<string> JsonParseResult(HttpResponseMessage response)
        {
            JObject json;
            string data;

            if (response == null)
            {
                return null;
            }

            if (response.Content == null)
            {
                return null;
            }

            var responseJson = await response.Content.ReadAsStringAsync();

            // make sure the object is properly formated json
            try
            {
                json = JObject.Parse(responseJson);
            }
            catch (Exception)
            {
                return null;
            }

            // Check for error code            
            if (JsonHelper.GetJsonInteger(json, "errorCode") == WebGlobalsModel.ErrorResultCode)
            {
                var myError = new
                {
                    ServerError = true,
                    MessageList = JsonHelper.GetJsonString(json, "msg")
                };

                var myString = (JObject)JToken.FromObject(myError);
                return myString.ToString();
            }

            // Version string is  1.1.1.1  MajorCode.MinorCode.MajorData.MinorData
            var versionJsonString = JsonHelper.GetJsonString(json, "version");
            if (string.IsNullOrEmpty(versionJsonString))
            {
                // invalid returned ID, so return fail
                return null;
            }

            data = null;
            var tempJsonObject = json["data"].ToString();

            if (!string.IsNullOrEmpty(tempJsonObject))
            {
                data = tempJsonObject;
            }

            return data;
        }
    }
}
