using ChessLib.Models.Enums;
using ChessLib.Models.Figures;
using System.Collections.Generic;

namespace ChessLib.Models.Configurations
{
    public sealed class PlayerConfiguration
    {
        private GameBoard _gameBoard;
        private Dictionary<ChessColor, List<ChessBase>> _chessSets = new Dictionary<ChessColor, List<ChessBase>>();
        public Dictionary<ChessColor, List<ChessBase>> ChessSet => _chessSets;
        public PlayerConfiguration(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
            _chessSets[ChessColor.White] = new List<ChessBase>();
            _chessSets[ChessColor.Black] = new List<ChessBase>();
            ConfigureWhiteChesses();
            ConfigureBlackChesses();
        }

        private void ConfigureWhiteChesses()
        {
            for (int i = 0; i < _gameBoard.BOARD_SIZE; i++)
            {
                ChessBase chess = new Pawn(_gameBoard.BoardCells[i, 1].ChessPosition, ChessColor.White);
                _gameBoard.BoardCells[i, 1].SetChess(chess);
                _chessSets[ChessColor.White].Add(chess);
            }

            ChessBase castle1 = new Castle(_gameBoard.BoardCells[0, 0].ChessPosition, ChessColor.White);
            _chessSets[ChessColor.White].Add(castle1);
            _gameBoard.BoardCells[0, 0].SetChess(castle1);
            ChessBase castle2 = new Castle(_gameBoard.BoardCells[_gameBoard.BOARD_SIZE - 1, 0].ChessPosition, ChessColor.White);
            _chessSets[ChessColor.White].Add(castle2);
            _gameBoard.BoardCells[_gameBoard.BOARD_SIZE - 1, 0].SetChess(castle2);

            ChessBase knight1 = new Knight(_gameBoard.BoardCells[1, 0].ChessPosition, ChessColor.White);
            _chessSets[ChessColor.White].Add(knight1);
            _gameBoard.BoardCells[1, 0].SetChess(knight1);
            ChessBase knight2 = new Knight(_gameBoard.BoardCells[6, 0].ChessPosition, ChessColor.White);
            _chessSets[ChessColor.White].Add(knight2);
            _gameBoard.BoardCells[6, 0].SetChess(knight2);
            ChessBase bishop1 = new Bishop(_gameBoard.BoardCells[2, 0].ChessPosition, ChessColor.White);
            _chessSets[ChessColor.White].Add(bishop1);
            _gameBoard.BoardCells[2, 0].SetChess(bishop1);
            ChessBase bishop2 = new Bishop(_gameBoard.BoardCells[5, 0].ChessPosition, ChessColor.White);
            _chessSets[ChessColor.White].Add(bishop2);
            _gameBoard.BoardCells[5, 0].SetChess(bishop2);
            ChessBase queen = new Queen(_gameBoard.BoardCells[3, 0].ChessPosition, ChessColor.White);
            _chessSets[ChessColor.White].Add(queen);
            _gameBoard.BoardCells[3, 0].SetChess(queen);
            ChessBase king = new King(_gameBoard.BoardCells[4, 0].ChessPosition, ChessColor.White);
            _chessSets[ChessColor.White].Add(king);
            _gameBoard.BoardCells[4, 0].SetChess(king);
        }

        private void ConfigureBlackChesses()
        {
            for (int i = 0; i < _gameBoard.BOARD_SIZE; i++)
            {
                ChessBase pawn = new Pawn(_gameBoard.BoardCells[i, 6].ChessPosition, ChessColor.Black);
                _chessSets[ChessColor.Black].Add(pawn);
                _gameBoard.BoardCells[0, 7].SetChess(pawn);
            }

            ChessBase castle1 = new Castle(_gameBoard.BoardCells[0, 7].ChessPosition, ChessColor.Black);
            _chessSets[ChessColor.Black].Add(castle1);
            _gameBoard.BoardCells[0, 7].SetChess(castle1);
            ChessBase castle2 = new Castle(_gameBoard.BoardCells[_gameBoard.BOARD_SIZE - 1, _gameBoard.BOARD_SIZE - 1].ChessPosition, ChessColor.Black);
            _chessSets[ChessColor.Black].Add(castle2);
            _gameBoard.BoardCells[_gameBoard.BOARD_SIZE - 1, _gameBoard.BOARD_SIZE - 1].SetChess(castle2);

            ChessBase knight1 = new Knight(_gameBoard.BoardCells[1, 7].ChessPosition, ChessColor.Black);
            _chessSets[ChessColor.Black].Add(knight1);
            _gameBoard.BoardCells[1, 7].SetChess(knight1);
            ChessBase knight2 = new Knight(_gameBoard.BoardCells[6, 7].ChessPosition, ChessColor.Black);
            _chessSets[ChessColor.Black].Add(knight2);
            _gameBoard.BoardCells[6, 7].SetChess(knight2);

            ChessBase bishop1 = new Bishop(_gameBoard.BoardCells[2, 7].ChessPosition, ChessColor.Black);
            _chessSets[ChessColor.Black].Add(bishop1);
            _gameBoard.BoardCells[2, 7].SetChess(bishop1);
            ChessBase bishop2 = new Bishop(_gameBoard.BoardCells[5, 7].ChessPosition, ChessColor.Black);
            _chessSets[ChessColor.Black].Add(bishop2);
            _gameBoard.BoardCells[5, 7].SetChess(bishop2);

            ChessBase queen = new Queen(_gameBoard.BoardCells[3, 7].ChessPosition, ChessColor.Black);
            _chessSets[ChessColor.Black].Add(queen);
            _gameBoard.BoardCells[3, 7].SetChess(queen);
            ChessBase king = new King(_gameBoard.BoardCells[4, 7].ChessPosition, ChessColor.Black);
            _chessSets[ChessColor.Black].Add(king);
            _gameBoard.BoardCells[4, 7].SetChess(king);
        }
    }
}
