using Xunit;
using ChessLib.Models;
using ChessLib.Models.Game;
using ChessLib.Models.Configurations;
using ChessLib.Models.Players;
using ChessLib.Models.Enums;

namespace ChessTests.ModelsTests.ChessModelsTests
{
    public class KingTests
    {
       [Fact]
       public void KingMovement_TestUpMove_ReturnsTrue()
       {
            string expected = "X: 5, Y: 2 White King X: 5, Y: 2";
            GameBoard gameBoard = new GameBoard();
            PlayerConfiguration playerConfiguration = new PlayerConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('e', 2), new ChessPosition('e', 3));
            game.MakeStep(new ChessPosition('d', 7), new ChessPosition('d', 6));
            game.MakeStep(new ChessPosition('e', 1), new ChessPosition('e', 2));
            Assert.Equal(expected, game.GameBoard.BoardCells[4, 1].ToString());
       }

        [Fact]
        public void KingMovement_TestInvalidMove_ThrowsArgumentException()
        {
            string expected = "X: 5, Y: 2 White King X: 5, Y: 2";
            GameBoard gameBoard = new GameBoard();
            PlayerConfiguration playerConfiguration = new PlayerConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('e', 2), new ChessPosition('e', 3));
            game.MakeStep(new ChessPosition('d', 7), new ChessPosition('d', 6));
            game.MakeStep(new ChessPosition('e', 1), new ChessPosition('e', 2));
            Assert.Equal(expected, game.GameBoard.BoardCells[4, 1].ToString());
        }
    }
}
