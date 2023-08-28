using Moq;
using NUnit.Framework;
using System.Data;
using AeCAPI.Entity;
using AeCAPI.Interface;

namespace TestsAeC.Service
{
    public class AeroportoServiceTests
    {
        private Mock<ICidadeService> _cidadeerviceMock;

        [SetUp]
        public void SetUp()
        {
            _cidadeerviceMock = new Mock<ICidadeService>();

            _cidadeerviceMock.Setup(a => a.Create(It.IsAny<string>())).Verifiable();
            _cidadeerviceMock.Setup(a => a.GetById(It.IsAny<int>())).Returns(new Cidade());
        }

        [Test]
        public void Test_Create_Success()
        {

            string message = "{'umidade': 50, 'visibilidade': 10, 'teste'}";

                _cidadeerviceMock.Object.Create(message);

                _cidadeerviceMock.Verify(a => a.Create(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Test_GetById_Success()
        {
            int id = 1;

            Cidade result = _cidadeerviceMock.Object.GetById(id);

            Assert.IsNotNull(result);
        }
    }
}
