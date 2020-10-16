

namespace StoreWarehouse.Core.UnitTest
{
    public static class Connections
    {

        public static string EntityFramework { get; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EFTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string Dapper { get; } = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=DapperTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
