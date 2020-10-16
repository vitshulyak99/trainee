using Xunit;

namespace XUnitTestTask4.MainWorkerTests
{
    [CollectionDefinition("MainWorker Collection")]
    class MainWorkerCollection:ICollectionFixture<MainWorkerFixture>
    {

    }
}
