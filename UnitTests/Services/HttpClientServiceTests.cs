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
        HttpClientService Service;

        [SetUp]
        public void Setup()
        {
            Service = HttpClientService.Instance;
        }


    }
}
