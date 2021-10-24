using System.Collections.Generic;

namespace ChessLib.Models.Figures.FigureMovements
{
    /// <summary>
    /// Represents interface which provides functionality to find possible steps for chess figure
    /// </summary>
    public interface IStepFinder
    {
        /// <summary>
        /// Returns possible steps for chess figure
        /// </summary>
        /// <param name="chessToMove">Chess for which find possible steps</param>
        /// <param name="moveDirections">Chess move directions</param>
        /// <param name="gameBoard">Game board</param>
        /// <returns>List of possible steps which figure can do</returns>
        public List<ChessPosition> GetPossibleSteps(ChessBase chessToMove, Vector2<int>[] moveDirections, GameBoard gameBoard);
    }
}
