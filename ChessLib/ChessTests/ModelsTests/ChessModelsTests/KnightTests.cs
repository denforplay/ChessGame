using ChessLib.Models;
using ChessLib.Models.Configurations;
using ChessLib.Models.Enums;
using ChessLib.Models.Game;
using ChessLib.Models.Players;
using System;
using Xunit;

namespace ChessTests.ModelsTests.ChessModelsTests
{
    public class KnightTests
    {
        [Fact]
        public void KnightMovement_TestRightUpMove()
        {
            string expected = "White Knight X: 3, Y: 3";
            GameBoard gameBoard = new GameBoard();
            PlayerConfiguration playerConfiguration = new PlayerConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('b', 1), new ChessPosition('c', 3));
            string actual = game.GameBoard.BoardCells[2, 2].Chess.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KnightMovement_TestLeftUpMove()
        {
            string expected = "White Knight X: 1, Y: 3";
            GameBoard gameBoard = new GameBoard();
            PlayerConfiguration playerConfiguration = new PlayerConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('b', 1), new ChessPosition('a', 3));
            string actual = game.GameBoard.BoardCells[0, 2].Chess.ToString();
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void KnightMovement_TestInvalidMove_ThrowsArgumentException()
        {
            GameBoard gameBoard = new GameBoard();
            PlayerConfiguration playerConfiguration = new PlayerConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            Assert.Throws<ArgumentException>(() => game.MakeStep(new ChessPosition('b', 1), new ChessPosition('c', 2)));
        }
    }
}
