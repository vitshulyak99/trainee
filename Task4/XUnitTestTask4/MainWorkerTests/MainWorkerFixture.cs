using System;
using Task4.Worker;

namespace XUnitTestTask4.MainWorkerTests
{
    class MainWorkerFixture:IDisposable
    {
        public MainWorkerFixture()
        {
            Worker = new MainWorker();
        }

        public void Dispose()
        {
            Worker = null;
        }

        public MainWorker Worker { get; private set; }

     
    }
}
