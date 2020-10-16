using System;
using System.Linq;
using Xunit;
using Parser = Task4.LineHandlers.LineParser;

namespace XUnitTestTask4.LineParserTests
{
    public class LineParser_SymbolsRepeats
    {
        [Fact]
        public void OneSymbolLine_s_lenght()
        {
            // arrange
            var line = "ssssssssss";
            var sym = line[0];
            int actual = line.Length;
            // act
            var expected = Parser.SymRepeats(line, sym);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NullLine_throwArgumentException()
        {
            // arrange
            string line = null;
            // act and assert
            Assert.Throws<ArgumentException>(() =>
            {
                Parser.SymRepeats(line, default);
            });
        }

        [Fact]
        public void EmptyLine_throwArgumentException()
        {
            // arrange
            string line = string.Empty;

            // act and assert
            Assert.Throws<ArgumentException>(() =>
            {
                var result = Parser.SymRepeats(line, default);
            });
        }


        [Theory]
        [InlineData("dfdgfhhjkjjjghgffddf", 'd')]
        [InlineData("dfdgfhhjkjjjghgffddf", 'f')]
        [InlineData("dfdgfhhjkjjjghgffddf", 'g')]
        public void SymRepeats_LongLine_GetCount(string line, char sym)
        {
            // arrange
            var actual = line.Where(l => l == sym).Count();

            // act
            var expected = Parser.SymRepeats(line, sym);
            // assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("dfdgfhhjkjjjghgffddf", 'e')]
        [InlineData("dfdgfhhjkjjjghgffddf", 'a')]
        [InlineData("dfdgfhhjkjjjghgffddf", 'z')]
        public void LongLine_NotExist_Sym(string line, char sym)
        {
            // arrange
            var actual = 0;

            // act
            var expected = Parser.SymRepeats(line, sym);

            // assert
            Assert.Equal(expected, actual);
        }

    }
}
