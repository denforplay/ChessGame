using System.Collections.Generic;

namespace ChessLib.Models.Figures.FigureMovements
{
    /// <summary>
    /// Represents class for finding all direction line possible steps for chess figure
    /// </summary>
    public sealed class AllDirectionLineStepFinder : IStepFinder
    {
        public List<ChessPosition> GetPossibleSteps(ChessBase chessToMove, Vector2<int>[] moveDirections, GameBoard gameBoard)
        {
            List<ChessPosition> nextSteps = new();

            for (int i = 0; i < moveDirections.Length; i++)
            {
                var nextPosition = new ChessPosition(chessToMove.CurrentPosition.Horizontal, chessToMove.CurrentPosition.Vertical);
                while (nextPosition.Vertical <= 8 && nextPosition.Vertical >= 1
&& nextPosition.Horizontal >= 1 && nextPosition.Horizontal <= 8)
                {
                    if (!gameBoard.IsPositionOnBoard(nextPosition.Horizontal + moveDirections[i].X - 1, nextPosition.Vertical + moveDirections[i].Y - 1))
                        break;
                    nextPosition.Horizontal += moveDirections[i].X;
                    nextPosition.Vertical += moveDirections[i].Y;

                    ChessBase chess = gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].Chess;

                    if (chess is EmptyChess)
                    {
                        nextSteps.Add(new ChessPosition(nextPosition.Horizontal, nextPosition.Vertical));
                    }
                    else if (chess.ChessColor != chessToMove.ChessColor)
                    {
                        nextSteps.Add(new ChessPosition(nextPosition.Horizontal, nextPosition.Vertical));
                        break;
                    }
                    else
                        break;
                }
            }

            return nextSteps;
        }
    }
}
