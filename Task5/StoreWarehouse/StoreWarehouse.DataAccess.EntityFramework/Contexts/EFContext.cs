using StoreWarehouse.Core.Entities;
using StoreWarehouse.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace StoreWarehouse.DataAccess.EntityFramework.Contexts
{
    using Models.Convertor;
    using System.Linq;

    public class EFContext : IEFContext
    {
        StoreWarehouseContext _context;

        public EFContext(string connectionString)
        {
            _context = new StoreWarehouseContext(connectionString);
        }

        public void AddCategory(Category category)
        {
            var newCategory = ModelConvertor.Convert(category);

            _context.Categories.Add(newCategory);

            _context.SaveChanges();
        }

        public void AddGoodToSubCategory(Good good, SubCategory category)
        {
            _context.SubCategoryGoods.Add(new Models.SubCategoryGood { GoodId = good.Id, Id = Guid.NewGuid(), SubCategoryId = category.Id });
        }

        public void AddSubCategory(SubCategory category)
        {
            var newSCategory = ModelConvertor.Convert(category);
            newSCategory.Category = _context.Categories.FirstOrDefault(f => f.Id == category.Id);

            _context.Add(newSCategory);

            _context.SaveChanges();

        }

        public bool CheckCategoryName(Category category)
        {
            return _context.Categories.Any(c => c.Name == category.Name);
        }

        public bool CheckSubCategoryName(SubCategory category)
        {
            return _context.SubCategories.Any(c => c.Name == category.Name);
        }

        public void DeleteCategory(Category category)
        {
            var item = _context.Categories.FirstOrDefault(f => f.Id == category.Id);

            if (!(item is null))
            {
                var sc = _context.SubCategories.Where(scg => scg.Category.Id == item.Id);
                _context.RemoveRange(sc);
                _context.Remove(item);
                _context.SaveChanges();
            }
        }

        public void DeleteCategory(IEnumerable<Category> corecategories)
        {
            List<Models.Category> categories = new List<Models.Category>();

            corecategories.ToList().ForEach(cc => categories.AddRange(_context.Categories.Where(c => c.Id == cc.Id)));

            List<Models.SubCategory> subCategories = new List<Models.SubCategory>();

            categories.ForEach(c => _context.RemoveRange(c.SubCategories));

            _context.RemoveRange(categories);
            _context.SaveChanges();
        }

        public void DeleteSubCategory(SubCategory category)
        {
            var item = _context.SubCategories.FirstOrDefault(f => f.Id == category.Id);

            if (!(item is null))
            {
                _context.Remove(item);
                _context.SaveChanges();
            }

        }

        public void DeleteSubCategory(IEnumerable<SubCategory> corecategories)
        {
            List<Models.SubCategory> categories = new List<Models.SubCategory>();

            corecategories.ToList().ForEach(cc => categories.AddRange(_context.SubCategories.Where(c => c.Id == cc.Id)));

            if (categories.Count > 0)
            {
                _context.RemoveRange(categories);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return Array.ConvertAll(_context.Categories.ToArray(), (c) => ModelConvertor.Convert(c));
        }

        public IEnumerable<SubCategory> GetAllSubCategories()
        {
            return Array.ConvertAll(_context.SubCategories.ToArray(), (c) =>
            {
                var sc =  ModelConvertor.Convert(c);
                sc.CategoryId = c.Id;
                return sc;
            });
        }

        public Category GetCategoryByID(Guid id)
        {
            return ModelConvertor.Convert(_context.Categories.FirstOrDefault(f => f.Id == id));
        }

        public SubCategory GetSubCategoryByID(Guid id)
        {
            return ModelConvertor.Convert(_context.SubCategories.FirstOrDefault(f => f.Id == id));
        }

        public void UpdateCategory(Category category)
        {
            var newCategory = ModelConvertor.Convert(category);
            _context.Categories.Update(newCategory);
            _context.SaveChanges();
        }

        public void UpdateSubCategory(SubCategory category)
        {
            var newCategory = ModelConvertor.Convert(category);
            _context.SubCategories.Update(newCategory);
            _context.SaveChanges();
        }
    }
}
