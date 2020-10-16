using StoreWarehouse.Core.Entities;
using StoreWarehouse.Core.Exceptions;
using System;
using Xunit;

namespace StoreWarehouse.Core.UnitTest.ManagerTest
{
    [CollectionDefinition("ManagerTestDataCollection")]
    public class DataManager_EditGood : IClassFixture<DataSetFixture>
    {
        DataSetFixture _fixture;

        public DataManager_EditGood()
        {
            _fixture = new DataSetFixture();
        }

        [Fact]
        public void AddGood_ExpireDateLessManufacturingDate()
        {
            //arrange
            Good good = new Good { Id = Guid.NewGuid(), Name = "invalideExpire", ManufacturingDate = DateTime.Now.AddDays(2), ExpireDate = DateTime.Now, Count = 20 };

            //act and assert
            Assert.Throws<InvalidExpirationDateException>(() => { _fixture.DataManager.AddGood(good); });
        }
    }
}
