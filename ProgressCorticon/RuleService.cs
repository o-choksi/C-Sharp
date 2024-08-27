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

        public async Task<string> ExecuteRuleAsync(string ruleName, object input)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"/rules/{ruleName}/execute")
            {
                Content = new StringContent(JsonSerializer.Serialize(input), System.Text.Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
