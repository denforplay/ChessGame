using ChessLib.Models.Configurations;
using ChessLib.Models.Enums;
using ChessLib.Models.Figures;
using System;
using System.Collections.Generic;

namespace ChessLib.Models.Players
{
    /// <summary>
    /// Represents chess player
    /// </summary>
    public sealed class HumanPlayer
    {
        private string _playerName;
        private readonly List<ChessBase> _chesses;
        private ChessColor _playerChessColor;
        private ChessBase _takenChess;

        /// <summary>
        /// Getter returns player chess color
        /// </summary>
        public ChessColor PlayerChessColor => _playerChessColor;

        /// <summary>
        /// Getter returns list of player chesses
        /// </summary>
        public List<ChessBase> Chesses => _chesses;

        /// <summary>
        /// Getter returns player taken chess
        /// </summary>
        public ChessBase TakenChess => _takenChess;

        /// <summary>
        /// Chess player constructor
        /// </summary>
        /// <param name="chessColor">Chess color of chess player</param>
        public HumanPlayer(string playerName, ChessColor chessColor, PlayerConfiguration playerConfig)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                throw new ArgumentNullException(nameof(playerName));
            }

            _playerName = playerName;
            _chesses = playerConfig.ChessSet[chessColor];
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
            if (_takenChess is not EmptyChess)
            {
                _takenChess.Move(moveTo, gameBoard);
                if (_takenChess is Pawn pawn && _takenChess.CurrentPosition.Vertical == gameBoard.BOARD_SIZE)
                {
                    var boardCell = gameBoard.BoardCells[_takenChess.CurrentPosition.Horizontal - 1, _takenChess.CurrentPosition.Vertical - 1];
                    gameBoard.BoardCells[_takenChess.CurrentPosition.Horizontal - 1, _takenChess.CurrentPosition.Vertical - 1].SetChess(new Queen(pawn));
                    Chesses.Remove(pawn);
                    Chesses.Add(boardCell.Chess);
                }
                else
                {
                    _takenChess = new EmptyChess(_takenChess.CurrentPosition, _takenChess.ChessColor);
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(_takenChess), "Player hasnt taken chess");
            }
        }

        /// <summary>
        /// Remove player chess
        /// </summary>
        /// <param name="chessToRemove">Chess to remove</param>
        public void RemoveChess(ChessBase chessToRemove)
        {
            _chesses.Remove(chessToRemove);
        }

        /// <summary>
        /// Returns a string that represents chess player.
        /// </summary>
        /// <returns>A string that represents chess player</returns>
        public override string ToString()
        {
            return $"Player {_playerName}";
        }

        /// <summary>
        /// Check if this player equals to other object
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if players are equals, other return false</returns>
        public override bool Equals(object obj)
        {
            if (obj is HumanPlayer otherPlayer)
            {
                return _playerChessColor == otherPlayer.PlayerChessColor;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach(var chess in Chesses)
            {
                hash += chess.GetHashCode();
            }

            return hash;
        }
    }
}
