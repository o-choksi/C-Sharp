using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using CorticonAPI; //Need CorticonAPI.dll added to csproj
using Microsoft.Extensions.Configuration;

namespace ProgressCorticonIntegration
{
    public class RulesService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public RulesService()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_configuration["Corticon:ServiceUrl"])
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", 
                Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{_configuration["Corticon:UserName"]}:{_configuration["Corticon:Password"]}"))
            );
        }

        public async Task<bool> ShouldBuyHomeAsync(decimal homePrice)
        {
            var requestUri = "https://your-corticon-service-url/decisionmodel/HomePurchaseDecisionModel";
            var requestBody = new
            {
                HomePrice = homePrice
            };
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(responseContent);
            return result.ShouldBuyHome;
        }
    }
}
