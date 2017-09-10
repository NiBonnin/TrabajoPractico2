using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Controlador
    {
        private Partidas partidas = new Partidas();
        private int cantPartidas, cantMejoresPartidas;
        private Partida partidaActual;

        public Controlador()
        {
            cantPartidas = this.partidas.CantidadMaxPartidas;
            cantMejoresPartidas = this.partidas.CantMejoresPartidas;
        }
        
        public void CrearPartida(String nombre)//se crea una partida con el nombre del jugador en partida actual
        {
            this.partidaActual = this.partidas.NuevaPartida(nombre);
        }

        public void GuardarPartidaActual()//la guarda solo si es mejor que la peor
        {
            partidas.GuardarPartida(partidaActual);
        }

        public String ObtenerPalabraPartidaActual()
        {
            String asd = this.partidaActual.ObtenerPalabra();
            Console.WriteLine(asd);
            return asd;
        }

        public void FinalizarPartidaActual()//se detiene el contador de tiempo
        {
            this.partidaActual.FinPartida();
        }

        public void IniciarPartidaActual()//se inicia el contador de tiempo
        {
            this.partidaActual.InicioPartida();
        }
        
        public Boolean ControlarIntentosPartidaActual(int intentosActuales)
        {
            int cantIntentos = this.partidaActual.CantIntentos;
            if (intentosActuales == cantIntentos){ return false; }
                else { return true; }
        }

        private String ObtenerTiempoPartida(Partida partida)
        {
            TimeSpan tiempo = partida.ObtenerTiempo;
            return tiempo.TotalMinutes+"m " + tiempo.TotalSeconds +"s "+ tiempo.TotalMilliseconds+"ms";
        }

        public String ObtenerTiempoPartidaActual()
        {
            return ObtenerTiempoPartida(this.partidaActual);
        }

        public int CantidadMaximaPartidas()
        {
            return this.cantPartidas;
        }

        public String[,] TablaPartidas()
        {
            int i = 0;
            partidas.ActualizarYOrdenar();//actualizacion y ordenamiento de partidas
            String[,] tablaPartidas = new String[cantMejoresPartidas, 3];//5 filas(las mejores 5 partidas) y 3 columnas(numero partida,nombre jugador, tiempo)
            for (int f = 0; f < tablaPartidas.GetLength(0); f++)
            {
                if (partidas.ListaPartida[i] != null)
                {
                    tablaPartidas[f, 0] = i + 1 + "";
                    tablaPartidas[f, 1] = partidas.ListaPartida[i].NombreJugador;
                    tablaPartidas[f, 2] = ObtenerTiempoPartida(partidas.ListaPartida[i]);
                }
                i++;
            }
            return tablaPartidas;
        }
    }
}
