using Microsoft.Extensions.Configuration;
using StoreWarehouse.Core.DataContext;
using StoreWarehouse.DataAccess.Dapper.Repositories;
using StoreWarehouse.DataAccess.EntityFramework.Contexts;

namespace StoreWarehouse.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            // .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json"/*, optional: true, reloadOnChange: true*/);

            var config = builder.Build();

            var goodsDB = config.GetConnectionString("GoodsDB");
            var categoriesDB = config.GetConnectionString("CategoriesDB");

            MyDataContext myDataContext = new MyDataContext(efContext: new EFContext(categoriesDB), new GoodRepository(goodsDB));

          
            UserInterface.UInterface uInterface = new UserInterface.UInterface(new Core.Managers.DataManager(myDataContext));

            uInterface.MainMenu();


        }
    }
}



