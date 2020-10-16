using StoreWarehouse.Core.Entities;
using StoreWarehouse.Core.Exceptions;
using System;
using Xunit;

namespace StoreWarehouse.Core.UnitTest.ManagerTest
{
    [CollectionDefinition("ManagerTestDataCollection")]
    public class DataManager_EditCategory : IClassFixture<DataSetFixture>
    {
        DataSetFixture _fixture;

        public DataManager_EditCategory(DataSetFixture fixture)
        {
            _fixture = fixture;

        }


        [Fact]
        public void EditCategory_ExistName_ExistCategoryNameException()
        {
            //arrange 
            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "test2name" + new Random().Next(1, 10000)
            };

            // act and assert
            Assert.Throws<ExistCategoryNameException>(() =>
            {

                _fixture.DataManager.AddCategory(category);
                category.Name = "testCategory";
                _fixture.DataManager.AddCategory(category);
            });
        }
    }
}
