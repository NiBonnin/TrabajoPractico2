using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Cuentas
    {
        Cuenta ctaCorriente;
        Cuenta cjaAhorro;
        Cliente cliente;

        public Cuentas(Cliente c)
        {
            this.cliente = c;
            ctaCorriente = new Cuenta(1000);
            cjaAhorro = new Cuenta(1500);
        }

        public Cuenta CuentaCorriente { get { return ctaCorriente; } }
        public Cuenta CajaAhorro { get { return cjaAhorro; } }
        
    }
}
