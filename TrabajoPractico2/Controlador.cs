using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico2
{
    class Controlador
    {
        public Controlador(){}

        public double CaclularDistanciaDesdePunto(double x1, double y1, double x2, double y2)
        {
            Punto p1 = new Punto(x1, y1);
            Punto p2 = new Punto(x2, y2);
            return p1.CalularDistanciaDesde(p2);
        }

        public double CalcularAreaTriangulo(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Punto p1 = new Punto(x1, y1);
            Punto p2 = new Punto(x2, y2);
            Punto p3 = new Punto(x3, y3);
            Triangulo t = new Triangulo(p1, p2, p3);
            return t.Area;
        }

        public double CalucarPerimetroTriangulo(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Punto p1 = new Punto(x1, y1);
            Punto p2 = new Punto(x2, y2);
            Punto p3 = new Punto(x3, y3);
            Triangulo t = new Triangulo(p1,p2,p3);
            return t.Perimetro;
        }

        public double CalcularAreaCirculo(double x, double y, double radio)
        {
            Punto punto = new Punto(x, y);
            Circulo circulo = new Circulo(punto, radio);
            return circulo.Area;
        }

        public double CalcularPerimetroCirculo(double x, double y, double radio)
        {
            Punto punto = new Punto(x, y);
            Circulo circulo = new Circulo(punto, radio);
            return circulo.Perimetro;
        }        
    }
}
