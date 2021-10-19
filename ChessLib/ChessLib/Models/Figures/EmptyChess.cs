using ChessLib.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Models.Figures
{
    public class EmptyChess : ChessBase
    {
        public EmptyChess(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
        }

        public override List<ChessPosition> GetPossibleSteps(GameBoard gameBoard)
        {
            return new List<ChessPosition>();
        }
    }
}
