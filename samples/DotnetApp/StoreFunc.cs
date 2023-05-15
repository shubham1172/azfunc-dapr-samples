using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.Dapr;
using Microsoft.Azure.Functions.Extensions.Dapr.Core;

namespace DotnetApp
{
    public static class StoreFunc
    {
        [FunctionName("StoreFunc")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [DaprInvoke(AppId = "nodeapp", MethodName = "CreateNewOrder", HttpVerb = "post")] IAsyncCollector<InvokeMethodParameters> output,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a CreateNewOrder request.");

            Console.WriteLine("before for loop");
            for (int i = 1; i <= 3; i++)
            {
                var order = new Order(i, i * 10, "item" + i);
                var outputContent = new InvokeMethodParameters
                {
                    Body = order,
                };

                await output.AddAsync(outputContent);
                Console.WriteLine("Order passed: " + order);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            return new OkResult();
        }
    }
}