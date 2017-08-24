using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Controlador
    {
        Cliente cliente;
        Cuentas cuentas;
        public Controlador()
        {
            this.cliente = new Cliente((Cliente.TipoDocumento) 1, "32093209", "Pepito");
            this.cuentas = new Cuentas(cliente);
        }

        public String GetNombre()
        {
            return cliente.Nombre;
        }
        public Cliente.TipoDocumento GetTipoDocumento()
        {
            return cliente.TipoDeDocumento;
        }
        public String GetNumeroDocumento()
        {
            return cliente.Documento;
        }

        public void AcreditarSaldoCC(double saldo)
        {
            cuentas.CuentaCorriente.acreditarSaldo(saldo);
        }
        public void AcreditarSaldoCA(double saldo)
        {
            cuentas.CajaAhorro.acreditarSaldo(saldo);
        }
        public Boolean DebitarSaldoCC(double saldo)
        {
            return cuentas.CuentaCorriente.debitarSaldo(saldo);
        }
        public Boolean DebitarSaldoCA(double saldo)
        {
            return cuentas.CajaAhorro.debitarSaldo(saldo);
        }
    }
}
