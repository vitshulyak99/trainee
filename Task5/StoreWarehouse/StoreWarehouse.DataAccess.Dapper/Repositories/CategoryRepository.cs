using StoreWarehouse.Core.Entities;
using StoreWarehouse.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreWarehouse.DataAccess.Dapper.Repositories
{
    class CategoryRepository : IRepository<Category>
    {
        public void Add(Category item)
        {

        }

        public bool CheckName(Category item)
        {
            throw new NotImplementedException();
        }

        public Category Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Category item)
        {
            throw new NotImplementedException();
        }

        public void Update(Category newV)
        {
            throw new NotImplementedException();
        }
    }
}
