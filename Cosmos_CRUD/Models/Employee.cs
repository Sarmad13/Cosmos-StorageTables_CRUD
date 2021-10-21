using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmos_CRUD.Models
{
    public class Employee : TableEntity
    {
        public Employee(string lastName, string firstName)
        {
            this.PartitionKey = lastName; this.RowKey = firstName;
        }
        public Employee() { }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
