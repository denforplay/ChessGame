using ChessLib.Models;
using ChessLib.Models.Game;
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
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('b', 1), new ChessPosition('c', 3));
            string actual = game.GameBoard.BoardCells[2, 2].Chess.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void KnightMovement_TestLeftUpMove()
        {
            string expected = "White Knight X: 1, Y: 3";
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('b', 1), new ChessPosition('a', 3));
            string actual = game.GameBoard.BoardCells[0, 2].Chess.ToString();
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void KnightMovement_TestInvalidMove_ThrowsArgumentException()
        {
            ChessGame game = new ChessGame();
            Assert.Throws<ArgumentException>(() => game.MakeStep(new ChessPosition('b', 1), new ChessPosition('c', 2)));
        }
    }
}
