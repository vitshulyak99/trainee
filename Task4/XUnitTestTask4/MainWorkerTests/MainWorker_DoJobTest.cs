
using Xunit;
using Moq;
using Task4.Provider.Interface;
using System;

using Moq.Language;


namespace XUnitTestTask4.MainWorkerTests
{
    [Collection("MainWorker Collection")]
    public class MainWorker_DoJobTest:IClassFixture<MainWorkerFixture>
    {
        

        MainWorkerFixture fixture;

        Mock<ITextIO> tpm = null;

        public MainWorker_DoJobTest()
        {
            this.fixture = new MainWorkerFixture();
            string textFile = "And produce say the ten moments parties." +
            " Simple innate summer fat appear basket his desire joy. ";
            var repos = new MockRepository(MockBehavior.Strict);
            tpm = repos.Create<ITextIO>();
            //var modifiedDateActual = DateTime.Now;
            tpm.Setup(t => t.Write(It.IsAny<char>(), true));
            tpm.Setup(t => t.ReadAll()).Returns(textFile);
            tpm.SetupGet(t => t.LastModified).Returns(DateTime.Now);
            
        }

        [Theory]
        [InlineData("wqertyui",3)]
        [InlineData("dsfghfdsafghhfgfd",5)]
        [InlineData("qwertfdgsdas",4)]
        [InlineData("dsfdsgfgsrgggs",6)]
        public void DoJob_CorrectInputLine_WriteCallsTheory(string symbols,int n)
        {

            // Arrange
            int exepectedCountCalls = symbols.Length / n;
         
            
            // tpm.Setup(tp => tp.Write('a', true));
           
            //ISetupSequentialResult<string> setupSequentialResult = null; 

            //foreach (var item in symbols)
            //{
            //    if(setupSequentialResult is null)
            //       setupSequentialResult = tpm.SetupSequence(t => t.ReadAll()).Returns(textFile);
            //    else
            //    {
            //        setupSequentialResult.Returns(textFile);
            //    }
            //}

           


            // Act
            fixture.Worker.SetProvider(tpm.Object);
            fixture.Worker.DoJob(symbols,n);

            // Assert
            tpm.Verify(tp => tp.Write(It.IsAny<char>(), true),
                Times.Exactly(exepectedCountCalls));

            //Assert.Equal(exepectedCountCalls, actualCountCalls);
        }

        [Theory]
        [InlineData("asdfsgd",3)]
        [InlineData("asdfghjhasdfsgd",6)]
        public void DoJob_CorrectInputLine_LastUpdateCallsSymbolCount(string symbols,int n)
        {

            // Arrange
            var expectedCalls = symbols.Length;

            // Act
            fixture.Worker.SetProvider(tpm.Object);
            fixture.Worker.OnUpdate += (a, c) => { };
            fixture.Worker.DoJob(symbols,n);

            // Assert
            tpm.VerifyGet(tp => tp.LastModified, Times.Exactly(expectedCalls));
        }

        [Theory]
        [InlineData("agtssfew",2)]
        [InlineData("agew",1)]
        public void DoJob_CorrectInputLine_ReadAllCallsSymbolCount(string symbols,int n)
        {

            // Arrange
            var expectedCalls = symbols.Length;

            // Act
            fixture.Worker.SetProvider(tpm.Object);
            fixture.Worker.OnUpdate += (a, c) => { };
            fixture.Worker.DoJob(symbols,n);

            // Assert
            tpm.Verify(tp => tp.ReadAll(), Times.Exactly(expectedCalls));
        }


    }

}
