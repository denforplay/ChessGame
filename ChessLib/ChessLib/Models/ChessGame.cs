using ChessLib.Models.Configurations;
using ChessLib.Models.Enums;
using ChessLib.Models.Figures;
using ChessLib.Models.Loggers;
using ChessLib.Models.Players;

namespace ChessLib.Models
{
    public sealed class ChessGame
    {
        private GameBoard _gameBoard;
        private HumanPlayer _whitePlayer;
        private HumanPlayer _blackPlayer;
        private HumanPlayer _currentTurnPlayer;
        private GameState _gameState;
        private ILogger _gameLogger = new TxtLogger();

        public GameState GameState => _gameState;
        public GameBoard GameBoard => _gameBoard;

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
                _gameLogger.Log("Black win");
                _gameState = GameState.BLACK_WIN;
            }
            else
            {
                _gameLogger.Log("White win");
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
            PlayerConfiguration playerConfig = new PlayerConfiguration(_gameBoard);
            _whitePlayer = new HumanPlayer(ChessColor.White, playerConfig);
            _blackPlayer = new HumanPlayer(ChessColor.Black, playerConfig);
            _currentTurnPlayer = _whitePlayer;
        }
    }
}
