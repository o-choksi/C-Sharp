using System;
using System.Threading.Tasks;

namespace ProgressCorticonIntegration
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var rulesService = new RulesService();
            var result = await rulesService.ExecuteRuleAsync("SampleRules", new { /* Your input parameters */ });
            Console.WriteLine($"Rule execution result: {result}");
        }
    }
}
