using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba
{
    class Program
    {
        static void Main()
        {
            string [,] matriz= new string [8,6];
            string palabra ="null";
            bool jugar = true;
            int intentos = 0;
            string letra = " ";
            char Letrachar = ' ';
            string volverjugar = " ";
            int Gano = 0;
            int contador = 0; // para saber si la letra que se escribio si estaba en la palabra
            while (jugar == true)
            {
                palabra = escojerPalabra(palabra);
                char[] palabravector = palabra.ToCharArray();
                char[] espaciosEnBlanco = new char[palabra.Length];
                for (int i = 0; i < palabra.Length; i++) espaciosEnBlanco[i] = '_';
                Gano = 0;
                while (intentos <= 6)
                {
                    bool letraMayorQueUno = true; // para saber si la letra ingresada fue solo una y si se puede convertir en char
                    MostrarEpaciosEnBlanco(espaciosEnBlanco);
                    Console.WriteLine();
                    while (letraMayorQueUno == true)
                    {
                        Console.Write("dijite la letra: ");
                        letra =   Console.ReadLine();
                        if (letra.Length == 1)
                        {
                            Letrachar = Convert.ToChar(letra);
                            letraMayorQueUno = false ;
                        }
                        Console.Clear();
                    }
                    
                    for (int i = 0; i < espaciosEnBlanco.Length; i++)
                    {
                        if (Letrachar == espaciosEnBlanco[i])
                        {
                            Console.WriteLine("esa letra ya estaba, escribir otra");
                            Console.ReadKey();
                            contador++;
                        }
                        else 
                        {
                            if (Letrachar == palabravector[i])
                            {
                                espaciosEnBlanco[i] = Letrachar;
                                contador++;
                                Gano++;
                            }
                        }
                    }
                    if (contador == 0)
                    {
                        intentos++;
                    }
                    if (Gano == palabra.Length) break;
                    else contador = 0;
                }
                if (Gano == palabra.Length)
                {
                    Console.WriteLine();
                    MostrarEpaciosEnBlanco(espaciosEnBlanco);
                    Console.WriteLine();
                    Console.WriteLine("Si la palabra era {0} ganaste!! quieres volver a jugar : S / N", palabra );
                    volverjugar = Console.ReadLine();
                    if (volverjugar == "n") jugar = false;
                    else intentos = 0;

                }
                else
                {
                    Console.WriteLine("se te acabaron los intentos la palabra era {0} quieres juegar de nuevo : S /  N", palabra);
                    volverjugar = Console.ReadLine();
                    if (volverjugar == "n") jugar = false;

                    else intentos = 0;
                }
            }
        }
        static void MostrarEpaciosEnBlanco(char[] Espacios)
        {
            for (int i = 0; i < Espacios.Length; i++)
            {
                Console.Write(Espacios[i] + " ");
            }
        }
        static string escojerPalabra(string palabra)
        {
            string[] palabras = new string[16] { "camion", "computador", "leche", "vino", "vaca", "mula", "lis", "quiero", "hermoza", "novia","tarro", "perro", "uva", "internet", "codigo", "programacion"};
            Random nroaleatorio = new Random();
            palabra = palabras[nroaleatorio .Next (10)];
            return palabra;
        }
    }
}
