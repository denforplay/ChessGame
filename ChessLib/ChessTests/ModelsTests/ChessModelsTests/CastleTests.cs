using ChessLib.Models;
using ChessLib.Models.Configurations;
using ChessLib.Models.Enums;
using ChessLib.Models.Game;
using ChessLib.Models.Players;
using System;
using Xunit;

namespace ChessTests.ModelsTests.ChessModelsTests
{
    public class CastleTests
    {
        [Fact]
        public void CastleMovement_TestHorizontalMovementWithAttack()
        {
            string expected = "White Castle X: 1, Y: 4";
            GameBoard gameBoard = new GameBoard();
            PlayerConfiguration playerConfiguration = new PlayerConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('a', 2), new ChessPosition('a', 4));
            game.MakeStep(new ChessPosition('b', 7), new ChessPosition('b', 5));
            game.MakeStep(new ChessPosition('a', 1), new ChessPosition('a', 2));
            game.MakeStep(new ChessPosition('b', 5), new ChessPosition('a', 4));
            game.MakeStep(new ChessPosition('a', 2), new ChessPosition('a', 4));
            string actual = game.GameBoard.BoardCells[0, 3].Chess.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CastleMovement_TestVerticalMovementWithAttack()
        {
            string expected = "White Castle X: 2, Y: 4";
            GameBoard gameBoard = new GameBoard();
            PlayerConfiguration playerConfiguration = new PlayerConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('a', 2), new ChessPosition('a', 4));
            game.MakeStep(new ChessPosition('b', 7), new ChessPosition('b', 5));
            game.MakeStep(new ChessPosition('a', 4), new ChessPosition('a', 5));
            game.MakeStep(new ChessPosition('b', 5), new ChessPosition('b', 4));
            game.MakeStep(new ChessPosition('a', 1), new ChessPosition('a', 4));
            game.MakeStep(new ChessPosition('h', 7), new ChessPosition('h', 6));
            game.MakeStep(new ChessPosition('a', 4), new ChessPosition('b', 4));
            string actual = game.GameBoard.BoardCells[1, 3].Chess.ToString();
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void CastleMovement_InvalidMovement_ThrowsArgumentException()
        {
            GameBoard gameBoard = new GameBoard();
            PlayerConfiguration playerConfiguration = new PlayerConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('a', 2), new ChessPosition('a', 4));
            game.MakeStep(new ChessPosition('b', 7), new ChessPosition('b', 5));
            game.MakeStep(new ChessPosition('a', 4), new ChessPosition('a', 5));
            game.MakeStep(new ChessPosition('b', 5), new ChessPosition('b', 4));
            game.MakeStep(new ChessPosition('a', 1), new ChessPosition('a', 4));
            game.MakeStep(new ChessPosition('h', 7), new ChessPosition('h', 6));
            Assert.Throws<ArgumentException>(() => game.MakeStep(new ChessPosition('a', 4), new ChessPosition('c', 6)));
        }
    }
}
