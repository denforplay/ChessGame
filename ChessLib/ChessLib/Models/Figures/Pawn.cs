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
                        if (gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical].Chess is null)
                            nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical + 1));

                        if (_isFirstStep && gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical + 1].Chess is null)
                        {
                             nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical + 2));
                        }
                    }
                    break;
                case ChessColor.Black:
                    {
                        if (gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical - 2].Chess is null)
                            nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical - 1));

                        if (_isFirstStep && gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical - 3].Chess is null)
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
                gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical - 1].SetChess(null);
                gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].SetChess(this);
                CurrentPosition = nextPosition;
            }
        }
    }
}
