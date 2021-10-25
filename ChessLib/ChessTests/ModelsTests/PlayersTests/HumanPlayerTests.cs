using ChessLib.Models;
using ChessLib.Models.Configurations;
using ChessLib.Models.Enums;
using ChessLib.Models.Players;
using System;
using Xunit;

namespace ChessTests.ModelsTests.PlayersTests
{
    public class HumanPlayerTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CreateHumanPlayer_NullOrEmptyName_ThrowsArgumentNullException(string name)
        {
            var playerConfiguration = new ChessesConfiguration(new GameBoard());
            Assert.Throws<ArgumentNullException>(() => new HumanPlayer(name, ChessColor.White, playerConfiguration));
        }

        [Fact]
        public void CreateHumanPlayer_NullConfiguration_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new HumanPlayer("Vasya", ChessColor.White, null));
        }

        [Theory]
        [InlineData('a', 1, "White Castle X: 1, Y: 1")]
        [InlineData('a', 2, "White Pawn X: 1, Y: 2")]
        [InlineData('e', 1, "White King X: 5, Y: 1")]
        public void TakeFigureTests_WhitePlayer_ReturnsTrue(char horizontal, int vertical, string expected)
        {
            var playerConfiguration = new ChessesConfiguration(new GameBoard());
            var player = new HumanPlayer("Vasya", ChessColor.White, playerConfiguration);
            player.TakeChessFigure(new ChessPosition(horizontal, vertical));
            Assert.Equal(expected, player.TakenChess.ToString());
        }

        [Theory]
        [InlineData('a', 8, "Black Castle X: 1, Y: 8")]
        [InlineData('b', 7, "Black Pawn X: 2, Y: 7")]
        [InlineData('e', 8, "Black King X: 5, Y: 8")]
        public void TakeFigureTests_BlackPlayer_ReturnsTrue(char horizontal, int vertical, string expected)
        {
            var playerConfiguration = new ChessesConfiguration(new GameBoard());
            var player = new HumanPlayer("Vasya", ChessColor.Black, playerConfiguration);
            player.TakeChessFigure(new ChessPosition(horizontal, vertical));
            Assert.Equal(expected, player.TakenChess.ToString());
        }

        [Theory]
        [InlineData('a', 2, 'a', 3, "White Pawn X: 1, Y: 3")]
        public void MoveFigureTests_ReturnsTrue(char horizontal, int vertical, char toHorizontal, int toVertical, string expected)
        {
            var playerConfig = new ChessesConfiguration(new GameBoard());
            var gameBoard = new GameBoard();
            var player = new HumanPlayer("Vasya", ChessColor.White, playerConfig);
            player.TakeChessFigure(new ChessPosition(horizontal, vertical));
            player.MoveChess(new ChessPosition(toHorizontal, toVertical), gameBoard);
            var chessPosition = new ChessPosition(toHorizontal, toVertical);
            Assert.Equal(expected, gameBoard.BoardCells[chessPosition.Horizontal - 1, chessPosition.Vertical - 1].Chess.ToString());
        }
    }
}
