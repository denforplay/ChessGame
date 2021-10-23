using System.Collections.Generic;

namespace ChessLib.Models.Figures.FigureMovements
{
    public interface IMovement
    {
        public List<ChessPosition> GetPossibleSteps(ChessBase chessToMove, Vector2<int>[] moveDirections, GameBoard gameBoard);
    }
}
