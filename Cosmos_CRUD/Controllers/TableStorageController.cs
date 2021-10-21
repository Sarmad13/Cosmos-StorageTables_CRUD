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
        [HttpGet("AddTable")]
        public IActionResult Index()
        {
            TableStorage obj = new TableStorage();
            obj.AddTable();
            return null;
        }
    }
}
