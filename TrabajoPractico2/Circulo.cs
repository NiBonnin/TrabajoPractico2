using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico2
{
    class Circulo
    {
        double radio;
        Punto centro;

        public Circulo(Punto pCentro, double pRadio)
        {
            this.radio = pRadio;
            this.centro = pCentro;
        }

        public Circulo(double pX, double pY, double pRadio)
        {
            this.radio = pRadio;
            Punto p = new Punto(pY, pY);
            this.centro = p;
        }

        public Punto Centro { get { return this.centro; }}
        public double Radio { get { return this.radio; }}
        public double Area { get { return this.Radio * this.Radio * Math.PI; } }
        public double Perimetro { get { return 2 * Math.PI * this.Radio; } }        
    }
}
