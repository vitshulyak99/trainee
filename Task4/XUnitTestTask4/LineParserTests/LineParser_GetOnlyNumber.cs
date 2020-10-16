using System;
using Xunit;
using Parser = Task4.LineHandlers.LineParser;
using Task4.Exceptions;

namespace XUnitTestTask4.LineParserTests
{
    public class LineParser_GetOnlyNumber
    {
        [Fact]
        public void GetOnlyNumber_NullLine_ArgumentNullException()
        {
            // Arrange
            string line = null;

            // Act and Assert 
            Assert.Throws<ArgumentNullException>(() => Parser.GetOnlyNumber(line));

        }

        [Fact]
        public void GetOnlyNumber_IncorrectLine_InvalidInputStringException()
        {
            // Arrange
            string line = string.Empty;

            // Act and Assert 
            Assert.Throws<InvalidInputStringException>(() =>
            {
                Parser.GetOnlyNumber(line);
            });
        }

        [Theory]
        [InlineData("a,b,d,c,g,5")]
        [InlineData("a,b,d,g,10")]
        [InlineData("a,b,d,c,4")]
        public void GetOnlyNumber_CorrectLinePositiveNumber_GetNumber(string line)
        {
            // Arrange
            int index = line.LastIndexOf(",");
            var actual = int.Parse(line[(index + 1)..]);

            // Act 
            var expected = Parser.GetOnlyNumber(line);

            // Assert
            Assert.Equal(expected, actual);


        }

        [Theory]
        [InlineData("a,b,d,c,g,-5")]
        [InlineData("a,b,d,g,-10")]
        [InlineData("a,b,d,c,-4")]
        public void GetOnlyNumber_CorrectLineNegativeNumber_GetNumber(string line)
        {
            // Arrange
            int index = line.LastIndexOf(",");
            var actual = int.Parse(line[(index + 1)..]);

            // Act 
            var expected = Parser.GetOnlyNumber(line);

            // Assert
            Assert.Equal(expected, actual);



        }

        [Theory]
        [InlineData("a,b,d,c,g,-5.55")]
        [InlineData("a,b,d,g,-10.4")]
        [InlineData("a,b,d,c,-4.345")]
        public void GetOnlyNumber_CorrectLineDecimalNumber_GetNumber(string line)
        {

            // Act and Assert
            Assert.Throws<InvalidInputStringException>(() =>
            {
                var expected = Parser.GetOnlyNumber(line);
            });



        }
    }
}