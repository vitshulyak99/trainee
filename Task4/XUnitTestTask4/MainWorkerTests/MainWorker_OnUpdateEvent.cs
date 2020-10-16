using Moq;
using System;
using System.Collections.Generic;
using Task4.Provider.Interface;
using Xunit;

using System.Linq;


namespace XUnitTestTask4.MainWorkerTests
{
    [Collection("MainWorker Collection")]
    public class MainWorker_OnUpdateEvent
    {
        MainWorkerFixture fixture;


        public MainWorker_OnUpdateEvent()
        {
            this.fixture = new MainWorkerFixture();
        }
        [Fact]
        public void OnUpdate_CorrectInputString_CorrectResultsAsync()
        {
            // Arrange
            List<(int,char,DateTime)> actual = new List<(int, char, DateTime)>();
            List<(int, char, DateTime)> expected = new List<(int, char, DateTime)>();
            string textFile = "And produce say the ten moments parties." +
           " Simple innate summer fat appear basket his desire joy. ";
            var tpm = new Mock<ITextIO>();
            var modifiedDateActual = DateTime.Now;
            string symbols = "aaa";
            int n = 2;
            
            tpm.Setup(tp => tp.Write('a', true));
            tpm.SetupSequence(t => t.LastModified)
                .Returns(modifiedDateActual)
                .Returns(modifiedDateActual)
                .Returns(modifiedDateActual);
            tpm.SetupSequence(t => t.ReadAll())
                .Returns(textFile)
                .Returns(textFile)
                .Returns(textFile + 'a');
            var x = textFile.Where(c => c == 'a').Count();
            var t1 = (7, 'a', modifiedDateActual);
            var t2 = (8, 'a', modifiedDateActual);
            actual.Add(t1);
            actual.Add(t1);
            actual.Add(t2);

            // Act
            fixture.Worker.SetProvider(tpm.Object);
            fixture.Worker.OnUpdate += (s, e) => expected.Add((e.Count,e.Symbol,e.UpdateTime));
            fixture.Worker.DoJob(symbols,n);

            // Assert 
            Assert.True(actual.All(item => expected.Exists(ex => ex == item)));
            
        }
    }
}
