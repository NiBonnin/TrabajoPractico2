using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Partidas
    {
        private Partida[] listaPartidas = new Partida[3], mejoresPartidas = new Partida[2];
        private int intentos = 10;

        public Partidas() { }

        public Partida NuevaPartida(String jugador)//crea una nueva partida y la devuelve
        {
            return new Partida(intentos, jugador);
        }

        public void ActualizarYOrdenar()
        {
            OrdenarPartidas();
            for (int i = 0; i < mejoresPartidas.Length; i++)
            {
                mejoresPartidas[i] = listaPartidas[i];
            }
        }

        private void OrdenarPartidas()
        {
            for (int u = 2; u < listaPartidas.Length; u++)
            {
                for (int e = 0; e < (listaPartidas.Length - u); e++)
                {
                    if ((listaPartidas[e] != null) && (listaPartidas[e + 1] != null))
                    {
                        if (listaPartidas[e].ObtenerTiempo > listaPartidas[e + 1].ObtenerTiempo)
                        {
                            var aux = listaPartidas[e];
                            listaPartidas[e] = listaPartidas[e + 1];
                            listaPartidas[e + 1] = aux;
                        }
                    }
                }
            }
        }

        private Partida PeorPartidaDeLasMejores()
        {
            Partida menor = mejoresPartidas[0];
            for (int i = 0; i < mejoresPartidas.Length; i++)
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

        public void GuardarPartida(Partida partida)//la guarda cuando hay espacio, y si no lo hay solo si es mejor que la peor
        {
            ActualizarYOrdenar();
            int valor = HayLugar();
            if (valor != -1)//si hay lugar se tiene la posicion donde esta ese lugar
            {
                listaPartidas[valor] = partida;
            }
            else               //si no hay lugar disponible se guarda en donde esta la peor, si es que la nueva es mejor (que deberia ser la ultima, porque esta ordenada)
            {
                Partida peorPartida = PeorPartida();
                if (partida.ObtenerTiempo < peorPartida.ObtenerTiempo)
                {
                    ReemplazarPartida(peorPartida, partida);
                }
            }
           
        }

        private Partida PeorPartida()//obtiene la peor partida de todas
        {
            Partida menor = listaPartidas[0];
            for (int i = 0; i < listaPartidas.Length; i++)
            {
                if (listaPartidas[i] != null)
                {
                    if (menor.ObtenerTiempo > listaPartidas[i].ObtenerTiempo)
                    {
                        menor = listaPartidas[i];
                    }
                }
            }
            return menor;
        }

        private void ReemplazarPartida(Partida oldPartida, Partida newPartida)
        {
            for (int i = 0; i < listaPartidas.Length; i++)
            {
                if (listaPartidas[i] != null)
                {
                    if (listaPartidas[i].ObtenerTiempo == oldPartida.ObtenerTiempo)
                    {
                        listaPartidas[i] = newPartida;
                    }
                }
            }
        }

        private int HayLugar()//para false es -1 y para true, la posicion
        {
            int i = 0, limiteArray = listaPartidas.Length - 1;
            while ((i < limiteArray) && (listaPartidas[i] != null))//mientras que haya lugar para agregar y no se llegue al fin
            {
                i++;//suma hasta que encuentre uno vacio o llegue a la cantidad maxima que se guarda
            }
            if (limiteArray == i)
            {
                if (listaPartidas[i] != null) { return -1; }
                else { return i; }
            }
            return i;
        }

        public Partida[] ListaPartida { get { return this.listaPartidas; } }
        public int CantidadMaxPartidas { get { return this.listaPartidas.Length; } }
        public int CantMejoresPartidas { get { return this.mejoresPartidas.Length; } }
    }
}
