using ChessLib.Models;
using System;
using Xunit;

namespace ChessTests.ModelsTests
{
    public class ChessPositionTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(9, 1)]
        public void CreateChessPosition_WithHorizontalOutOfZone_ThrowArgumentOutOfRangeException(int horizontal, int vertical)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ChessPosition(horizontal, vertical));
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(1, 9)]
        public void CreateChessPosition_WithVerticalOutOfZone_ThrowArgumentException(int horizontal, int vertical)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ChessPosition(horizontal, vertical));
        }

        [Theory]
        [InlineData(2, 2)]
        public void CreateChessPosition_WithValidIntData(int horizontal, int vertical)
        {
            var expected = (2, 2);
            ChessPosition chessPosition = new ChessPosition(horizontal, vertical);
            var actual = (chessPosition.Horizontal, chessPosition.Vertical);
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData('b', 2)]
        public void CreateChessPosition_WithValidCharData(char horizontal, int vertical)
        {
            var expected = (2, 2);
            ChessPosition chessPosition = new ChessPosition(horizontal, vertical);
            var actual = (chessPosition.Horizontal, chessPosition.Vertical);
            Assert.Equal(expected, actual);
        }


    }
}
