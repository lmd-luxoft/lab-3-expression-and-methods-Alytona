using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    class Program
    {
        static char _winnerSymbol = GameField.EMPTY_CELL_CHAR;

        static GameField _gameField = new GameField();
        static Players _gamePlayers;

        static void Main(string[] args)
        {
            InitGame();

            for (int move = 1; move <= GameField.FIELD_SIZE; move++)
            {
                MakeMove();

                Console.Clear();
                _gameField.Show( Console.Out );

                if (move >= 5)
                {
                    _winnerSymbol = _gameField.Check(); 
                    if (_winnerSymbol != GameField.EMPTY_CELL_CHAR)
                        break;
                }
            }
            _gamePlayers.ShowGreetings( _winnerSymbol, Console.Out );

            Console.ReadKey( true );
        }
        static void InitGame ()
        {
            string playerName1, playerName2;
            do
            {
                Console.Write( "Введите имя первого игрока : " );
                playerName1 = Console.ReadLine();

                Console.Write( "Введите имя второго игрока: " );
                playerName2 = Console.ReadLine();
                Console.WriteLine();
            } while (playerName1 == playerName2);
            _gamePlayers = new Players( playerName1, playerName2 );

            Console.Clear();
            _gameField.Show( Console.Out );
        }
        static void MakeMove ()
        {
            string raw_cell;
            int cell;

            Console.Write( _gamePlayers.CurrentPlayer.Name );
            do
            {
                Console.Write( ", введите номер ячейки, сделайте свой ход:" );
                raw_cell = Console.ReadLine();
            }
            while (!Int32.TryParse( raw_cell, out cell ));

            while (!_gameField.SetCell( cell, _gamePlayers.CurrentPlayer.Symbol ))
            {
                do
                {
                    Console.Write( "Введите номер правильного ( 1-9 ) или пустой ( --- ) клетки , чтобы сделать ход:" );
                    raw_cell = Console.ReadLine();
                }
                while (!Int32.TryParse( raw_cell, out cell ));
                Console.WriteLine();
            }

            _gamePlayers.NextPlayer();
        }

    }
}
