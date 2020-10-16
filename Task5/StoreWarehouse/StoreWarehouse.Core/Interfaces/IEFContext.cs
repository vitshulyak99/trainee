using StoreWarehouse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreWarehouse.Core.Interfaces
{
    public interface IEFContext
    {
        public IEnumerable<SubCategory> GetAllSubCategories();

        public bool CheckSubCategoryName(SubCategory category);

        public void AddSubCategory(SubCategory category);

        public void DeleteCategory(Category category);

        public void DeleteCategory(IEnumerable<Category> corecategories);

        public void DeleteSubCategory(IEnumerable<SubCategory> corecategories);

        public IEnumerable<Category> GetAllCategories();

        public bool CheckCategoryName(Category category);

        public void AddGoodToSubCategory(Good good, SubCategory category);

        public void AddCategory(Category category);
    }
}
