using ChessLib.Models;
using System;
using Xunit;

namespace ChessTests.ModelsTests.ChessModelsTests
{
    public class PawnTests
    {
        [Theory]
        [InlineData('a', 2, 'b', 3, "None EmptyChess X: 2, Y: 3")]
        [InlineData('a', 2, 'a', 3, "White Pawn X: 1, Y: 3")]
        [InlineData('a', 2, 'a', 4, "White Pawn X: 1, Y: 4")]
        public void PawnMovement_TestPossibilityMovements(char startX, int startY, char endX, int endY, string expected)
        {
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition(startX, startY), new ChessPosition(endX, endY));
            int x = Math.Abs('a' - endX);
            string actual = game.GameBoard.BoardCells[x, endY - 1].Chess.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PawnMovement_TestRightDiagonalAttackMovement_ReturnsTrue()
        {
            string expected = "White Pawn X: 3, Y: 5";
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('b', 2), new ChessPosition('b', 4));
            game.MakeStep(new ChessPosition('c', 7), new ChessPosition('c', 5));
            game.MakeStep(new ChessPosition('b', 4), new ChessPosition('c', 5));

            string actual = game.GameBoard.BoardCells[2, 4].Chess.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PawnMovement_TestLeftDiagonalAttackMovement_ReturnsTrue()
        {
            string expected = "White Pawn X: 1, Y: 5";
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('b', 2), new ChessPosition('b', 4));
            game.MakeStep(new ChessPosition('a', 7), new ChessPosition('a', 5));
            game.MakeStep(new ChessPosition('b', 4), new ChessPosition('a', 5));

            string actual = game.GameBoard.BoardCells[0, 4].Chess.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PawnReplaceByQueen_ReturnsTrue()
        {
            string expected = "White Queen X: 1, Y: 8";
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('b', 2), new ChessPosition('b', 4));
            game.MakeStep(new ChessPosition('a', 7), new ChessPosition('a', 5));
            game.MakeStep(new ChessPosition('b', 4), new ChessPosition('a', 5));
            game.MakeStep(new ChessPosition('a', 8), new ChessPosition('a', 6));
            game.MakeStep(new ChessPosition('h', 2), new ChessPosition('h', 3));
            game.MakeStep(new ChessPosition('a', 6), new ChessPosition('f', 6));
            game.MakeStep(new ChessPosition('a', 5), new ChessPosition('a', 6));
            game.MakeStep(new ChessPosition('h', 7), new ChessPosition('h', 6));
            game.MakeStep(new ChessPosition('a', 6), new ChessPosition('a', 7));
            game.MakeStep(new ChessPosition('h', 6), new ChessPosition('h', 5));
            game.MakeStep(new ChessPosition('a', 7), new ChessPosition('a', 8));
            string actual = game.GameBoard.BoardCells[0, 7].Chess.ToString();
            Assert.Equal(expected, actual);
        }
    }
}
