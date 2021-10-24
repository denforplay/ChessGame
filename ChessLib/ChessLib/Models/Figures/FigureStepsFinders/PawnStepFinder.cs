using System.Collections.Generic;

namespace ChessLib.Models.Figures.FigureMovements
{
    public sealed class PawnStepFinder : IStepFinder
    {
        /// <summary>
        /// Field that contains information about first step of pawn
        /// </summary>
        public bool IsFirstStep = true;

        public List<ChessPosition> GetPossibleSteps(ChessBase chessToMove, Vector2<int>[] moveDirections, GameBoard gameBoard)
        {
            List<ChessPosition> nextSteps = new();

            var currentPosition = chessToMove.CurrentPosition;

            if (gameBoard.IsPositionOnBoard(currentPosition.Horizontal - 1 + moveDirections[0].X, currentPosition.Vertical - 1 + moveDirections[0].Y) &&
                gameBoard.BoardCells[currentPosition.Horizontal - 1 + moveDirections[0].X, currentPosition.Vertical - 1 + moveDirections[0].Y].Chess is EmptyChess)
                nextSteps.Add(new ChessPosition(currentPosition.Horizontal + moveDirections[0].X, currentPosition.Vertical + moveDirections[0].Y));

            for (int i = 1; i <= 2; i++)
            {
                if (gameBoard.IsPositionOnBoard(currentPosition.Horizontal - 1 + moveDirections[i].X, currentPosition.Vertical - 1 + moveDirections[i].Y) &&
           gameBoard.BoardCells[currentPosition.Horizontal - 1 + moveDirections[i].X, currentPosition.Vertical - 1 + moveDirections[i].Y].Chess is not EmptyChess)
                    nextSteps.Add(new ChessPosition(currentPosition.Horizontal + moveDirections[i].X, currentPosition.Vertical + moveDirections[i].Y));
            }

            if (IsFirstStep && gameBoard.BoardCells[currentPosition.Horizontal - 1 + moveDirections[3].X, currentPosition.Vertical - 1 + moveDirections[3].Y].Chess is EmptyChess)
                nextSteps.Add(new ChessPosition(currentPosition.Horizontal + moveDirections[3].X, currentPosition.Vertical + moveDirections[3].Y));

            return nextSteps;
        }
    }
}
