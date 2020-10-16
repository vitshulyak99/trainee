
using System;
using System.Collections.Generic;

namespace StoreWarehouse.DataAccess.EntityFramework.Models
{
    public class SubCategory
    {
        public SubCategory()
        {
            this.SubCategoryGoods = new HashSet<SubCategoryGood>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual Category Category { get; set; } = new Category();

        public virtual ICollection<SubCategoryGood> SubCategoryGoods { get; set; }
    }
}