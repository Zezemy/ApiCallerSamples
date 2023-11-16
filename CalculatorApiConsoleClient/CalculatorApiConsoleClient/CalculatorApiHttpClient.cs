using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculatorApiConsoleClient
{
    internal class CalculatorApiHttpClient
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task CalculatorApiPostRequest(string methodName, double num1, double num2)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                CalculationRequest calculationRequest = new CalculationRequest(methodName, num1, num2);

                var jsonContent = JsonSerializer.Serialize(calculationRequest);
                using var httpContent = new StringContent
                    (jsonContent, Encoding.UTF8, "application/json");

                using HttpResponseMessage response = await client.PostAsync("https://dotnetcalculatorapi.azurewebsites.net/", httpContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
