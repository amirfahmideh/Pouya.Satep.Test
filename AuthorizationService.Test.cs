using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Pouya.Satep;
using Xunit;

namespace Pouya.Satep.Tests
{
    public class AuthorizationServiceTests
    {
        [Fact]
        public async Task LoginAsync_ReturnsToken_WhenResponseIsSuccessful()
        {
            var httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(120)
            };

            var service = new AuthorizationService(httpClient, new SatepServiceConfiguration()
            {
                JWTTokenServiceUrl = "https://power.scmiran.ir/api/Tavanir/Authenticate",
                UserName = Environment.GetEnvironmentVariable("SATEP_USERNAME"),
                Password = Environment.GetEnvironmentVariable("SATEP_PASSWORD")
            });

            var result = await service.LoginAsync();
            Console.WriteLine(result.Token);
            Assert.NotEmpty(result.Token ?? "");
        }
    }
}
