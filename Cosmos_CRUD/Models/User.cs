using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmos_CRUD.Models
{
    public class UserInfo
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string designation { get; set; }
        public string country { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
