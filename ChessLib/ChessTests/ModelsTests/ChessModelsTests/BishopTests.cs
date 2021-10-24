using ChessLib.Models;
using ChessLib.Models.Configurations;
using ChessLib.Models.Enums;
using ChessLib.Models.Game;
using ChessLib.Models.Players;
using System;
using Xunit;

namespace ChessTests.ModelsTests.ChessModelsTests
{
    public class BishopTests
    {
        [Fact]
        public void BishopMovement_TestLeftUpperDiagonalMovement()
        {
            string expected = "White Bishop X: 1, Y: 3";
            GameBoard gameBoard = new GameBoard();
            ChessesConfiguration playerConfiguration = new ChessesConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('b', 2), new ChessPosition('b', 4));
            game.MakeStep(new ChessPosition('b', 7), new ChessPosition('b', 5));
            game.MakeStep(new ChessPosition('c', 1), new ChessPosition('a', 3));
            string actual = game.GameBoard.BoardCells[0, 2].Chess.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BishopMovement_TestRightUpperDiagonalMovement()
        {
            string expected = "White Bishop X: 7, Y: 5";
            GameBoard gameBoard = new GameBoard();
            ChessesConfiguration playerConfiguration = new ChessesConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('d', 2), new ChessPosition('d', 4));
            game.MakeStep(new ChessPosition('d', 7), new ChessPosition('d', 6));
            game.MakeStep(new ChessPosition('c', 1), new ChessPosition('g', 5));
            string actual = game.GameBoard.BoardCells[6, 4].Chess.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BishopMovement_TestRightDownDiagonalMovement()
        {
            string expected = "Black Bishop X: 8, Y: 6";
            GameBoard gameBoard = new GameBoard();
            ChessesConfiguration playerConfiguration = new ChessesConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('d', 2), new ChessPosition('d', 4));
            game.MakeStep(new ChessPosition('g', 7), new ChessPosition('g', 6));
            game.MakeStep(new ChessPosition('c', 1), new ChessPosition('g', 5));
            game.MakeStep(new ChessPosition('f', 8), new ChessPosition('h', 6));
            string actual = game.GameBoard.BoardCells[7, 5].Chess.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BishopMovement_TestLeftDownDiagonalMovement()
        {
            string expected = "Black Bishop X: 3, Y: 5";
            GameBoard gameBoard = new GameBoard();
            ChessesConfiguration playerConfiguration = new ChessesConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('d', 2), new ChessPosition('d', 4));
            game.MakeStep(new ChessPosition('e', 7), new ChessPosition('e', 6));
            game.MakeStep(new ChessPosition('c', 1), new ChessPosition('g', 5));
            game.MakeStep(new ChessPosition('f', 8), new ChessPosition('c', 5));
            string actual = game.GameBoard.BoardCells[2, 4].Chess.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BishopMovement_InvalidDirectionMovement_ThrowsArgumentException()
        {
            GameBoard gameBoard = new GameBoard();
            ChessesConfiguration playerConfiguration = new ChessesConfiguration(gameBoard);
            ChessGame game = new ChessGame(new HumanPlayer("Vasya", ChessColor.White, playerConfiguration),
                new HumanPlayer("Petya", ChessColor.Black, playerConfiguration), gameBoard);
            game.MakeStep(new ChessPosition('d', 2), new ChessPosition('d', 4));
            game.MakeStep(new ChessPosition('e', 7), new ChessPosition('e', 6));
            game.MakeStep(new ChessPosition('c', 1), new ChessPosition('g', 5));
            game.MakeStep(new ChessPosition('f', 8), new ChessPosition('c', 5));
            game.MakeStep(new ChessPosition('h', 2), new ChessPosition('h', 3));
            Assert.Throws<ArgumentException>(() => game.MakeStep(new ChessPosition('c', 5), new ChessPosition('a', 5)));
        }
    }
}
