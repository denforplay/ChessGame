using ChessLib.Models;
using Xunit;
using System;

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
        public void QueenMovement_TestDownMovement_ReturnsTrue()
        {
            string expected = "White Queen X: 4, Y: 3";
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('d', 2), new ChessPosition('d', 4));
            game.MakeStep(new ChessPosition('c', 7), new ChessPosition('c', 5));
            game.MakeStep(new ChessPosition('d', 4), new ChessPosition('c', 5));
            game.MakeStep(new ChessPosition('h', 7), new ChessPosition('h', 5));
            game.MakeStep(new ChessPosition('d', 1), new ChessPosition('d', 7));
            game.MakeStep(new ChessPosition('h', 5), new ChessPosition('h', 4));
            game.MakeStep(new ChessPosition('d', 7), new ChessPosition('d', 3));
            string actual = game.GameBoard.BoardCells[3, 2].Chess.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenMovement_TestRightUpDiagonalMovement_ReturnsTrue()
        {
            string expected = "White Queen X: 7, Y: 6";
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('d', 2), new ChessPosition('d', 4));
            game.MakeStep(new ChessPosition('c', 7), new ChessPosition('c', 5));
            game.MakeStep(new ChessPosition('d', 4), new ChessPosition('c', 5));
            game.MakeStep(new ChessPosition('h', 7), new ChessPosition('h', 5));
            game.MakeStep(new ChessPosition('d', 1), new ChessPosition('d', 7));
            game.MakeStep(new ChessPosition('h', 5), new ChessPosition('h', 4));
            game.MakeStep(new ChessPosition('d', 7), new ChessPosition('d', 3));
            game.MakeStep(new ChessPosition('h', 4), new ChessPosition('h', 3));
            game.MakeStep(new ChessPosition('d', 3), new ChessPosition('g', 6));
            string actual = game.GameBoard.BoardCells[6, 5].Chess.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueenMovement_TestLeftUpDiagonalMovement_ReturnsTrue()
        {
            string expected = "White Queen X: 1, Y: 6";
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('d', 2), new ChessPosition('d', 4));
            game.MakeStep(new ChessPosition('c', 7), new ChessPosition('c', 5));
            game.MakeStep(new ChessPosition('d', 4), new ChessPosition('c', 5));
            game.MakeStep(new ChessPosition('h', 7), new ChessPosition('h', 5));
            game.MakeStep(new ChessPosition('d', 1), new ChessPosition('d', 7));
            game.MakeStep(new ChessPosition('h', 5), new ChessPosition('h', 4));
            game.MakeStep(new ChessPosition('d', 7), new ChessPosition('d', 3));
            game.MakeStep(new ChessPosition('h', 4), new ChessPosition('h', 3));
            game.MakeStep(new ChessPosition('d', 3), new ChessPosition('a', 6));
            string actual = game.GameBoard.BoardCells[0, 5].Chess.ToString();
            Assert.Equal(expected, actual);
        }
    }
}
