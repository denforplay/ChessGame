using System.Collections.Generic;

namespace ChessLib.Models.Figures.FigureMovements
{
    public sealed class AllDirectionStepFinder : IStepFinder
    {
        public List<ChessPosition> GetPossibleSteps(ChessBase chessToMove, Vector2<int>[] moveDirections, GameBoard gameBoard)
        {
            List<ChessPosition> nextSteps = new();

            for (int i = 0; i < moveDirections.Length; i++)
            {
                var nextPosition = new ChessPosition(chessToMove.CurrentPosition.Horizontal, chessToMove.CurrentPosition.Vertical);

                if (!gameBoard.IsPositionOnBoard(nextPosition.Horizontal + moveDirections[i].X - 1, nextPosition.Vertical + moveDirections[i].Y - 1))
                    continue;

                nextPosition.Horizontal += moveDirections[i].X;
                nextPosition.Vertical += moveDirections[i].Y;

                var chess = gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].Chess;

                if (chess is EmptyChess)
                    nextSteps.Add(new ChessPosition(nextPosition.Horizontal, nextPosition.Vertical));
                else if (chess.ChessColor != chessToMove.ChessColor)
                {
                    nextSteps.Add(new ChessPosition(nextPosition.Horizontal, nextPosition.Vertical));
                    continue;
                }
                else
                    continue;
            }

            return nextSteps;
        }
    }
}
