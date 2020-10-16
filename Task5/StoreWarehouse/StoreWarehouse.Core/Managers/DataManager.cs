
using StoreWarehouse.Core.DataContext;
using StoreWarehouse.Core.Entities;
using StoreWarehouse.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreWarehouse.Core.Managers
{
   
    public class DataManager
    {
        private MyDataContext _context;

        public DataManager(MyDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Good> GetAllGoods()
        {
            return _context.Goods.GetAll();
        }

        
        public IEnumerable<Good> GetAllGoodsWhereCount(int x)
        {
            return _context.Goods.GetAllByCountLessX(x);
        }
        public IEnumerable<Good> GetAllGoodsWhereExpireDateBefore(DateTime date)
        {
            return _context.Goods.GetAllByExpireBeforeXDate(date);
        }

        public IEnumerable<SubCategory> GetAllSubCategories() => _context.EfContext.GetAllSubCategories();

        public IEnumerable<Category> GetAllCategories() => _context.EfContext.GetAllCategories();

        public void AddGood(Good good)
        {
            if (good.ExpireDate <= good.ManufacturingDate) throw new InvalidExpirationDateException();
           
            _context.Goods.Add(good);
        }

        public void UpdateGood(Good good)
        {
            if (good.ExpireDate <= good.ManufacturingDate) throw new InvalidExpirationDateException();

            var r =_context.Goods.Get(good.Id);

            if (r is null)
                throw new NotExistItemException();

            _context.Goods.Update(good);
        }

        public void RemoveGood(Good good)
        {
            
            var r = _context.Goods.Get(good.Id);

            if (r is null)
                throw new NotExistItemException();

            _context.Goods.Remove(r);
        }

        public void AddCategory(Category category)
        {
            if (_context.EfContext.CheckCategoryName(category))
            {
                throw new ExistCategoryNameException();
            }

            _context.EfContext.AddCategory(category);
        }

        public void RemoveCategory(Category category)
        {
            if (_context.EfContext.GetCategoryByID(category.Id) is null)
            {
                throw new NotExistItemException();
            }

            _context.EfContext.DeleteCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            if(_context.EfContext.CheckCategoryName(category))
            {
                throw new ExistCategoryNameException();
            }

            _context.EfContext.UpdateCategory(category);
        }     

        public void AddSubCategory(SubCategory category)
        {
            if (_context.EfContext.CheckSubCategoryName(category))
            {
                throw new ExistSubCategoryNameException();
            }

            _context.EfContext.AddSubCategory(category);
        }   

        public void UpdateSubCategory(SubCategory category)
        {

            if (_context.EfContext.CheckSubCategoryName(category))
            {
                throw new ExistCategoryNameException();
            }

            _context.EfContext.UpdateSubCategory(category);
        }

        public void RemoveSubCategory(SubCategory category)
        {
            if (_context.EfContext.GetSubCategoryByID(category.Id)==null)
            {
                throw new NotExistItemException();
            }
            _context.EfContext.DeleteSubCategory(category);
        }

        public void AddGoodToSubCaategory(Good good, SubCategory subCategory)
        {
            _context.EfContext.AddGoodToSubCategory(good,subCategory);
        }

    }


       
    
}
