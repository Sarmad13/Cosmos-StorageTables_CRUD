using Cosmos_CRUD.Models;
using Cosmos_CRUD.Table_Storage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmos_CRUD.Controllers
{
    [ApiController]
    public class TableStorageController : Controller
    {
        TableStorage tableStorage;
        public TableStorageController()
        {
            tableStorage = new TableStorage();

        }
        [HttpGet("addTable")]
        public IActionResult Index()
        {
            tableStorage.AddTable();
            return null;
        }

        [HttpGet("getData/{key}/{value}")]
        public Task<List<Employee>> GetData([FromRoute] string key, [FromRoute] string value)
        {
            var employees= tableStorage.GetData(key,value);
            return employees;
        }
        [HttpPost("saveData")]
        public IActionResult SaveData([FromBody] Employee employee)
        {
            tableStorage.insertEmployee(employee);
            return Ok();
        }
        [HttpDelete("deleteData")]
        public Task<dynamic> DeleteData([FromBody] Employee employee)
        {
            return tableStorage.DeleteData(employee);
        }
    }
}
