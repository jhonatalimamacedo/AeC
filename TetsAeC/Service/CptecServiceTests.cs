using AeCAPI.Interface;
using AeCAPI.Service;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TestsAeC.Service
{
    public class CptecServiceTests
    {
        private Mock<ICptecService> _cptecServiceMock;
        private HttpClient _httpClient;

        [SetUp]
        public void SetUp()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{'umidade': 50, 'temperatura': 25}")
                });

            _httpClient = new HttpClient(handlerMock.Object);

            _cptecServiceMock = new Mock<ICptecService>();

            var handlerMock2 = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock2
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{'previsao': 'Ensolarado'}")
                });

            _httpClient = new HttpClient(handlerMock2.Object);

            _cptecServiceMock = new Mock<ICptecService>();
        }

        [Test]
        public async Task Test_Aeroporto_Success()
        {
            // Arrange
            string codigo = "SBGR";
            var cptecService = new CptecService(_httpClient);

            // Act
            string result = await cptecService.aeroporto(codigo);

            // Assert
            Assert.AreEqual("{'umidade': 50, 'temperatura': 25}", result);
        }

        [Test]
        public async Task Test_Cidade_Success()
        {
            // Arrange
            int codigo = 12345;
            var cptecService = new CptecService(_httpClient);

            // Act
            string result = await cptecService.cidade(codigo);

            // Assert
            Assert.AreEqual("{'previsao': 'Ensolarado'}", result);
        }


        // ... other tests
    }
}
