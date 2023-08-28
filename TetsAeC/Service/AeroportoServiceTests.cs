using System;
using Moq;
using NUnit.Framework;
using AeCAPI.Service;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using AeCAPI.Entity;
using Newtonsoft.Json;
using AeCAPI.Interface;

namespace TetsAeC.Service
{
    public class AeroportoServiceTests
    {
        private Mock<IAeroportoService> _aeroportoServiceMock;

        [SetUp]
        public void SetUp()
        {
            _aeroportoServiceMock = new Mock<IAeroportoService>();

            _aeroportoServiceMock.Setup(a => a.Create(It.IsAny<string>())).Verifiable();
            _aeroportoServiceMock.Setup(a => a.GetById(It.IsAny<int>())).Returns(new Aeroportos());
        }

        [Test]
        public void Test_Create_Success()
        {

            string message = "{'umidade': 50, 'visibilidade': 10, 'teste'}";

            _aeroportoServiceMock.Object.Create(message);

            _aeroportoServiceMock.Verify(a => a.Create(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Test_GetById_Success()
        {
            int id = 1;

            Aeroportos result = _aeroportoServiceMock.Object.GetById(id);

            Assert.IsNotNull(result);
        }
    }
}
