using System.Linq;
using System.Text.RegularExpressions;
using Task4.Exceptions;
using Xunit;
using Parser = Task4.LineHandlers.LineParser;

namespace XUnitTestTask4.LineParserTests
{
    public class LineParser_GetOnlyWordSymbol
    {

        [Theory]
        [InlineData("dfsghhjk")]
        [InlineData("d,f,s,g,h,h,j,k")]
        [InlineData("df,s,g,h,h,j,44k")]
        [InlineData("44,5,8")]
        public void GetOnlyWordCharacterFromString_IncorrectLine_ThrowInvalidInputStringEsception(string line)
        {
            // arrange

            // act and assert
            Assert.Throws<InvalidInputStringException>(() =>
            {
                var result = Parser.GetOnlyWordCharacterFromString(line);
            });
        }

        [Fact]
        public void GetOnlyWordCharacterFromString_NullLine_ThrowArgumentNullException()
        {
            // Arrange 
            string line = null;

            // act and assert
            Assert.Throws<System.ArgumentNullException>(() =>
            {
                var result = Parser.GetOnlyWordCharacterFromString(line);
            });
        }

        [Theory]
        [InlineData("a,b,c,d,5")]
        [InlineData("f,g,c,d,7")]
        [InlineData("a,a,a,a,4")]
        public void GetOnlyWordCharacterFromString_CorrectLine_GetSymbols(string line)
        {
            // arrange
            var reg = new Regex(@"[a-zA-Z]");
            string actual = string.Empty;
            line.Where(l => reg.IsMatch(l.ToString())).ToList().ForEach(ch => actual += ch);

            // act
            var expected = Parser.GetOnlyWordCharacterFromString(line);

            // assert
            Assert.Equal(expected, actual);

        }
    }
}
