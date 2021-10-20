using ChessLib.Models.Enums;
using ChessLib.Models.Figures;
using System;
using System.Collections.Generic;

namespace ChessLib.Models.Players
{
    /// <summary>
    /// Represents chess player
    /// </summary>
    public class ChessPlayer
    {
        private readonly List<ChessBase> _chesses;
        private ChessColor _playerChessColor;
        private ChessBase _takenChess;

        public List<ChessBase> Chesses => _chesses;
        public ChessBase TakenChess => _takenChess;

        /// <summary>
        /// Chess player constructor
        /// </summary>
        /// <param name="chessColor">Chess color of chess player</param>
        public ChessPlayer(ChessColor chessColor)
        {
            _chesses = new List<ChessBase>();
            _playerChessColor = chessColor;
        }

        /// <summary>
        /// Take chess figure from chosen position
        /// </summary>
        /// <param name="chessPosition">Chess position</param>
        public void TakeChessFigure(ChessPosition chessPosition)
        {
            _takenChess = _chesses.Find(x => x.CurrentPosition.Equals(chessPosition));
        }

        /// <summary>
        /// If figure taken move to chosen position on gameboard
        /// </summary>
        /// <param name="moveTo">Position to move taken figure</param>
        /// <param name="gameBoard">Game board</param>
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

        public void RemoveChess(ChessBase chessToRemove)
        {
            _chesses.Remove(chessToRemove);
        }

        /// <summary>
        /// Initialize player (give base figures list)
        /// </summary>
        /// <param name="gameBoard">Game board</param>

        public void Initialize(GameBoard gameBoard)
        {
            switch (_playerChessColor)
            {
                case ChessColor.White:
                    {
                        for (int i = 0; i < gameBoard.BOARD_SIZE; i++)
                        {
                            ChessBase chess = new Pawn(gameBoard.BoardCells[i, 1].ChessPosition, _playerChessColor);
                            AddChess(chess, ref gameBoard.BoardCells[i, 1]);
                        }

                        ChessBase castle1 = new Castle(gameBoard.BoardCells[0, 0].ChessPosition, _playerChessColor);
                        _chesses.Add(castle1);
                        gameBoard.BoardCells[0, 0].SetChess(castle1);
                        ChessBase castle2 = new Castle(gameBoard.BoardCells[gameBoard.BOARD_SIZE - 1, 0].ChessPosition, _playerChessColor);
                        _chesses.Add(castle2);
                        gameBoard.BoardCells[gameBoard.BOARD_SIZE - 1, 0].SetChess(castle2);
                       
                        ChessBase knight1 = new Knight(gameBoard.BoardCells[1, 0].ChessPosition, _playerChessColor);
                        _chesses.Add(knight1);
                        gameBoard.BoardCells[1, 0].SetChess(knight1);
                        ChessBase knight2 = new Knight(gameBoard.BoardCells[6, 0].ChessPosition, _playerChessColor);
                        _chesses.Add(knight2);
                        gameBoard.BoardCells[6, 0].SetChess(knight2);
                        ChessBase bishop1 = new Bishop(gameBoard.BoardCells[2, 0].ChessPosition, _playerChessColor);
                        _chesses.Add(bishop1);
                        gameBoard.BoardCells[2, 0].SetChess(bishop1);
                        ChessBase bishop2 = new Bishop(gameBoard.BoardCells[5, 0].ChessPosition, _playerChessColor);
                        _chesses.Add(bishop2);
                        gameBoard.BoardCells[5, 0].SetChess(bishop2);
                        ChessBase queen = new Queen(gameBoard.BoardCells[3, 0].ChessPosition, _playerChessColor);
                        _chesses.Add(queen);
                        gameBoard.BoardCells[3, 0].SetChess(queen);
                        ChessBase king = new King(gameBoard.BoardCells[4, 0].ChessPosition, _playerChessColor);
                        _chesses.Add(king);
                        gameBoard.BoardCells[4, 0].SetChess(king);
                    }
                    break;
                case ChessColor.Black:
                    {
                        for (int i = 0; i < gameBoard.BOARD_SIZE; i++)
                        {
                            ChessBase pawn = new Pawn(gameBoard.BoardCells[i, 6].ChessPosition, _playerChessColor);
                            AddChess(pawn, ref gameBoard.BoardCells[i, 6]);
                        }

                        ChessBase castle1 = new Castle(gameBoard.BoardCells[0, 7].ChessPosition, _playerChessColor);
                        _chesses.Add(castle1);
                        gameBoard.BoardCells[0, 7].SetChess(castle1);
                        ChessBase castle2 = new Castle(gameBoard.BoardCells[gameBoard.BOARD_SIZE - 1, gameBoard.BOARD_SIZE - 1].ChessPosition, _playerChessColor);
                        _chesses.Add(castle2);
                        gameBoard.BoardCells[gameBoard.BOARD_SIZE - 1, gameBoard.BOARD_SIZE - 1].SetChess(castle2);
                       
                        ChessBase knight1 = new Knight(gameBoard.BoardCells[1, 7].ChessPosition, _playerChessColor);
                        _chesses.Add(knight1);
                        gameBoard.BoardCells[1, 7].SetChess(knight1);
                        ChessBase knight2 = new Knight(gameBoard.BoardCells[6, 7].ChessPosition, _playerChessColor);
                        _chesses.Add(knight2);
                        gameBoard.BoardCells[6, 7].SetChess(knight2);

                        ChessBase bishop1 = new Bishop(gameBoard.BoardCells[2, 7].ChessPosition, _playerChessColor);
                        _chesses.Add(bishop1);
                        gameBoard.BoardCells[2, 7].SetChess(bishop1);
                        ChessBase bishop2 = new Bishop(gameBoard.BoardCells[5, 7].ChessPosition, _playerChessColor);
                        _chesses.Add(bishop2);
                        gameBoard.BoardCells[5, 7].SetChess(bishop2);

                        ChessBase queen = new Queen(gameBoard.BoardCells[3, 7].ChessPosition, _playerChessColor);
                        _chesses.Add(queen);
                        gameBoard.BoardCells[3, 7].SetChess(queen);
                        ChessBase king = new King(gameBoard.BoardCells[4, 7].ChessPosition, _playerChessColor);
                        _chesses.Add(king);
                        gameBoard.BoardCells[4, 7].SetChess(king);
                    }
                    break;
            }
        }

        private void AddChess(ChessBase chess, ref BoardCell boardCell)
        {
            boardCell.SetChess(chess);
            _chesses.Add(chess);
        }

        /// <summary>
        /// Returns a string that represents chess player.
        /// </summary>
        /// <returns>A string that represents chess player</returns>
        public override string ToString()
        {
            return $"Player with {_playerChessColor} color";
        }
    }
}
