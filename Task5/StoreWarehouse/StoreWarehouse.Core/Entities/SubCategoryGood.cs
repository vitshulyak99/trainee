using System;


namespace StoreWarehouse.Core.Entities
{
    public class SubCategoryGood
    {
        public Guid Id { get; set; }

        public  Guid GoodId { get; set; }

        public  Guid SubCategoryId { get; set; }
      
    }
}
