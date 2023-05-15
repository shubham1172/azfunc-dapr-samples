using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Extensions.Dapr.Core;
using System.Net.Http;
using Dapr.Client;

namespace DotnetApp
{
    public static class StoreFuncSdk
    {
        [FunctionName("StoreFuncSdk")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a CreateNewOrder request.");

            using var client = new DaprClientBuilder().Build();

            Console.WriteLine("before for loop");
            for (int i = 1; i <= 3; i++)
            {
                var order = new Order(i, i * 10, "item" + i);
                var outputContent = new InvokeMethodParameters
                {
                    Body = order,
                };

                try
                {
                    await client.InvokeMethodAsync<Order>("nodeapp", "CreateNewOrder", order);
                    Console.WriteLine("Order passed: " + order);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Order failed: " + e.InnerException.Message);
                }

                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            return new OkResult();
        }
    }
}