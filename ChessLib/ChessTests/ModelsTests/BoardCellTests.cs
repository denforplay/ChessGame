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

        [Fact]
        public void CreateBoardCell_WithValidData()
        {
            string expected = "";
            var chessPos = new ChessPosition(1, 1);
            BoardCell cell = new BoardCell(chessPos, new EmptyChess(chessPos, ChessColor.None));
            Assert.Equal(expected, cell.ToString());
        }
    }
}
