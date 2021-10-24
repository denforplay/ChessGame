using ChessLib.Models.Configurations;
using ChessLib.Models.Enums;
using ChessLib.Models.Figures;
using ChessLib.Models.Loggers;
using ChessLib.Models.Players;
using System;
using System.Collections.Generic;

namespace ChessLib.Models.Game
{
    /// <summary>
    /// Represents chess game
    /// </summary>
    public sealed class ChessGame
    {
        private GameBoard _gameBoard;
        private HumanPlayer _whitePlayer;
        private HumanPlayer _blackPlayer;
        private HumanPlayer _currentTurnPlayer;
        private GameState _gameState;
        private ILogger _gameLogger = new TxtLogger();
        private ChessBase _lastRemovedChess;

        /// <summary>
        /// Returns current game state
        /// </summary>
        public GameState GameState => _gameState;

        /// <summary>
        /// Returns current game board
        /// </summary>
        public GameBoard GameBoard => _gameBoard;

        /// <summary>
        /// Chess game constructor
        /// </summary>
        /// <param name="player1">First chess player</param>
        /// <param name="player2">Second chess player</param>
        /// <param name="gameBoard">Game board</param>
        public ChessGame(HumanPlayer player1, HumanPlayer player2, GameBoard gameBoard)
        {
            _gameState = GameState.ACTIVE_GAME;
            _gameBoard = gameBoard;
            InitializePlayers(player1, player2);
            _gameBoard.OnChessRemoved += (ChessBase chess) =>
            {
                _lastRemovedChess = chess;
                RemovePlayerChess(chess);
            };
            _gameLogger.Log($"Game started beyong {player1} and {player2}");
        }

        /// <summary>
        /// Makes step and checks if player is under mate.
        /// </summary>
        /// <param name="fromPositionChess">Takes chess from this position</param>
        /// <param name="toPosition">Move chess to this position</param>
        public void MakeStep(ChessPosition fromPositionChess, ChessPosition toPosition)
        {
            _currentTurnPlayer.TakeChessFigure(fromPositionChess);
            _gameLogger.Log($"{_currentTurnPlayer} move {_currentTurnPlayer.TakenChess} to {toPosition}");
            _currentTurnPlayer.MoveChess(toPosition, _gameBoard);
            if (IsKingUnderAttack(_currentTurnPlayer))
            {
                UnmakeStep(toPosition, fromPositionChess);
                return;
            }


            _currentTurnPlayer = _currentTurnPlayer == _whitePlayer ? _blackPlayer : _whitePlayer;

            if(IsPlayerUnderMate(_currentTurnPlayer))
            {
                if (_currentTurnPlayer.PlayerChessColor == ChessColor.Black)
                    _gameState = GameState.BLACK_UNDER_MATE;
                else
                    _gameState = GameState.WHITE_UNDER_MATE;
                return;
            }

            if (IsKingUnderAttack(_currentTurnPlayer))
            {
                if (_currentTurnPlayer.PlayerChessColor == ChessColor.Black)
                {
                    _gameState = GameState.BLACK_UNDER_CHECK;
                }
                else
                {
                    _gameState = GameState.WHITE_UNDER_CHECK;
                }
            }
            else
            {
                _gameState = GameState.ACTIVE_GAME;
            }
        }

        /// <summary>
        /// Undo last maked step from chess position to previous chess position
        /// </summary>
        /// <param name="fromPosition">From position</param>
        /// <param name="toPosition">To position</param>
        private void UnmakeStep(ChessPosition fromPosition, ChessPosition toPosition)
        {
            var chess = _gameBoard.BoardCells[fromPosition.Horizontal - 1, fromPosition.Vertical - 1].Chess;

            if (chess is Pawn pawn && pawn.StartPosition.Equals(toPosition))
            {
                pawn.SetFirstStep(true);
            }

            if (_lastRemovedChess is not null && _lastRemovedChess.CurrentPosition.Equals(fromPosition))
            {
                if (_lastRemovedChess.ChessColor == ChessColor.Black)
                    _blackPlayer.Chesses.Add(_lastRemovedChess);
                else
                    _whitePlayer.Chesses.Add(_lastRemovedChess);
                _gameBoard.BoardCells[fromPosition.Horizontal - 1, fromPosition.Vertical - 1].SetChess(_lastRemovedChess);
            }
            else
            {
                _gameBoard.BoardCells[fromPosition.Horizontal - 1, fromPosition.Vertical - 1].SetChess(new EmptyChess(chess.CurrentPosition, ChessColor.None));
            }
            chess.CurrentPosition = toPosition;
            _gameBoard.BoardCells[toPosition.Horizontal - 1, toPosition.Vertical - 1].SetChess(chess);

        }

        /// <summary>
        /// Remove chess from player
        /// </summary>
        /// <param name="chess">Chess to remove</param>
        private void RemovePlayerChess(ChessBase chess)
        {
            if (chess.ChessColor == ChessColor.White)
            {
                _whitePlayer.RemoveChess(chess);
            }
            else
            {
                _blackPlayer.RemoveChess(chess);
            }
        }

        /// <summary>
        /// Method checks if can chess move to other position without opening player chess
        /// </summary>
        /// <param name="player">Player</param>
        /// <param name="fromPositionChess">Chess position</param>
        /// <param name="toPosition">Position to move chess</param>
        /// <returns>True if chess can move without opening other returns false</returns>
        private bool CanChessMoveWithoutOpeningKing(HumanPlayer player, ChessPosition fromPositionChess, ChessPosition toPosition)
        {
            player.TakeChessFigure(fromPositionChess);
            player.MoveChess(toPosition, _gameBoard);
            if (IsKingUnderAttack(player))
            {
                UnmakeStep(toPosition, fromPositionChess);
                return false;
            }
            else
            {
                UnmakeStep(toPosition, fromPositionChess);
                return true;
            }
        }

        /// <summary>
        /// Method cheks if player king is under attack
        /// </summary>
        /// <param name="player">Player to check</param>
        /// <returns>Returns true if player king is under attack other returns false</returns>
        private bool IsKingUnderAttack(HumanPlayer player)
        {
            player = player == _whitePlayer ? _blackPlayer : _whitePlayer;
            foreach (var chess in player.Chesses)
            {
                foreach (var step in chess.GetPossibleSteps(_gameBoard))
                {
                    if (_gameBoard.BoardCells[step.Horizontal - 1, step.Vertical - 1].Chess is King king)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Method checks if player is under mate
        /// </summary>
        /// <param name="player">Player to check</param>
        /// <returns>True if plates is under mate other returns false</returns>
        private bool IsPlayerUnderMate(HumanPlayer player)
        {
            var chesses = new List<ChessBase>(player.Chesses);
            foreach (var chess in chesses)
            {
                foreach (var step in chess.GetPossibleSteps(_gameBoard))
                {
                    if (CanChessMoveWithoutOpeningKing(player, chess.CurrentPosition, step))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Initialize players
        /// </summary>
        private void InitializePlayers(HumanPlayer player1, HumanPlayer player2)
        {
            if (player1.PlayerChessColor == player2.PlayerChessColor)
            {
                throw new ArgumentException();
            }

            ChessesConfiguration playerConfig = new ChessesConfiguration(_gameBoard);
            if (player1.PlayerChessColor == ChessColor.White)
            {
                _whitePlayer = player1;
                _blackPlayer = player2;
            }
            else
            {
                _whitePlayer = player2;
                _blackPlayer = player1;
            }

            _currentTurnPlayer = _whitePlayer;
        }
    }
}
