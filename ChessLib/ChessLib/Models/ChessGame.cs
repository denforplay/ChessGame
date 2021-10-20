using ChessLib.Models.Enums;
using ChessLib.Models.Figures;
using ChessLib.Models.Loggers;
using ChessLib.Models.Players;

namespace ChessLib.Models
{
    public class ChessGame
    {
        private GameBoard _gameBoard;
        private ChessPlayer _whitePlayer;
        private ChessPlayer _blackPlayer;
        private ChessPlayer _currentTurnPlayer;
        private GameState _gameState;
        private ILogger _gameLogger = new TxtLogger();

        public ChessGame()
        {
            _gameState = GameState.ACTIVE_GAME;
            _gameBoard = new GameBoard();
            _gameBoard.OnKingRemoved += (king) => EndGame(king);
            InitializePlayers();
        }

        public void EndGame(King king)
        {
            if (king.ChessColor == ChessColor.White)
            {
                _gameState = GameState.BLACK_WIN;
            }
            else
            {
                _gameState = GameState.WHITE_WIN;
            }
        }

        public void MakeStep(ChessPosition fromPositionChess, ChessPosition toPosition)
        {
            _currentTurnPlayer.TakeChessFigure(fromPositionChess);
            _gameLogger.Log($"{_currentTurnPlayer} move {_currentTurnPlayer.TakenChess} from {fromPositionChess} to {toPosition}");
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
