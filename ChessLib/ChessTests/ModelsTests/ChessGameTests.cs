using ChessLib.Models;
using ChessLib.Models.Configurations;
using ChessLib.Models.Enums;
using ChessLib.Models.Game;
using ChessLib.Models.Players;
using Xunit;

namespace ChessTests.ModelsTests
{
    public class ChessGameTests
    {
        [Fact]
        public void ChildMateGame_ReturnsTrue()
        {
            GameBoard gameBoard = new GameBoard();
            ChessesConfiguration playerConfiguration = new ChessesConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('e', 2), new ChessPosition('e', 4));
            game.MakeStep(new ChessPosition('e', 7), new ChessPosition('e', 5));
            game.MakeStep(new ChessPosition('f', 1), new ChessPosition('c', 4));
            game.MakeStep(new ChessPosition('b', 8), new ChessPosition('c', 6));
            game.MakeStep(new ChessPosition('d', 1), new ChessPosition('h', 5));
            game.MakeStep(new ChessPosition('g', 8), new ChessPosition('f', 6));
            game.MakeStep(new ChessPosition('h', 5), new ChessPosition('f', 7));
            Assert.Equal(GameState.BLACK_UNDER_MATE, game.GameState);
        }

        [Fact]
        public void ChessGame_TestBishopMovesRemovesUnderCheckState_ReturnsTrue()
        {
            GameBoard gameBoard = new GameBoard();
            ChessesConfiguration playerConfiguration = new ChessesConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('d', 2), new ChessPosition('d', 3));
            game.MakeStep(new ChessPosition('e', 7), new ChessPosition('e', 6));
            game.MakeStep(new ChessPosition('h', 2), new ChessPosition('h', 3));
            game.MakeStep(new ChessPosition('f', 8), new ChessPosition('b', 4));
            Assert.Equal(GameState.WHITE_UNDER_CHECK, game.GameState);
            game.MakeStep(new ChessPosition('c', 1), new ChessPosition('d', 2));
            Assert.Equal(GameState.ACTIVE_GAME, game.GameState);
        }
    }
}
