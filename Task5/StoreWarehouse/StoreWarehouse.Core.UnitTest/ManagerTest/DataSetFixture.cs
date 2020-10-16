using Moq;
using StoreWarehouse.Core.Managers;
using StoreWarehouse.DataAccess.Dapper.Repositories;
using StoreWarehouse.DataAccess.EntityFramework.Contexts;
using System;

namespace StoreWarehouse.Core.UnitTest.ManagerTest
{
    public class DataSetFixture : IDisposable
    {
        public MockRepository MockRepository { get; } = new MockRepository(MockBehavior.Loose);

        public DataManager DataManager { get; }

        public DataSetFixture()
        {

            DataManager = new Managers.DataManager(
                new DataContext.MyDataContext(new EFContext(Connections.EntityFramework),
                   new GoodRepository(Connections.Dapper)));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
