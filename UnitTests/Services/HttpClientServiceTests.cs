using Game.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
