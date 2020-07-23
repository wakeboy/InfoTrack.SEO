using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace InfoTrack.SEO.ScraperTests.Mocks
{
    public class MockHttpClientFactory : IHttpClientFactory
    {
        private readonly string responseContent;

        public MockHttpClientFactory(string responseContent)
        {
            this.responseContent = responseContent;
        }

        public HttpClient CreateClient(string name)
        {
            var httpMessageHandler = new MockHttpMessageHandler(responseContent);
            return new HttpClient(httpMessageHandler);
        }
    }

    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly string responseContent;

        public MockHttpMessageHandler(string responseContent)
        {
            this.responseContent = responseContent;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent)
            };
            return Task.FromResult(response);
        }


    }
}
