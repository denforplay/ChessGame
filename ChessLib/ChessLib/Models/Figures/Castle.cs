using ChessLib.Models.Enums;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace ChessLib.Models.Figures
{
    public class Castle : ChessBase
    {
        public Castle(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
            _moveDirections = new Vector2<int>[]
            {
                 new Vector2<int>(0, 1),
                 new Vector2<int>(0, -1),
                 new Vector2<int>(1, 0),
                 new Vector2<int>(-1, 0)
            };
        }
    }
}