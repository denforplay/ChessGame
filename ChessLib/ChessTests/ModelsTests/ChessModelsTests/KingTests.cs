using Xunit;
using ChessLib.Models;
using ChessLib.Models.Game;

namespace ChessTests.ModelsTests.ChessModelsTests
{
    public class KingTests
    {
       [Fact]
       public void KingMovement_TestUpMove_ReturnsTrue()
       {
            string expected = "X: 5, Y: 2 White King X: 5, Y: 2";
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('e', 2), new ChessPosition('e', 3));
            game.MakeStep(new ChessPosition('d', 7), new ChessPosition('d', 6));
            game.MakeStep(new ChessPosition('e', 1), new ChessPosition('e', 2));
            Assert.Equal(expected, game.GameBoard.BoardCells[4, 1].ToString());
       }

        [Fact]
        public void KingMovement_TestInvalidMove_ThrowsArgumentException()
        {
            string expected = "X: 5, Y: 2 White King X: 5, Y: 2";
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('e', 2), new ChessPosition('e', 3));
            game.MakeStep(new ChessPosition('d', 7), new ChessPosition('d', 6));
            game.MakeStep(new ChessPosition('e', 1), new ChessPosition('e', 2));
            Assert.Equal(expected, game.GameBoard.BoardCells[4, 1].ToString());
        }
    }
}
