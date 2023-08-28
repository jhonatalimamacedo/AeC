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
        private HttpClient _httpClientAeroporto;
        private HttpClient _httpClientCidade;

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

            _httpClientAeroporto = new HttpClient(handlerMock.Object);

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

            _httpClientCidade = new HttpClient(handlerMock2.Object);


        }

        [Test]
        public async Task Test_Aeroporto_Success()
        {

            string codigo = "SBGR";
            var cptecService = new CptecService(_httpClientAeroporto);

            string result = await cptecService.aeroporto(codigo);

       
            Assert.AreEqual("{'umidade': 50, 'temperatura': 25}", result);
        }

        [Test]
        public async Task Test_Cidade_Success()
        {
            int codigo = 12345;
            var cptecService = new CptecService(_httpClientCidade);

            string result = await cptecService.cidade(codigo);

            Assert.AreEqual("{'previsao': 'Ensolarado'}", result);
        }
    }
}
