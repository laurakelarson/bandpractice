using Game.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTests.Services
{
    [TestFixture]
    public class HttpClientServiceTests
    {
        HttpClientService Service; // service to be called 

        // setup for the unit tests 
        [SetUp]
        public void Setup()
        {
            Service = HttpClientService.Instance;
        }

        // Test constructor 
        [Test]
        public void HttpClientService_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Service;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        // Test set 
        [Test]
        public void HttpClientService_SetHttpClient_Default_Should_Pass()
        {
            // Arrange

            HttpClient httpClient = new HttpClient();

            // Act
            var result = Service.SetHttpClient(httpClient);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        // Test empty url 
        [Test]
        public async Task HttpClientService_GetJsonGetAsync_InValid_Null_Should_Fail()
        {
            // Arrange
            var RestUrl = "";

            // Act
            var result = await Service.GetJsonGetAsync(RestUrl);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        // Test bogus url 
        [Test]
        public async Task HttpClientService_GetJsonGetAsync_InValid_Bogus_Should_Fail()
        {
            // Arrange
            var RestUrl = "bogus";

            // Act
            var result = await Service.GetJsonGetAsync(RestUrl);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        // ResponseMessage class used for sending mock responses 
        public static class ResponseMessage
        {

            public static StringContent ResponseMessageStringContent = new StringContent("Content as string");

            public static StringContent DefaultStringContent = new StringContent("Content as string");

            public static StringContent GetStringContent = new StringContent(@"{'msg':'Ok','errorCode':0,'version':'1.1.1.1','data':{'ItemList':[{'Value':10,'Attribute':14,'Location':20,'Name':'Strong Shield','Guid':'3a138793-7411-7c60-6b03-aee9423d3684','Description':'Enough to hide behind','ImageURI':'http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},{'Value':10,'Attribute':14,'Location':20,'Name':'Bow','Guid':'2e0ac680-1913-0854-de5e-294bb0e4d23a','Description':'Fast shooting bow','ImageURI':'http://cliparts.co/cliparts/di4/oAB/di4oABdbT.png','Range':10,'Damage':6,'Count':-1,'IsConsumable':false,'Category':10}]}}");
            public static StringContent PostStringContent = new StringContent(@"{'msg':'Ok','errorCode': 0,'version': '1.1.1.1','data':{'ItemList':[{'Value':10,'Attribute':14,'Location':20,'Name':'Strong Shield','Guid':'3a138793-7411-7c60-6b03-aee9423d3684','Description':'Enough to hide behind','ImageURI':'http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},{'Value':10,'Attribute':14,'Location':20,'Name':'Bow','Guid':'2e0ac680-1913-0854-de5e-294bb0e4d23a','Description':'Fast shooting bow','ImageURI':'http://cliparts.co/cliparts/di4/oAB/di4oABdbT.png','Range':10,'Damage':6,'Count':-1,'IsConsumable':false,'Category':10},{'Value':10,'Attribute':12,'Location':30,'Name':'Blue Ring of Power','Guid':'c3f4cece-b1d8-bb02-38c0-32c7a4e87160','Description':'The one to control them all','ImageURI':'http://www.clker.com/cliparts/A/E/4/t/L/1/diamond-ring-teal-hi.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},{'Value':10,'Attribute':10,'Location':10,'Name':'Bunny Hat','Guid':'0e9f41b4-4be2-adc3-d39d-1c70ae814913','Description':'Pink hat with fluffy ears','ImageURI':'http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10}]}}");
            public static StringContent NullStringContent = null;

            public static void SetResponseMessageStringContent(StringContent content)
            {
                ResponseMessageStringContent = content;
            }

            public static void ResetResponseMessageStringContent()
            {
                ResponseMessageStringContent = DefaultStringContent;
            }


            public static HttpStatusCode HttpStatusCode = HttpStatusCode.OK;
            public static HttpStatusCode HttpStatusCodeSuccess = HttpStatusCode.OK;
            public static HttpStatusCode HttpStatusCodeBadRequest = HttpStatusCode.BadRequest;
            public static HttpStatusCode HttpStatusCodeNotFound = HttpStatusCode.NotFound;

            public static void SetHttpStatusCode(HttpStatusCode code)
            {
                HttpStatusCode = code;
            }

            public static void ResetHttpStatusCode()
            {
                HttpStatusCode = HttpStatusCodeSuccess;
            }
        }

        // Mock Http message handler class 
        public class MockHttpMessageHandler : HttpMessageHandler
        {

            protected override async Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                var responseMessage = new HttpResponseMessage(ResponseMessage.HttpStatusCode)
                {
                    Content = ResponseMessage.ResponseMessageStringContent
                };

                return await Task.FromResult(responseMessage);
            }
        }

        // Example json string 
        readonly string ExampleJson = @"
            {
                'msg':'Ok',
                'errorCode':0,
                'version':'1.1.1.1',
                'data':
                {
                    'ItemList':
                    [
                        {'Value':10,'Attribute':14,'Location':20,'Name':'Strong Shield','Guid':'3a138793-7411-7c60-6b03-aee9423d3684','Description':'Enough to hide behind','ImageURI':'http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},
                        {'Value':10,'Attribute':14,'Location':20,'Name':'Bow','Guid':'2e0ac680-1913-0854-de5e-294bb0e4d23a','Description':'Fast shooting bow','ImageURI':'http://cliparts.co/cliparts/di4/oAB/di4oABdbT.png','Range':10,'Damage':6,'Count':-1,'IsConsumable':false,'Category':10},
                        {'Value':10,'Attribute':12,'Location':30,'Name':'Blue Ring of Power','Guid':'c3f4cece-b1d8-bb02-38c0-32c7a4e87160','Description':'The one to control them all','ImageURI':'http://www.clker.com/cliparts/A/E/4/t/L/1/diamond-ring-teal-hi.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},
                        {'Value':10,'Attribute':10,'Location':10,'Name':'Bunny Hat','Guid':'0e9f41b4-4be2-adc3-d39d-1c70ae814913','Description':'Pink hat with fluffy ears','ImageURI':'http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10}
                    ]
                }
            }";

        // Example json string without version 
        readonly string ExampleJsonNoVersion = @"
            {
                'msg':'Ok',
                'errorCode':0,
                'version':,
                'data':
                {
                    'ItemList':
                        [
                            {'Value':10,'Attribute':14,'Location':20,'Name':'Strong Shield','Guid':'3a138793-7411-7c60-6b03-aee9423d3684','Description':'Enough to hide behind','ImageURI':'http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},
                            {'Value':10,'Attribute':14,'Location':20,'Name':'Bow','Guid':'2e0ac680-1913-0854-de5e-294bb0e4d23a','Description':'Fast shooting bow','ImageURI':'http://cliparts.co/cliparts/di4/oAB/di4oABdbT.png','Range':10,'Damage':6,'Count':-1,'IsConsumable':false,'Category':10},
                            {'Value':10,'Attribute':12,'Location':30,'Name':'Blue Ring of Power','Guid':'c3f4cece-b1d8-bb02-38c0-32c7a4e87160','Description':'The one to control them all','ImageURI':'http://www.clker.com/cliparts/A/E/4/t/L/1/diamond-ring-teal-hi.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10},
                            {'Value':10,'Attribute':10,'Location':10,'Name':'Bunny Hat','Guid':'0e9f41b4-4be2-adc3-d39d-1c70ae814913','Description':'Pink hat with fluffy ears','ImageURI':'http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png','Range':0,'Damage':0,'Count':-1,'IsConsumable':false,'Category':10}
                        ]
                }
            }";

        // Example json error message
        readonly string ExampleJsonMessageError = @"
            {
                'msg':'Ok',
                'errorCode':1,
                'version':'1.1.1.1',
                'data':{}
            }";
    }
}
