using StoreWarehouse.Core.Entities;
using StoreWarehouse.Core.Exceptions;
using System;
using Xunit;

namespace StoreWarehouse.Core.UnitTest.ManagerTest
{
    [CollectionDefinition("ManagerTestDataCollection")]
    public class DataManager_AddCategory : IClassFixture<DataSetFixture>
    {
        DataSetFixture _fixture;

        public DataManager_AddCategory()
        {
            _fixture = new DataSetFixture();
        }

        [Fact]
        public void AddCategoryWithExistName()
        {

            // act and assert
            Assert.Throws<ExistCategoryNameException>(() => {
                _fixture.DataManager.AddCategory(new Entities.Category { Id = Guid.NewGuid(), Name = "testCategory" });
                _fixture.DataManager.AddCategory(new Entities.Category { Id = Guid.NewGuid(), Name = "testCategory" });
            });
        }

    }
}
