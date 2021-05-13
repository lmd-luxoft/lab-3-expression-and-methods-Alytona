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
        readonly char[] _cells = new char[9];

        public GameField ()
        {
            for (int i = 0; i < _cells.Length; i++) {
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
            for (int i = 0; i < 3; i++)
                if (_cells[i * 3] == _cells[i * 3 + 1] && _cells[i * 3 + 1] == _cells[i * 3 + 2])
                    return _cells[i];
                else if (_cells[i] == _cells[i + 3] && _cells[i + 3] == _cells[i + 6])
                    return _cells[i];
                else if ((_cells[2] == _cells[4] && _cells[4] == _cells[6]) || (_cells[0] == _cells[4] && _cells[4] == _cells[8]))
                    return _cells[i];
            return EMPTY_CELL_CHAR;
        }

        public bool SetCell (int cell, char cellChar)
        {
            if (cell <= 9 && cell >= 1 && _cells[cell - 1] == EMPTY_CELL_CHAR)
            {
                _cells[cell - 1] = cellChar;
                return true;
            }
            return false;
        }
    }
}
