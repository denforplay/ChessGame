using ChessLib.Models;
using Xunit;
using System;
using ChessLib.Models.Game;

namespace ChessTests.ModelsTests.ChessModelsTests
{
    public class QueenTests
    {
        [Fact]
        public void QueenMovement_TestUpMovementAttach_ReturnsTrue()
        {
            string expected = "White Queen X: 4, Y: 7";
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('d', 2), new ChessPosition('d', 4));
            game.MakeStep(new ChessPosition('c', 7), new ChessPosition('c', 5));
            game.MakeStep(new ChessPosition('d', 4), new ChessPosition('c', 5));
            game.MakeStep(new ChessPosition('h', 7), new ChessPosition('h', 5));
            game.MakeStep(new ChessPosition('d', 1), new ChessPosition('d', 7));
            string actual = game.GameBoard.BoardCells[3, 6].Chess.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenMovement_TestRightUpDiagonalMovement_ReturnsTrue()
        {
            string expected = "White Queen X: 8, Y: 5";
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('e', 2), new ChessPosition('e', 3));
            game.MakeStep(new ChessPosition('h', 7), new ChessPosition('h', 5));
            game.MakeStep(new ChessPosition('d', 1), new ChessPosition('h', 5));
            string actual = game.GameBoard.BoardCells[7, 4].Chess.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenMovement_TestLeftUpDiagonalMovement_ReturnsTrue()
        {
            string expected = "White Queen X: 1, Y: 4";
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('c', 2), new ChessPosition('c', 3));
            game.MakeStep(new ChessPosition('h', 7), new ChessPosition('h', 5));
            game.MakeStep(new ChessPosition('d', 1), new ChessPosition('a', 4));
            string actual = game.GameBoard.BoardCells[0, 3].Chess.ToString();
            Assert.Equal(expected, actual);
        }
    }
}
