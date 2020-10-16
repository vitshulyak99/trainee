using StoreWarehouse.Core.Entities;
using StoreWarehouse.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreWarehouse.Core.DataContext
{
    public class MyDataContext
    {
        public MyDataContext(IEFContext efContext, IDapperGoodsRepository goods)
        {
            this.EfContext = efContext;
            Goods = goods;
        }

 
        public IEFContext EfContext { get; }

        public IDapperGoodsRepository Goods { get; }

    }
}
