using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Controlador
    {
        private Partidas partida;
        private Jugador jugador;
        private int cantPartidas;
        private Partida[] mejoresPartidas;

        public Controlador()
        {
            this.jugador = new Jugador("Nico");
            this.partida = new Partidas(this.jugador);
            this.cantPartidas = this.partida.CantidadMaxPartidas;
        }

        public String ObtenerPalabra(int i)
        {            
            return this.partida.Partida[i].ObtenerPalabra(); 
        }

        public void FinalizarPartida(int i)
        {
            this.partida.Partida[i].FinPartida();
        }

        public void IniciarPartida(int i)
        {
            this.partida.Partida[i].InicioPartida();
        }
        
        public Boolean ControlarIntentos(int numeroPartida,int intentosActuales)
        {
            int cantIntentos = this.partida.Partida[numeroPartida].CantIntentos;
            if (intentosActuales == cantIntentos){ return false; }
                else { return true; }
        }

        public String ObtenerTiempoPartida(int i)
        {
            TimeSpan tiempo = this.partida.Partida[i].ObtenerTiempo;
            return tiempo.TotalMinutes+"m " + tiempo.TotalSeconds +"s "+ tiempo.TotalMilliseconds+"ms";
        }

        public int CantidadMaximaPartidas()
        {
            return this.cantPartidas;
        }

        public void TablaPartidas()
        {
            MejoresPartidas();//actualizacion de las mejores partidas
            String[,] tablaPartidas = new String[5, 3];//5 filas(las mejores 5 partidas) y 3 columnas(numero partida,nombre jugador, tiempo)
            for (int f = 0; f < tablaPartidas.GetLength(0); f++)
            {
                int i = 0;
                if (mejoresPartidas[i] != null)
                {
                    tablaPartidas[f, 0] = i + 1 + "";
                    tablaPartidas[f, 1] = mejoresPartidas[i].Jugador.Nombre;
                    tablaPartidas[f, 2] = mejoresPartidas[i].ObtenerTiempo + "";
                }
                i++;
            }
        }

        private Array MejoresPartidas()
        {
            int j = 0;
            mejoresPartidas = new Partida[5];
            for (int i = 0; i < this.cantPartidas; i++)
            {
                if (partida.Partida[i] != null)
                {
                    j++;
                }
            }
            if (j < 6)
            {
                for (int i = 0; i < this.cantPartidas; i++)
                {
                    mejoresPartidas[i] = this.partida.Partida[i];
                }
            }
            else
            {
                for (int i = 6; i < this.cantPartidas; i++)
                {
                    if (partida.Partida[i] != null)
                    {
                        if (PeorPartidaDeArray().ObtenerTiempo < partida.Partida[i].ObtenerTiempo)
                        {
                            ReemplazarEnMejoresPartidas(PeorPartidaDeArray(), partida.Partida[i]);
                        }
                    }
                }
            }
            return mejoresPartidas;
        }

        private Partida PeorPartidaDeArray()
        {
            Partida menor = mejoresPartidas[0];
            for (int i = 0; i < 6; i++)
            {
                if (mejoresPartidas[i] != null)
                {
                    if (menor.ObtenerTiempo > mejoresPartidas[i].ObtenerTiempo)
                    {
                        menor = mejoresPartidas[i];
                    }
                }
            }
            return menor;
        }

        private void ReemplazarEnMejoresPartidas(Partida oldPartida, Partida newPartida)
        {
            for (int i = 0; i < 6; i++)
            {
                if (mejoresPartidas[i] != null)
                {
                    if (mejoresPartidas[i] == oldPartida)
                    {
                        mejoresPartidas[i] = newPartida;
                    }
                }
            }
        }


    }
}
