using ChessLib.Models.Figures;
using System.Collections.Generic;

namespace ChessLib.Models
{
    public class Player
    {
        private List<ChessBase> _chesses;
        private ChessColor _playerChessColor;

        public Player(ChessColor chessColor)
        {
            _chesses = new List<ChessBase>();
            _playerChessColor = chessColor;
        }

        public ChessBase TakeChessFigure(ChessPosition chessPosition)
        {
            ChessBase chess = _chesses.Find(x => x.CurrentPosition.Equals(chessPosition));
            return chess;
        }

        public void Initialize(GameBoard gameBoard)
        {
            switch (_playerChessColor)
            {
                case ChessColor.White:
                    {
                        for (int i = 0; i < gameBoard.BOARD_SIZE; i++)
                        {
                            ChessBase chess = new Pawn(gameBoard.BoardCells[i, 1].ChessPosition, _playerChessColor);
                            gameBoard.BoardCells[i, 1].SetChess(chess);
                            _chesses.Add(chess);
                        }
                    }
                    break;
                case ChessColor.Black:
                    {
                        for (int i = 0; i < gameBoard.BOARD_SIZE; i++)
                        {
                            ChessBase chess = new Pawn(gameBoard.BoardCells[i, 6].ChessPosition, _playerChessColor);
                            gameBoard.BoardCells[i, 6].SetChess(chess);
                            _chesses.Add(chess);
                        }
                    }
                    break;
            }
        }
    }
}
