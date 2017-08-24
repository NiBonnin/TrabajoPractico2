using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico2
{
    class Principal
    {
        static Controlador ct = new Controlador();

        static void Main(string[] args)
        {
            Console.WriteLine("Seleccione la opcion");
            Console.WriteLine("1. Crear un punto");
            Console.WriteLine("2. Crear un circulo");
            Console.WriteLine("3. Crear un triangulo");
            char op = Convert.ToChar(Console.ReadLine());
            switch (op){
                case '1': opcionPunto(); break;
                case '2': opcionCirculo(); break;
                case '3': opcionTriangulo(); break;
            }
        }

        private static void opcionPunto()
        {
            Console.WriteLine("Ingese dos coordenadas:");
            Console.Write("X: ");
            double cX = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y: ");
            double cY = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Tiene la opcion de calcular la distancia a este punto desde otro punto, desea hacerlo? Y/N");
            char op = Convert.ToChar(Console.ReadLine());
            if ((op == 'Y') || (op == 'y'))
            {
                Console.WriteLine("Ingese dos coordenadas:");
                Console.Write("X: ");
                double cX2 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Y: ");
                double cY2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("La distancia entre los dos puntos es de: " + ct.CaclularDistanciaDesdePunto(cX,cY,cX2,cY2));
            }
            despedirse();
        }

        private static void opcionCirculo()
        {
            Console.WriteLine("Para crear un circulo se necesita de un punto y de un radio");

            Console.WriteLine("Ingese dos coordenadas:");
            Console.Write("X: ");
            double cX = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y: ");
            double cY = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese el radio: ");
            double radio = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Su circulo fue creado con exito");
            char cont;
            do
            {
                Console.WriteLine("Seleccione la opcion");
                Console.WriteLine("1. Ver centro (desabilitada)");
                Console.WriteLine("2. Ver radio");
                Console.WriteLine("3. Ver area");
                Console.WriteLine("4. Ver perimetro");
                char op = Convert.ToChar(Console.ReadLine());
                switch (op) {
                    //case '1': Console.WriteLine("Su centro es un punto"); mostrarPunto(c.Centro); break;
                    case '2': Console.WriteLine("Su radio es de: "+ radio); break;
                    case '3': Console.WriteLine("Su area es de: "+ ct.CalcularAreaCirculo(cX, cY, radio)); break;
                    case '4': Console.WriteLine("Su perimetro es de: " + ct.CalcularPerimetroCirculo(cX, cY, radio)); break;
                    default: Console.WriteLine("Error!"); break;
                }
                Console.WriteLine("Continuar? Y/N");
                cont = Convert.ToChar(Console.ReadLine());
            } while ((cont == 'Y') || (cont == 'y'));
            despedirse();
        }

        private static void opcionTriangulo()
        {

            Console.WriteLine("Para crear un triangulo se necesitan tres puntos");

            Console.WriteLine("1er punto");
            Console.WriteLine("Ingese dos coordenadas:");
            Console.Write("X: ");
            double cX1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y: ");
            double cY1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Su punto fue creado con exito");

            Console.WriteLine("2do punto");
            Console.WriteLine("Ingese dos coordenadas:");
            Console.Write("X: ");
            double cX2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y: ");
            double cY2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Su punto fue creado con exito");

            Console.WriteLine("3er punto");
            Console.WriteLine("Ingese dos coordenadas:");
            Console.Write("X: ");
            double cX3 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y: ");
            double cY3 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Su punto fue creado con exito");


            Console.WriteLine("Su triangulo fue creado con exito");

            char cont;
            do
            {
                Console.WriteLine("Seleccione la opcion");
                Console.WriteLine("1. Ver area");
                Console.WriteLine("2. Ver perimetro");
                Console.WriteLine("3. Ver punto 1 (desabilitada)");
                Console.WriteLine("4. Ver punto 2 (desabilitada)");
                Console.WriteLine("5. Ver punto 3 (desabilitada)");
                char op = Convert.ToChar(Console.ReadLine());
                switch (op)
                {
                    case '1': Console.WriteLine("Su area es de: " + ct.CalcularAreaTriangulo(cX1, cY1, cX2, cY2, cX3, cY3)); break;
                    case '2': Console.WriteLine("Su perimetro es de: " + ct.CalcularAreaTriangulo(cX1, cY1, cX2, cY2, cX3, cY3)); break;
                    //case '3': Console.WriteLine("Punto 1"); mostrarPunto(t.Punto1); break;
                    //case '4': Console.WriteLine("Punto 2"); mostrarPunto(t.Punto2); break;
                    //case '5': Console.WriteLine("Punto 3"); mostrarPunto(t.Punto3); break;
                    default: Console.WriteLine("Error!"); break;
                }
                Console.WriteLine("Continuar? Y/N");
                cont = Convert.ToChar(Console.ReadLine());
            } while ((cont == 'Y') || (cont == 'y'));
            despedirse();
        }

        private static Punto crearPunto() {
            Console.WriteLine("Ingese dos coordenadas:");
            Console.Write("X: ");
            double cX = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y: ");
            double cY = Convert.ToDouble(Console.ReadLine());
            Punto p = new Punto(cX, cY);
            Console.WriteLine("Su punto fue creado con exito");
            return p;
        }

        private static Circulo crearCirculo()
        {
            Console.WriteLine("Para crear un circulo se necesita de un punto y de un radio");
            Punto p = crearPunto();
            Console.Write("Ingrese el radio: ");
            double radio = Convert.ToDouble(Console.ReadLine());
            Circulo circ = new Circulo(p, radio);
            Console.WriteLine("Su circulo fue creado con exito");
            return circ;
        }

        private static Triangulo crearTriangulo()
        {
            Console.WriteLine("Para crear un triangulo se necesitan tres puntos");
            Console.WriteLine("1er punto");
            Punto p1 = crearPunto();
            Console.WriteLine("2do punto");
            Punto p2 = crearPunto();
            Console.WriteLine("3er punto");
            Punto p3 = crearPunto();
            Triangulo triangulo = new Triangulo(p1,p2,p3);
            Console.WriteLine("Su triangulo fue creado con exito");
            return triangulo;
        }

        private static void mostrarPunto(Punto p)
        {
            Console.WriteLine("Coordenadas del punto");
            Console.WriteLine("Coordenada X:"+ p.X);
            Console.WriteLine("Coordenada Y:" + p.Y);
        }

        private static void despedirse()
        {
            Console.WriteLine("Adios");
            Console.ReadKey();
        }
    }
}
