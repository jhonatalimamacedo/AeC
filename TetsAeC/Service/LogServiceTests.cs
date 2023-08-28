using AeCAPI.Entity;
using AeCAPI.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TetsAeC.Service
{
    public class LogServiceTests
    {
        private Mock<ILogService> _logServiceMock;

        [SetUp]
        public void SetUp()
        {
            _logServiceMock = new Mock<ILogService>();
            _logServiceMock.Setup(a => a.Get()).Returns(new List<log> { new log(), new log() });
            _logServiceMock.Setup(a => a.SaveLog(It.IsAny<int>(), It.IsAny<string>()));
        }

        [Test]
        public void Test_SaveLog_Success()
        {
            int code = 200;
            string message = "Log message";

          
            _logServiceMock.Object.SaveLog(code, message);

            _logServiceMock.Verify(a => a.SaveLog(code, message), Times.Once);
        }

        [Test]
        public void Test_Get_Success()
        {
   
            IEnumerable<log> logs = _logServiceMock.Object.Get();

            Assert.IsNotNull(logs);
            Assert.AreEqual(2, logs.Count());
        }
    }
}
