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
        public void ChildGame()
        {
            GameBoard gameBoard = new GameBoard();
            PlayerConfiguration playerConfiguration = new PlayerConfiguration(gameBoard);
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
        public void ChessGame_TestBishopMovesUnderCheckState()
        {
            GameBoard gameBoard = new GameBoard();
            PlayerConfiguration playerConfiguration = new PlayerConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('d', 2), new ChessPosition('d', 3));
            game.MakeStep(new ChessPosition('e', 7), new ChessPosition('e', 6));
            game.MakeStep(new ChessPosition('h', 2), new ChessPosition('h', 3));
            game.MakeStep(new ChessPosition('f', 8), new ChessPosition('b', 4));
            game.MakeStep(new ChessPosition('c', 1), new ChessPosition('e', 3));
        }

        [Fact]
        public void Game_2()
        {
            GameBoard gameBoard = new GameBoard();
            PlayerConfiguration playerConfiguration = new PlayerConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('a', 2), new ChessPosition('a', 3));
            game.MakeStep(new ChessPosition(8, 7), new ChessPosition(8, 6));
            game.MakeStep(new ChessPosition(5, 2), new ChessPosition(5, 4));
            game.MakeStep(new ChessPosition(8, 6), new ChessPosition(8, 5));
            game.MakeStep(new ChessPosition(5, 1), new ChessPosition(5, 2));
        }

        [Fact]
        public void Game_3()
        {
            GameBoard gameBoard = new GameBoard();
            PlayerConfiguration playerConfiguration = new PlayerConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition(2, 2), new ChessPosition(2, 3));
            game.MakeStep(new ChessPosition(8, 7), new ChessPosition(8, 6));
            game.MakeStep(new ChessPosition(3, 1), new ChessPosition(1, 3));
        }
    }
}
