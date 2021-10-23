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
            _gameBoard.OnChessRemoved += (chess) => EndGame(chess);
            InitializePlayers();
        }

        public void EndGame(ChessBase chess)
        {
            if (chess is King king)
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

            if (chess.ChessColor == ChessColor.Black)
            {
                _blackPlayer.RemoveChess(chess);
            }
            else
            {
                _whitePlayer.RemoveChess(chess);
            }
        }

        public void MakeStep(ChessPosition fromPositionChess, ChessPosition toPosition)
        {
            _currentTurnPlayer.TakeChessFigure(fromPositionChess);
            _gameLogger.Log($"{_currentTurnPlayer} move {_currentTurnPlayer.TakenChess} from {fromPositionChess} to {toPosition}");
            _currentTurnPlayer.MoveChess(toPosition, _gameBoard);

            if (_gameState != GameState.WHITE_WIN && _gameState != GameState.BLACK_WIN)
            {
                var possibleSteps = _gameBoard.BoardCells[toPosition.Horizontal - 1, toPosition.Vertical - 1].Chess.GetPossibleSteps(_gameBoard);
                foreach (var step in possibleSteps)
                {
                    if (_gameBoard.BoardCells[step.Horizontal - 1, step.Vertical - 1].Chess is King king)
                    {
                        _gameState = king.ChessColor == ChessColor.White ? GameState.WHITE_UNDER_CHECK : GameState.BLACK_UNDER_CHECK;
                        break;
                    }
                    else
                    {
                        _gameState = GameState.ACTIVE_GAME;
                    }
                }
            }
            
            _currentTurnPlayer = _currentTurnPlayer == _whitePlayer ? _blackPlayer : _whitePlayer;
        }

        /// <summary>
        /// Initialize players by chess figures depends on figures colors
        /// </summary>
        private void InitializePlayers()
        {
            PlayerConfiguration playerConfig = new PlayerConfiguration(_gameBoard);
            _whitePlayer = new HumanPlayer("Vasya", ChessColor.White, playerConfig);
            _blackPlayer = new HumanPlayer("Petya", ChessColor.Black, playerConfig);
            _currentTurnPlayer = _whitePlayer;
        }
    }
}
