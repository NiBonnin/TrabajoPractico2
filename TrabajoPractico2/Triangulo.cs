using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico2
{
    class Triangulo
    {
        private Punto p1;
        private Punto p2;
        private Punto p3;

        public Triangulo(Punto p1, Punto p2, Punto p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }
        public Punto Punto1 { get { return this.p1; }}
        public Punto Punto2 { get { return this.p2; }}
        public Punto Punto3 { get { return this.p3; } }
        public double Area { get { return (this.Perimetro /2);}}
        public double Perimetro { get {
                return (p1.CalularDistanciaDesde(p2) +
                            p2.CalularDistanciaDesde(p3) +
                                p3.CalularDistanciaDesde(p1));
            }
        }

    }
}
