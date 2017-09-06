using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Jugador
    {
        private String nombre;
        public Jugador(String nombre)
        {
            this.nombre = nombre;
        }

        public String Nombre { get { return this.nombre; } }
    }
}
