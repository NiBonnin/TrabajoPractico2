using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico2
{
    class Punto
    {
        double iX, iY;
        public double X { get { return this.iX; }}
        public double Y { get { return this.iY; }}

        public Punto(double pX, double pY)
        {
            this.iX = pX;
            this.iY = pY;
        }
        
        public double CalularDistanciaDesde(Punto p)
        {
            double restaX = this.X - p.X;
            double restaY = this.Y - p.Y;
            double sum = Math.Pow(restaX, 2) + Math.Pow(restaY, 2);
            return Math.Sqrt(sum);
        }
    }
}
