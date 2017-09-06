using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Partida
    {
        private String[] palabras;
        private int cantIntentos;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private Jugador jugador;
        public Partida(int intentos, Jugador jugador)
        {
            this.palabras = new String[] 
                {"casa", "arbol", "auto", "camion", "avion", "computadora", "robot", "numero", "palabra", "cancion",
                "martillo","letra", "arroz","avioneta", "garra","trebol", "pasillo","camara", "autopista", "cazador",
                "cable", "telefono","ventilador", "mate", "cafe", "termo", "cuchillo", "tenedor","cuchara", "lente" };
            this.cantIntentos = intentos;
            this.jugador = jugador;
        }

        public void FinPartida()
        {
            this.fechaFin = DateTime.Now;
        }

        public void InicioPartida()
        {
            this.fechaInicio = DateTime.Now;
        }

        public String ObtenerPalabra()
        {
            Random rdn = new Random();
            return palabras[rdn.Next(0, this.palabras.Length)];
        }

        public DateTime ObtenerFechaFin()
        {
            return this.fechaFin;
        }

        public int CantIntentos { get { return this.cantIntentos; } }

        public TimeSpan ObtenerTiempo {
            get
            {
                TimeSpan tiempoJugado = this.fechaFin - this.fechaInicio;
                return tiempoJugado;
            }
        }

        public Jugador Jugador { get { return this.jugador; } }
    }
}
