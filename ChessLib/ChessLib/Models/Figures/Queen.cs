using ChessLib.Models.Enums;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace ChessLib.Models.Figures
{
    public class Queen : ChessBase
    {
        public Queen(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
            _moveDirections = new Vector2<int>[]
            {
                 new Vector2<int>(-1, 1),
                 new Vector2<int>(1, 1),
                 new Vector2<int>(1, -1),
                 new Vector2<int>(-1, -1),
                 new Vector2<int>(0, 1),
                 new Vector2<int>(0, -1),
                 new Vector2<int>(1, 0),
                 new Vector2<int>(-1, 0)
            };
        }
    }
}