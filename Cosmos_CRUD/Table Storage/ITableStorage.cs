using Cosmos_CRUD.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cosmos_CRUD.Table_Storage
{
    public interface ITableStorage
    {
        CloudStorageAccount Account { get; set; }
        CloudTableClient Client { get; set; }
        CloudTable Table { get; set; }

        void AddTable();
        Task<dynamic> DeleteData(Employee employee);
        Task<List<Employee>> GetData(string key, string value);
        void insertEmployee(Employee employee);
    }
}