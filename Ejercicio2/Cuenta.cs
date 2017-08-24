using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Cuenta
    {
        private double saldo;
        private double acuerdo;
        public Cuenta(double acrdo)
        {
            this.saldo = 0;
            this.acuerdo = acrdo;
        }
        public Cuenta(double saldoInicial, double acrdo)
        {
            this.saldo = saldoInicial;
            this.acuerdo = acrdo;
        }

        public double Saldo { get { return this.saldo; } }
        public double Acuerdo { get { return this.acuerdo; } }

        public void acreditarSaldo(double sald)
        {
            this.saldo += sald;
        }

        public Boolean debitarSaldo(double sald)
        {
            if (this.saldo > sald) { this.saldo -= sald; return true; }
            else if (this.acuerdo > sald) { this.acuerdo -= sald; return true; }
            else return false;
        }
    }
}
