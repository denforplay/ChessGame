using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib.Models
{
    public class ChessGame
    {
        private GameBoard _gameBoard;
        private ChessPlayer _whitePlayer;
        private ChessPlayer _blackPlayer;
        private ChessPlayer _currentTurnPlayer;

        public ChessGame()
        {
            _gameBoard = new GameBoard();
            InitializePlayers();
        }

        public void MakeStep(ChessPosition fromPositionChess, ChessPosition toPosition)
        {
            _currentTurnPlayer.TakeChessFigure(fromPositionChess);
            _currentTurnPlayer.MoveChess(toPosition, _gameBoard);
            _currentTurnPlayer = _currentTurnPlayer == _whitePlayer ? _blackPlayer : _whitePlayer;
        }

        /// <summary>
        /// Initialize players by chess figures depends on figures colors
        /// </summary>
        private void InitializePlayers()
        {
            _whitePlayer = new ChessPlayer(ChessColor.White);
            _blackPlayer = new ChessPlayer(ChessColor.Black);
            _whitePlayer.Initialize(_gameBoard);
            _blackPlayer.Initialize(_gameBoard);
            _currentTurnPlayer = _whitePlayer;
        }
    }
}
