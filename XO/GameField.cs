using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    class GameField
    {
        public const char EMPTY_CELL_CHAR = '-';
        public const int FIELD_SIDE_SIZE = 3;
        public const int FIELD_SIZE = 9;

        readonly char[] _cells = new char[FIELD_SIZE];

        public GameField ()
        {
            for (int i = 0; i < FIELD_SIZE; i++) {
                _cells[i] = EMPTY_CELL_CHAR;
            }
        }

        public void Show (TextWriter gameFieldWriter)
        {
            gameFieldWriter.WriteLine( "Числа клеток:" );
            gameFieldWriter.WriteLine( "-1-|-2-|-3-" );
            gameFieldWriter.WriteLine( "-4-|-5-|-6-" );
            gameFieldWriter.WriteLine( "-7-|-8-|-9-" );

            gameFieldWriter.WriteLine( "Текущая ситуация (---пустой):" );
            gameFieldWriter.WriteLine( $"-{_cells[0]}-|-{_cells[1]}-|-{_cells[2]}-" );
            gameFieldWriter.WriteLine( $"-{_cells[3]}-|-{_cells[4]}-|-{_cells[5]}-" );
            gameFieldWriter.WriteLine( $"-{_cells[6]}-|-{_cells[7]}-|-{_cells[8]}-" );
        }

        public char Check ()
        {
            for (int i = 0; i < FIELD_SIDE_SIZE; i++) {
                if (CheckHorizontal( i ))
                    return _cells[i];

                if (CheckVertical( i ))
                    return _cells[i];
            }
            if (CheckDiagonals())
                return _cells[5];

            return EMPTY_CELL_CHAR;
        }
        bool CheckHorizontal (int rowNumber)
        {
            int rowOffset = rowNumber * FIELD_SIDE_SIZE;
            return _cells[rowOffset] == _cells[rowOffset + 1] && _cells[rowOffset + 1] == _cells[rowOffset + 2];
        }
        bool CheckVertical (int columnNumber)
        {
            return _cells[columnNumber] == _cells[columnNumber + FIELD_SIDE_SIZE] && _cells[columnNumber + FIELD_SIDE_SIZE] == _cells[columnNumber + FIELD_SIDE_SIZE * 2];
        }
        bool CheckDiagonals ()
        {
            return CheckMainDiagonal() || CheckSecondaryDiagonal();
        }
        bool CheckMainDiagonal ()
        {
            return _cells[2] == _cells[4] && _cells[4] == _cells[6];
        }
        bool CheckSecondaryDiagonal ()
        {
            return _cells[0] == _cells[4] && _cells[4] == _cells[8];
        }

        public bool SetCell (int cell, char cellChar)
        {
            if (cell <= FIELD_SIZE && cell >= 1 && _cells[cell - 1] == EMPTY_CELL_CHAR)
            {
                _cells[cell - 1] = cellChar;
                return true;
            }
            return false;
        }
    }
}
