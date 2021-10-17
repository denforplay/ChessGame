using ChessLib.Models;
using Xunit;

namespace ChessTests.ModelsTests
{
    public class ChessPositionTests
    {
        [Fact]
        public void CreateChessPosition_WithHorizontalOutOfZone_ThrowArgumentException()
        {

        }

        [Fact]
        public void CreateChessPosition_WithVerticalOutOfZone_ThrowArgumentException()
        {
            GameBoard _gameBoard = new GameBoard();
            _gameBoard.MoveChess(new ChessPosition(1, 2), new ChessPosition(1, 4));
            _gameBoard.MoveChess(new ChessPosition(6, 7), new ChessPosition(6, 5));
            _gameBoard.MoveChess(new ChessPosition(1, 4), new ChessPosition(1, 5));
        }
    }
}
