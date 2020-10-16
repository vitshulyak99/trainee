using StoreWarehouse.Core.Entities;
using StoreWarehouse.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StoreWarehouse.Core.UnitTest.ManagerTest
{
    [CollectionDefinition("ManagerTestDataCollection")]
    public class DataManager_EditSubCategory : IClassFixture<DataSetFixture>
    {
        DataSetFixture _fixture;

        public DataManager_EditSubCategory(DataSetFixture fixture)
        {
            _fixture = fixture;

        }


        [Fact]
        public void EditSubCategory_ExistName_ExistCategoryNameException()
        {
            //arrange 
            SubCategory category = new SubCategory()
            {
                Id = Guid.NewGuid(),
                Name = "test2name" + new Random().Next(1, 10000)
            };

            // act and assert
            Assert.Throws<ExistSubCategoryNameException>(() =>
            {

                _fixture.DataManager.AddSubCategory(category);
                category.Name = "testCategory";
                _fixture.DataManager.AddSubCategory(category);
            });
        }
    }
}
