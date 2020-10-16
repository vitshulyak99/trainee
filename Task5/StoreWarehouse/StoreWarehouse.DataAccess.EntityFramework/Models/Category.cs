using System;
using System.Collections.Generic;

namespace StoreWarehouse.DataAccess.EntityFramework.Models
{
    public class Category
    {
        public Category()
        {
            this.SubCategories = new HashSet<SubCategory>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }

    }
}