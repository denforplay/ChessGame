using ChessLib.Models.Enums;
using System.Collections.Generic;

namespace ChessLib.Models.Figures
{
    public class Pawn : ChessBase
    {
        private bool _isFirstStep = true;

        public Pawn(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
        }

        public override List<ChessPosition> GetPossibleSteps(GameBoard gameBoard)
        {
            List<ChessPosition> nextSteps = new List<ChessPosition>();

            switch (ChessColor)
            {
                case ChessColor.White:
                    {
                        if (gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical].Chess is EmptyChess)
                            nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical + 1));

                        if (gameBoard.IsPositionOnBoard(CurrentPosition.Horizontal, CurrentPosition.Vertical) &&
                        gameBoard.BoardCells[CurrentPosition.Horizontal, CurrentPosition.Vertical].Chess is not EmptyChess)
                        {
                            nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal + 1, CurrentPosition.Vertical + 1));
                        }

                        if (gameBoard.IsPositionOnBoard(CurrentPosition.Horizontal - 2, CurrentPosition.Vertical) &&
                            gameBoard.BoardCells[CurrentPosition.Horizontal - 2, CurrentPosition.Vertical].Chess is not EmptyChess)
                        {
                            nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal - 1, CurrentPosition.Vertical + 1));
                        }

                        if (_isFirstStep && gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical + 1].Chess is EmptyChess)
                        {
                            nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical + 2));
                        }
                    }
                    break;
                case ChessColor.Black:
                    {
                        if (gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical - 2].Chess is EmptyChess)
                            nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical - 1));

                        if (gameBoard.IsPositionOnBoard(CurrentPosition.Horizontal, CurrentPosition.Vertical - 2) &&
                            gameBoard.BoardCells[CurrentPosition.Horizontal, CurrentPosition.Vertical - 2].Chess is not EmptyChess)
                        {
                            nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal + 1, CurrentPosition.Vertical - 1));
                        }

                        if (gameBoard.IsPositionOnBoard(CurrentPosition.Horizontal - 2, CurrentPosition.Vertical - 2) &&
                            gameBoard.BoardCells[CurrentPosition.Horizontal - 2, CurrentPosition.Vertical - 2].Chess is not EmptyChess)
                        {
                            nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal - 1, CurrentPosition.Vertical - 1));
                        }

                        if (_isFirstStep && gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical - 3].Chess is EmptyChess)
                        {
                            nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical - 2));
                        }

                    }
                    break;
            }

            return nextSteps;
        }

        public override void Move(ChessPosition nextPosition, GameBoard gameBoard)
        {
            if (GetPossibleSteps(gameBoard).Contains(nextPosition))
            {
                if (_isFirstStep)
                    _isFirstStep = false;

                gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical - 1].SetChess(new EmptyChess(CurrentPosition, ChessColor.None));

                if (gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].Chess is not EmptyChess)
                {
                    gameBoard.RemoveChess(gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1]);
                }

                gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].SetChess(this);
                CurrentPosition = nextPosition;
            }
        }
    }
}
