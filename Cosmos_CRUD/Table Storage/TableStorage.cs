using Cosmos_CRUD.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Data.Tables;
namespace Cosmos_CRUD.Table_Storage
{
    public class TableStorage
    {
        public CloudStorageAccount Account { get; set; }
        public CloudTableClient Client { get; set; }
        public CloudTable Table { get; set; }
        public TableClient tableClient;

        public TableStorage()
        {
            Account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=storagetablesample;AccountKey=E28+trOE/FQYpBzGbbEPP9puAMdkwkbAJxO6uW9N7xdqubw2yKYLOMtGVSwaSz5exmJe5kim4VRD9SgmPsto1w==;EndpointSuffix=core.windows.net");
            Client = Account.CreateCloudTableClient();
            Table = Client.GetTableReference("Employee");

            var serviceClient = new TableServiceClient("DefaultEndpointsProtocol=https;AccountName=storagetablesample;AccountKey=E28+trOE/FQYpBzGbbEPP9puAMdkwkbAJxO6uW9N7xdqubw2yKYLOMtGVSwaSz5exmJe5kim4VRD9SgmPsto1w==;EndpointSuffix=core.windows.net");
            tableClient = serviceClient.GetTableClient("Employee");
        }
        public void AddTable()
        {
            Table.CreateIfNotExistsAsync();
            Employee employeeEntity = new Employee("Sarmad", "Saeed")
            {
                Email = "mohd@sbeeh.com",
                PhoneNumber = "123456789"

            };
            TableOperation insertOperation = TableOperation.Insert(employeeEntity);
            Table.ExecuteAsync(insertOperation);

        }
        //public async Task<IEnumerable<Employee>> GetData()
        //{
        //    TableContinuationToken token = null;
        //    do
        //    {
        //        var o= tableClient.query<Employee>(ent => ent.PartitionKey.Equals("ThanksApp"));
        //        var q = new TableQuery<Employee>();
        //        var queryResult = await Table.ExecuteQuerySegmentedAsync(q, token);
        //        foreach (var item in queryResult.Results)
        //        {
        //            yield return item;
        //        }
        //        token = queryResult.ContinuationToken;
        //    } while (token != null);
        //}
    }
}
