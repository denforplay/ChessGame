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
        public void GameBoard_TestPawnMovements_ReturnsTrue()
        {
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition(2, 2), new ChessPosition(2, 4));
            game.MakeStep(new ChessPosition(3, 7), new ChessPosition(3, 5));
            game.MakeStep(new ChessPosition(4, 2), new ChessPosition(4, 4));
            game.MakeStep(new ChessPosition(3, 5), new ChessPosition(4, 4));
        }

        [Fact]
        public void CreateChessPosition_WithVerticalOutOfZone_ThrowArgumentException()
        {
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition(1, 2), new ChessPosition(1, 3));
            game.MakeStep(new ChessPosition(8, 7), new ChessPosition(8, 6));
            game.MakeStep(new ChessPosition(5, 2), new ChessPosition(5, 4));
            game.MakeStep(new ChessPosition(8, 6), new ChessPosition(8, 5));
            game.MakeStep(new ChessPosition(5, 1), new ChessPosition(5, 2));
        }
    }
}
