using ChessLib.Models.Enums;
using ChessLib.Models.Figures;
using System.Collections.Generic;

namespace ChessLib.Models.Configurations
{
    public sealed class PlayerConfiguration
    {
        private const int BLACK_PAWN_VERTICAL = 6;
        private const int BLACK_BACK_ROW = 7;
        private const int WHITE_PAWN_VERTICAL = 1;
        private const int WHITE_BACK_ROW = 0;
        private GameBoard _gameBoard;
        private Dictionary<ChessColor, List<ChessBase>> _chessSets = new Dictionary<ChessColor, List<ChessBase>>();
        public Dictionary<ChessColor, List<ChessBase>> ChessSet => _chessSets;
        public PlayerConfiguration(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
            _chessSets[ChessColor.White] = new List<ChessBase>();
            _chessSets[ChessColor.Black] = new List<ChessBase>();
            ConfigureChesses(ChessColor.White);
            ConfigureChesses(ChessColor.Black);
        }

        private void ConfigureChesses(ChessColor chessColor)
        {
            int pawnVertical = chessColor == ChessColor.Black ? BLACK_PAWN_VERTICAL : WHITE_PAWN_VERTICAL;
            int pawnBackRow = chessColor == ChessColor.Black ? BLACK_BACK_ROW : WHITE_BACK_ROW;
            for (int i = 0; i < _gameBoard.BOARD_SIZE; i++)
            {
                ChessBase chess = new Pawn(_gameBoard.BoardCells[i, pawnVertical].ChessPosition, chessColor);
                _gameBoard.BoardCells[i, pawnVertical].SetChess(chess);
                _chessSets[chessColor].Add(chess);
            }

            ChessBase castle1 = new Castle(_gameBoard.BoardCells[0, pawnBackRow].ChessPosition, chessColor);
            _chessSets[chessColor].Add(castle1);
            _gameBoard.BoardCells[0, pawnBackRow].SetChess(castle1);
            ChessBase castle2 = new Castle(_gameBoard.BoardCells[_gameBoard.BOARD_SIZE - 1, pawnBackRow].ChessPosition, chessColor);
            _chessSets[chessColor].Add(castle2);
            _gameBoard.BoardCells[_gameBoard.BOARD_SIZE - 1, pawnBackRow].SetChess(castle2);
            ChessBase knight1 = new Knight(_gameBoard.BoardCells[1, pawnBackRow].ChessPosition, chessColor);
            _chessSets[chessColor].Add(knight1);
            _gameBoard.BoardCells[1, pawnBackRow].SetChess(knight1);
            ChessBase knight2 = new Knight(_gameBoard.BoardCells[6, pawnBackRow].ChessPosition, chessColor);
            _chessSets[chessColor].Add(knight2);
            _gameBoard.BoardCells[6, pawnBackRow].SetChess(knight2);
            ChessBase bishop1 = new Bishop(_gameBoard.BoardCells[2, pawnBackRow].ChessPosition, chessColor);
            _chessSets[chessColor].Add(bishop1);
            _gameBoard.BoardCells[2, pawnBackRow].SetChess(bishop1);
            ChessBase bishop2 = new Bishop(_gameBoard.BoardCells[5, pawnBackRow].ChessPosition, chessColor);
            _chessSets[chessColor].Add(bishop2);
            _gameBoard.BoardCells[5, pawnBackRow].SetChess(bishop2);
            ChessBase queen = new Queen(_gameBoard.BoardCells[3, pawnBackRow].ChessPosition, chessColor);
            _chessSets[chessColor].Add(queen);
            _gameBoard.BoardCells[3, pawnBackRow].SetChess(queen);
            ChessBase king = new King(_gameBoard.BoardCells[4, pawnBackRow].ChessPosition, chessColor);
            _chessSets[chessColor].Add(king);
            _gameBoard.BoardCells[4, pawnBackRow].SetChess(king);
        }
    }
}
