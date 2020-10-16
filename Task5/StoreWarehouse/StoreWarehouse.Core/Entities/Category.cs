using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StoreWarehouse.Core.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
