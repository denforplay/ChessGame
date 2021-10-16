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
                        nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical + 1));

                        if (_isFirstStep)
                        {
                            nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical + 2));
                            _isFirstStep = false;
                        }
                    }
                    break;
                case ChessColor.Black:
                    {
                        nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical - 1));

                        if (_isFirstStep)
                        {
                            nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical - 2));
                            _isFirstStep = false;
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
                gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical - 1].SetChess(null);
                gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].SetChess(this);
            }
        }
    }
}
