using ChessLib.Models;
using ChessLib.Models.Enums;
using ChessLib.Models.Figures;
using System;
using Xunit;

namespace ChessTests.ModelsTests
{
    public class BoardCellTests
    {
        [Fact]
        public void CreateBoardCell_WithNullChessPosition_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BoardCell(null, new EmptyChess(new ChessPosition(1, 1), ChessColor.None)));
        }

        [Fact]
        public void CreateBoardCell_WithNullChess_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BoardCell(new ChessPosition(1, 1), null));
        }

        [Theory]
        [InlineData('a', 1, "X: 1, Y: 1 None EmptyChess X: 1, Y: 1")]
        [InlineData('b', 2, "X: 2, Y: 2 None EmptyChess X: 2, Y: 2")]
        [InlineData('c', 3, "X: 3, Y: 3 None EmptyChess X: 3, Y: 3")]
        public void CreateBoardCell_WithValidData(char horizontal, int vertical, string expected)
        {
            var chessPos = new ChessPosition(horizontal, vertical);
            BoardCell cell = new BoardCell(chessPos, new EmptyChess(chessPos, ChessColor.None));
            Assert.Equal(expected, cell.ToString());
        }
    }
}
