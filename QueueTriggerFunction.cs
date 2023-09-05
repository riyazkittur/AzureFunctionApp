using System;
using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctionApp
{
    public class QueueTriggerFunction
    {
        [FunctionName("QueueTriggerFunction")]
        [return: Table("demotableriyazkittur", Connection = "STORAGE_ACCOUNT_CONNSTR")]
        public EmployeeModel Run([QueueTrigger("demoqueueriyaz", Connection = "STORAGE_ACCOUNT_CONNSTR")]string myQueueItem, ILogger log)
        {
            var dto = JsonSerializer.Deserialize<AddEmployeeDto>(myQueueItem);
            return new EmployeeModel
            {
                PartitionKey = "DigitalOcean",
                RowKey = Guid.NewGuid().ToString(),
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };
        }
    }
}
