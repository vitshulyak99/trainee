using StoreWarehouse.Core.Exceptions;
using System;
using Xunit;

namespace StoreWarehouse.Core.UnitTest.ManagerTest
{
    [CollectionDefinition("ManagerTestDataCollection")]
    public class DataManager_AddSubCategory : IClassFixture<DataSetFixture>
    {
        DataSetFixture _fixture;

        public DataManager_AddSubCategory()
        {
            _fixture = new DataSetFixture();
        }

        [Fact]
        public void AddCategoryWithExistName()
        {

            // act and assert
            Assert.Throws<ExistSubCategoryNameException>(() =>
            {
                _fixture.DataManager.AddSubCategory(new Entities.SubCategory { Id = Guid.NewGuid(), Name = "testCategory" });
                _fixture.DataManager.AddSubCategory(new Entities.SubCategory { Id = Guid.NewGuid(), Name = "testCategory" });
            });
        }

    }
}
