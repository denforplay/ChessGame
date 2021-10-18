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
            _gameBoard.MoveChess(new ChessPosition(1, 2), new ChessPosition(1, 3));
            _gameBoard.MoveChess(new ChessPosition(1, 7), new ChessPosition(1, 6));
            _gameBoard.MoveChess(new ChessPosition(3, 2), new ChessPosition(3, 4));
            _gameBoard.MoveChess(new ChessPosition(7, 7), new ChessPosition(7, 6));
            _gameBoard.MoveChess(new ChessPosition(2, 1), new ChessPosition(5, 4));
            _gameBoard.MoveChess(new ChessPosition(6, 7), new ChessPosition(6, 5));
            _gameBoard.MoveChess(new ChessPosition(6, 2), new ChessPosition(6, 3));
            _gameBoard.MoveChess(new ChessPosition(6, 5), new ChessPosition(6, 4));
            _gameBoard.MoveChess(new ChessPosition(5, 4), new ChessPosition(3, 6));
            _gameBoard.MoveChess(new ChessPosition(3, 8), new ChessPosition(4, 6));
        }
    }
}
