using AeCAPI.Entity;
using AeCAPI.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetsAeC.Service
{
    public class ClimaServiceTest
    {
        private Mock<IClimaService> _climaserviceMock;

        [SetUp]
        public void SetUp()
        {
            _climaserviceMock = new Mock<IClimaService>();

            _climaserviceMock.Setup(a => a.GetClima(It.IsAny<int>())).Returns(new Clima());
        }
        [Test]
        public void Test_GetById_Success()
        {
            int id = 1;

            Clima result = _climaserviceMock.Object.GetClima(id);

            Assert.IsNotNull(result);
        }
    }
}
