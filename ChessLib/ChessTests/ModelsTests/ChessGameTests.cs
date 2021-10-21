using ChessLib.Models;
using ChessLib.Models.Enums;
using Xunit;

namespace ChessTests.ModelsTests
{
    public class ChessGameTests
    {

        [Fact]
        public void ChildGame()
        {
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('e', 2), new ChessPosition('e', 4));
            game.MakeStep(new ChessPosition('e', 7), new ChessPosition('e', 5));
            game.MakeStep(new ChessPosition('d', 1), new ChessPosition('h', 5));
            game.MakeStep(new ChessPosition('b', 8), new ChessPosition('c', 6));
            game.MakeStep(new ChessPosition('f', 1), new ChessPosition('c', 4));
            game.MakeStep(new ChessPosition('g', 8), new ChessPosition('f', 6));
            game.MakeStep(new ChessPosition('h', 5), new ChessPosition('f', 7));
            game.MakeStep(new ChessPosition('h', 7), new ChessPosition('h', 6));
            game.MakeStep(new ChessPosition('f', 7), new ChessPosition('e', 8));
            Assert.Equal(GameState.WHITE_WIN, game.GameState);
        }

        [Fact]
        public void Game_2()
        {
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition('a', 2), new ChessPosition('a', 3));
            game.MakeStep(new ChessPosition(8, 7), new ChessPosition(8, 6));
            game.MakeStep(new ChessPosition(5, 2), new ChessPosition(5, 4));
            game.MakeStep(new ChessPosition(8, 6), new ChessPosition(8, 5));
            game.MakeStep(new ChessPosition(5, 1), new ChessPosition(5, 2));
        }

        [Fact]
        public void Game_3()
        {
            ChessGame game = new ChessGame();
            game.MakeStep(new ChessPosition(2, 2), new ChessPosition(2, 3));
            game.MakeStep(new ChessPosition(8, 7), new ChessPosition(8, 6));
            game.MakeStep(new ChessPosition(3, 1), new ChessPosition(1, 3));
        }
    }
}
