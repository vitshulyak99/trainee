
using Moq;
using System;
using Task4.LineHandlers;
using Task4.Provider;
using Task4.Provider.Interface;
using Xunit;

namespace XUnitTestTask4.LineParserTests
{
    public class LineParser_RandomSymbolFromStringTest
    {
        [Theory]
        [InlineData("aaaaaaa",'a')]
        [InlineData("a",'a')]
        public void RandomSymbolFromString_OneSymbolString_Symbol(string line,char actual)
        {
            // 
            var intProvider = new RandomIntegerProvider();

            // act
            var expected = LineParser.RandomSymbolFromString(line,intProvider);

            // assert      
            Assert.Equal(expected , actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void RandomSymbolFromString_EmptyOrNullString_ArgumentException(string line)
        {
            // arrange
            var rand = new Mock<IGenerateInteger>();
            rand.Setup(r => r.Generate(It.IsAny<int>(), It.IsAny<int>())).Returns(0);

            // act and assert      
            Assert.Throws<ArgumentException>(()=>LineParser.RandomSymbolFromString(line,rand.Object));
        }

        [Fact]
        public void RandomSymbolFromStringTest_NullRandomIntegerProvider()
        {

            // arrange 
            string s = "asdfgb";
            RandomIntegerProvider rand = null;

            // act and assert      
            Assert.Throws<ArgumentNullException>(() => LineParser.RandomSymbolFromString(s,rand));
        }


        [Fact]
        public void RandomSymbolFromStringTest_LongString_20times_NotCompare()
        {
            // arrange
            var line = "asadfghjkhkjghgdfretyui";

            var fakeRandomIntegerProvider = new Mock<IGenerateInteger>();
            fakeRandomIntegerProvider.Setup(f => f.Generate(0, line.Length - 1)).Returns(0);

            var realRamdomIntegerProvider = new RandomIntegerProvider();

            string valuesFromFake = string.Empty;
            string valuesFromReal = string.Empty;

            // act
            for (int i = 0; i < 20; i++)
            {
                valuesFromFake += LineParser.RandomSymbolFromString(line, fakeRandomIntegerProvider.Object);
                valuesFromReal += LineParser.RandomSymbolFromString(line, realRamdomIntegerProvider);
            }


            // assert   
            fakeRandomIntegerProvider.Verify(f => f.Generate(0, line.Length - 1),Times.Exactly(20));
            Assert.NotEqual(valuesFromReal, valuesFromFake);
        }

   
        
    }
}
