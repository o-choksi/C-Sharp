using System;
using System.Threading.Tasks;

namespace ProgressCorticonIntegration
{
    class CorticonProgram
    {
        static async Task Main(string[] args)
        {
            // Create an instance of RulesService
            var corticonClient = new RulesService();

            // Example home prices to test
            decimal[] homePrices = { 450000, 550000, 300000, 600000 };

            foreach (var price in homePrices)
            {
                try
                {
                    // Check if the home should be bought based on the price
                    bool shouldBuy = await corticonClient.ShouldBuyHomeAsync(price);
                    Console.WriteLine($"Home Price: ${price} - Should Buy: {shouldBuy}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
