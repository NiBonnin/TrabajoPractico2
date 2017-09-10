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
            do
            {
                Partidas p = new Partidas();
                p.ActualizarYOrdenar();
                Console.WriteLine("Juego: Ahorcado");
                Console.WriteLine("1. Ver mejores partidas");
                Console.WriteLine("2. Jugarse una");
                Console.WriteLine("0. Salir");
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
            } while (op != '0');

        }

        static public void OpcionJugar(int i)
        {
            Console.Write("Ingrese el nombre del jugador: ");
            String nombreJugador = Console.ReadLine();
            ct.CrearPartida(nombreJugador);
            String palabra = ct.ObtenerPalabraPartidaActual();
            if (JugarPartida(palabra))
            {
                Console.WriteLine("Felicitaciones!! Ganaste!!! :D");
                Console.WriteLine("La palabra era " + palabra);
                Console.WriteLine("Tu tiempo fue de " + ct.ObtenerTiempoPartidaActual());
                ct.GuardarPartidaActual();
            }
            else
            {
                Console.WriteLine("Perdiste :(");
                Console.WriteLine("Se te acabaron los intentos");
                Console.WriteLine("La palabra era " + palabra);
            }
            Console.ReadKey();   
        }
        
        static public void OpcionVerMejoresPartidas()
        {
            String[,] tablaPartidas = ct.TablaPartidas();
            for (int f = 0; f < tablaPartidas.GetLength(0); f++)
            {
                Console.WriteLine(tablaPartidas[f, 0]);
                Console.WriteLine(tablaPartidas[f, 1]);
                Console.WriteLine(tablaPartidas[f, 2]);
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static Boolean JugarPartida(String palabra)
        {
            char[] palabraVector = palabra.ToCharArray();                           //se crean y se inicializan algunas variables
            char[] palabraEnLineas = new char[palabra.Length];
            Char letra;
            Boolean letraAcertada, partidaGanada = false;
            int intentosActuales = 0, contadorPalabraCompleta = 0;
            for (int j = 0; j < palabra.Length; j++) { palabraEnLineas[j] = '_'; }  //fin de inicializacion y creacion

            Console.WriteLine("La palabra que debe adivinar tiene " + palabra.Length + " letras");
            Console.WriteLine();
            ct.IniciarPartidaActual();

            while ((ct.ControlarIntentosPartidaActual(intentosActuales)) && (!partidaGanada))//mientras que no se terminen los intentos y no haya ganado
            {
                Console.WriteLine();
                MostrarPalabraEnLineas(palabraEnLineas);
                Console.WriteLine();
                Console.Write("Escriba una letra: ");
                try
                {
                    letra = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    letra = '0';
                }
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
                if (contadorPalabraCompleta == palabra.Length) { partidaGanada = true; ct.FinalizarPartidaActual(); }
                Console.Clear();
            }
            Console.ReadKey();
            return partidaGanada;
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