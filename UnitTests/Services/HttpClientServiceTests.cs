using Game.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

        // Test invalid url 
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
    }
}
