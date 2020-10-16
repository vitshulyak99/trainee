using Newtonsoft.Json;
using System;


namespace StoreWarehouse.Core.Entities
{
    public class SubCategory
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? CategoryId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}