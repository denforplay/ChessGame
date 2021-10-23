using ChessLib.Models.Enums;
using ChessLib.Models.Figures.FigureMovements;
using System.Collections.Generic;
using System.Linq;

namespace ChessLib.Models.Figures
{
    /// <summary>
    /// Represents king figure
    /// </summary>
    public sealed class King : ChessBase
    {
        /// <summary>
        /// Copy constructor to create king from other king
        /// </summary>
        /// <param name="otherChess">King from which copy info</param>
        public King(King otherChess) : base(otherChess)
        {
            _movement = new AllDirectionMovement();
        }

        /// <summary>
        /// King constructor
        /// </summary>
        /// <param name="startPosition">Start position</param>
        /// <param name="color">Figure color</param>
        public King(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
            _movement = new AllDirectionMovement();
        }

        protected override void InitializeMoveDirections()
        {
            _moveDirections = new Vector2<int>[]
           {
                 new Vector2<int>(0, 1),
                 new Vector2<int>(1, 1),
                 new Vector2<int>(1, 0),
                 new Vector2<int>(1, -1),
                 new Vector2<int>(0, -1),
                 new Vector2<int>(-1, -1),
                 new Vector2<int>(-1, 0),
                 new Vector2<int>(-1, 1)
           };
        }
    }
}
