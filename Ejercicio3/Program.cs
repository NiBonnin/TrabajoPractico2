using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Program
    {
        static Controlador ct = new Controlador();
        static int cantidadMaximaPartidas = ct.CantidadMaximaPartidas();
        static void Main(string[] args)
        {
            int i = 0;
            char op;
            Console.WriteLine("Juego: Ahorcado");
            Console.WriteLine("1. Ver mejores partidas");
            Console.WriteLine("2. Jugarse una");
            try
            {
                op = Convert.ToChar(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine("Se saldra de la aplicacion");
                Console.ReadKey();
                op = '0';
            }
            switch (op)
            {
                case '1': OpcionVerMejoresPartidas(); break;
                case '2': OpcionJugar(i); i++; break;
                default: op = '0'; break;
            }
            Console.Clear();

        }

        static public void OpcionJugar(int i)
        {
            if (i != cantidadMaximaPartidas)
            {
                if (JugarPartida(i, ct.ObtenerPalabra(i)))
                {
                    ct.TablaPartidas();
                }
                else { i--; }
            }
                
        }

        static Boolean JugarPartida(int i, String palabra)
        {
                char[] palabraVector = palabra.ToCharArray();
                char[] palabraEnLineas = new char[palabra.Length];
                Char letra;
                Boolean letraAcertada, partidaGanada = false;
                int intentosActuales = 0, contadorPalabraCompleta = 0;

                Console.WriteLine("Juego numero " + i + 1);

                for (int j = 0; j < palabra.Length; j++) { palabraEnLineas[j] = '_'; }

                Console.WriteLine("La palabra que debe adivinar tiene " + palabra.Length + " letras");
                Console.WriteLine();
                ct.IniciarPartida(i);

                while ((ct.ControlarIntentos(i, intentosActuales)) && (!partidaGanada))//mientras que no se terminen los intentos y no haya ganado
                {
                    MostrarPalabraEnLineas(palabraEnLineas);
                    Console.WriteLine();
                    Console.Write("Escriba una letra: ");
                    letra = Convert.ToChar(Console.ReadLine());
                    letraAcertada = false;
                    for (int e = 0; e < palabraEnLineas.Length; e++)//se controla la letra
                    {
                        if (letra == palabraEnLineas[e])//si ya fue escrita y esta en los _ _ _ 
                        {
                            Console.WriteLine("La letra " + letra + " ya estaba, escribi otra");
                            Console.ReadKey();
                            letraAcertada = true;
                        }
                        else
                        {
                            if (letra == palabraVector[e])//o si esta en la palabra a adivinar
                            {
                                palabraEnLineas[e] = letra;
                                contadorPalabraCompleta++;
                                letraAcertada = true;
                            }
                        }
                    }
                    if (!letraAcertada)//si no se encontro en ningun lado -> intentos++
                    {
                        intentosActuales++;
                        Console.WriteLine("La letra " + letra + " no fue acetrada, vas " + intentosActuales + " intentos");
                        Console.ReadKey();
                    }
                    if (contadorPalabraCompleta == palabra.Length) { partidaGanada = true; ct.FinalizarPartida(i); }
                    Console.Clear();
                }
                if (partidaGanada)
                {
                    Console.WriteLine("Felicitaciones!! Ganaste!!! :D");
                    Console.WriteLine("La palabra era " + palabra);
                    Console.WriteLine("Tu tiempo fue de " + ct.ObtenerTiempoPartida(i));
                }
                else
                {
                    Console.WriteLine("Perdiste :(");
                    Console.WriteLine("Se te acabaron los intentos");
                    Console.WriteLine("La palabra era " + palabra);
                }
                Console.ReadKey();
            
            return partidaGanada;
        }

        static public void OpcionVerMejoresPartidas()
        {

        }

        static void MostrarPalabraEnLineas(char[] espacios)
        {
            for (int i = 0; i < espacios.Length; i++)
            {
                Console.Write(espacios[i] + " ");
            }
        }
    }
}