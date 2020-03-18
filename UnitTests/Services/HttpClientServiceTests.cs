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



    }
}
