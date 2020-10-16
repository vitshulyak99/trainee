
using Newtonsoft.Json;
using System;


namespace StoreWarehouse.Core.Entities
{
    public class Good
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime ManufacturingDate
        {
            get; set;
        }

        public DateTime ExpireDate
        {
            get; set;
        }

        public int Count { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
