using System;

namespace StoreWarehouse.DataAccess.EntityFramework.Models
{
    public class SubCategoryGood
    {
        public Guid Id { get; set; }

        public Guid SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; } = new SubCategory();

        public Guid GoodId { get; set; }

    }
}
