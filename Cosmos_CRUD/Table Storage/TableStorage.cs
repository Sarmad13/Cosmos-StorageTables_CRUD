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

            //var serviceClient = new TableServiceClient("DefaultEndpointsProtocol=https;AccountName=storagetablesample;AccountKey=E28+trOE/FQYpBzGbbEPP9puAMdkwkbAJxO6uW9N7xdqubw2yKYLOMtGVSwaSz5exmJe5kim4VRD9SgmPsto1w==;EndpointSuffix=core.windows.net");
            //tableClient = serviceClient.GetTableClient("Employee");
        }
        public void AddTable()
        {
            Table.CreateIfNotExistsAsync();
        }
        public void insertEmployee(Employee employee)
        {
            TableOperation insertOperation = TableOperation.InsertOrReplace(employee);
            Table.ExecuteAsync(insertOperation);
        }
        public async Task<List<Employee>> GetData(string key,string value)
        {
            string filter = TableQuery.GenerateFilterCondition(key, QueryComparisons.Equal,value);
            TableQuery<Employee> tableQuery = new TableQuery<Employee>().Where(filter);
            var employees = await Table.ExecuteQuerySegmentedAsync(tableQuery, null);
            return employees.Results;
        }
        public async Task<dynamic> DeleteData(Employee employee)
        {
            TableOperation replaceOperation = TableOperation.Delete(employee);
            var obj = Table.ExecuteAsync(replaceOperation);
            return obj.Result;
        }
    }
}
