using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.Dapr;
using System.Text.Json;

namespace DotnetApp
{
    public static class SubscribeOrders
    {
        [FunctionName("SubscribeOrders")]
        public static void Run(
            [DaprTopicTrigger("pubsub", Topic = "orders")] Order order,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a SubscribeOrders request.");
            log.LogInformation("Order received: " + JsonSerializer.Serialize(order));
        }
    }
}