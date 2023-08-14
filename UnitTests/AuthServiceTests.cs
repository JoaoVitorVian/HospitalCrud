using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace UnitTests
{
    public class AuthServiceIntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public AuthServiceIntegrationTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Program>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task TestRealizarRegistro_Success_ReturnsSuccessResult()
        {
            // Arrange
            var email = "test@example.com";
            var senha = "Password123";
            var role = "UserRole";

            var request = new HttpRequestMessage(HttpMethod.Post, "/auth/register")
            {
                Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", email),
                    new KeyValuePair<string, string>("senha", senha),
                    new KeyValuePair<string, string>("role", role)
                })
            };

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

    }
}
