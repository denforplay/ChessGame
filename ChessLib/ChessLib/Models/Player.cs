using ChessLib.Models.Figures;
using System;
using System.Collections.Generic;

namespace ChessLib.Models
{
    public class Player
    {
        private List<ChessBase> _chesses;
        private ChessColor _playerChessColor;
        private ChessBase _takenChess;

        public Player(ChessColor chessColor)
        {
            _chesses = new List<ChessBase>();
            _playerChessColor = chessColor;
        }

        public void TakeChessFigure(ChessPosition chessPosition)
        {
            _takenChess = _chesses.Find(x => x.CurrentPosition.Equals(chessPosition));
        }

        public void MoveChess(ChessPosition moveTo, GameBoard gameBoard)
        {
            if (_takenChess is not null)
            {
                _takenChess.Move(moveTo, gameBoard);
                _takenChess = null;
            }
            else
            {
                throw new ArgumentNullException(nameof(_takenChess), "Player hasnt taken chess");
            }

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

                        ChessBase castle1 = new Castle(gameBoard.BoardCells[0, 0].ChessPosition, _playerChessColor);
                        ChessBase castle2 = new Castle(gameBoard.BoardCells[gameBoard.BOARD_SIZE - 1, 0].ChessPosition, _playerChessColor);
                        _chesses.Add(castle1);
                        _chesses.Add(castle2);
                        gameBoard.BoardCells[0, 0].SetChess(castle1);
                        gameBoard.BoardCells[gameBoard.BOARD_SIZE - 1, 0].SetChess(castle2);
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

                        ChessBase castle1 = new Castle(gameBoard.BoardCells[0, 7].ChessPosition, _playerChessColor);
                        ChessBase castle2 = new Castle(gameBoard.BoardCells[gameBoard.BOARD_SIZE - 1, gameBoard.BOARD_SIZE - 1].ChessPosition, _playerChessColor);
                        _chesses.Add(castle1);
                        _chesses.Add(castle2);
                        gameBoard.BoardCells[0, 7].SetChess(castle1);
                        gameBoard.BoardCells[gameBoard.BOARD_SIZE - 1, gameBoard.BOARD_SIZE - 1].SetChess(castle2);
                    }
                    break;
            }
        }
    }
}
