using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    class Players
    {
        readonly Player _xPlayer, _oPlayer;

        public Player CurrentPlayer
        {
            get; private set;
        }

        public Players (string xPlayerName, string oPlayerName)
        {
            _xPlayer = new Player( xPlayerName, 'X' );
            _oPlayer = new Player( oPlayerName, 'O' );

            CurrentPlayer = _xPlayer;
        }

        public void NextPlayer ()
        {
            CurrentPlayer = (CurrentPlayer == _xPlayer) ? _oPlayer : _xPlayer;
        }

        public void ShowGreetings (char winnersymbol, TextWriter greetingsWriter)
        {
            Player winnerPlayer = (winnersymbol == _xPlayer.Symbol) ? _xPlayer : _oPlayer;
            Player loserPlayer = (winnersymbol == _xPlayer.Symbol) ? _oPlayer : _xPlayer;
            greetingsWriter.WriteLine( $"{winnerPlayer.Name} вы  выиграли поздравляем, {loserPlayer.Name} а вы проиграли..." );
        }
    }
}
