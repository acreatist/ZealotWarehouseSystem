using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TicketRewardSystem.Repository;
using TicketRewardSystem.Controllers;

namespace TicketRewardSystem.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var uofMock = new Mock<UowData>();
            var controller = new HomeController(uofMock.Object);

        }
    }
}
