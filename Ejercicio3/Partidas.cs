using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Partidas
    {
        private int cantidadMaximaPartidas = 9;
        private Partida[] partida = new Partida[9];
        private int intentos = 10;
        public Partidas(Jugador jugador)
        {
            this.partida[0] = new Partida(intentos,jugador);
        }
        public Partida[] Partida { get { return this.partida; } }
        public int CantidadMaxPartidas { get { return this.cantidadMaximaPartidas; } }
    }
}
