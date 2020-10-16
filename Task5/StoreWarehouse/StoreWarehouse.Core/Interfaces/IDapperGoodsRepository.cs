using StoreWarehouse.Core.Entities;
using System;
using System.Collections.Generic;

namespace StoreWarehouse.Core.Interfaces
{
    public interface IDapperGoodsRepository:IRepository<Good>
    {
        IEnumerable<Good> GetAllByCountLessX(int x);

        IEnumerable<Good> GetAllByExpireBeforeXDate(DateTime xDate);
    }
}
