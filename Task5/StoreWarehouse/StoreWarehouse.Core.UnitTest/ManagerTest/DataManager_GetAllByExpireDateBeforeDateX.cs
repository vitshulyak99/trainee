

using Moq;
using StoreWarehouse.Core.Interfaces;
using StoreWarehouse.Core.Managers;
using System;
using System.Linq;
using Xunit;

namespace StoreWarehouse.Core.UnitTest.ManagerTest
{
    [CollectionDefinition("ManagerTestDataCollection")]
    public class DataManager_GetAllByExpireDateBeforeDateX : IClassFixture<DataSetFixture>
    {
        DataSetFixture _fixture;

        public DataManager_GetAllByExpireDateBeforeDateX()
        {
            _fixture = new DataSetFixture();
        }

        [Fact]
        public void GetAllByExpireDate_CallOnce()
        {
            //arrange
            var goodMock = _fixture.MockRepository.Create<IDapperGoodsRepository>();
            var efMock = _fixture.MockRepository.Create<IEFContext>();
            goodMock.Setup(g => g.GetAllByExpireBeforeXDate(It.IsAny<DateTime>()));

            //act

            DataManager dataManage = new DataManager(new DataContext.MyDataContext(efMock.Object, goodMock.Object));

            dataManage.GetAllGoodsWhereExpireDateBefore(DateTime.Now);

            //assert          
            goodMock.Verify(v => v.GetAllByExpireBeforeXDate(It.IsAny<DateTime>()), Times.Once);
        }

    }
}
