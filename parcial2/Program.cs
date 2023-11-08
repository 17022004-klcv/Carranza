using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial2
{

    internal class Program
    {

        ///inicioooooooo <summary>
        /// inicioooooooo
        
        

        /// fin 
        /// </summary>
        static int[,] juego = new int[3, 3];
        static bool jugadorX = true;

        //pregunta en que posicion se pondra el caracter

        static void PedirMovimiento()
        {
            Console.WriteLine("Turno del jugador " + (jugadorX ? "X" : "O"));
            Console.Write("Ingrese la fila (1-3): ");
            int fila = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Ingrese la columna (1-3): ");
            int columna = int.Parse(Console.ReadLine()) - 1;

            if (fila >= 0 && fila < 3 && columna >= 0 && columna < 3 && juego[fila, columna] == ' ')
            {
                juego[fila, columna] = jugadorX ? 'X' : 'O';
            }
            else
            {
                Console.WriteLine("Movimiento inválido. Intente nuevamente.");
                PedirMovimiento();
            }
        }

        static bool VerificarGanador()
        {
            // Verificar líneas horizontales
            for (int i = 0; i < 3; i++)
            {
                if (juego[i, 0] != ' ' && juego[i, 0] == juego[i, 1] && juego[i, 1] == juego[i, 2])
                {
                    return true;
                }
            }
            // Verificar líneas verticales
            for (int j = 0; j < 3; j++)
            {
                if (juego[0, j] != ' ' && juego[0, j] == juego[1, j] && juego[1, j] == juego[2, j])
                {
                    return true;
                }
            }

            // Verificar diagonales
            if (juego[0, 0] != ' ' && juego[0, 0] == juego[1, 1] && juego[1, 1] == juego[2, 2])
            {
                return true;
            }
            if (juego[0, 2] != ' ' && juego[0, 2] == juego[1, 1] && juego[1, 1] == juego[2, 0])
            {
                return true;
            }

            return false;
        }

        //mostrar matriz
        static void Matriz()
        {
            for (int filas = 0; filas < juego.GetLength(0); filas++)
            {
                for (int columnas = 0; columnas < juego.GetLength(1); columnas++)
                {
                    Console.Write("-" + " ");

                }
                Console.Write("\n");
            }
        }

        //empate
        static bool Empate()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (juego[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static void MostrarTablero()
        {
            Console.Clear();
            Console.WriteLine("  1 2 3");
            Console.WriteLine(" -------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + 1 + "|");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(juego[i, j] + "|");
                }
                Console.WriteLine("\n -------");
            }
        }
    
       
            

            // Resto del código (VerificarGanador, Matriz, Empate, MostrarTablero, Main) se mantiene igual.

            static void Main(string[] args)
            {
                // Inicializa la matriz con espacios en blanco.
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        juego[i, j] = '\0';
                    }
                }

                bool termina = false;
                Console.Write("Elija su caracter 'X' o 'O': ");
                string caracter = Console.ReadLine();

                // Mostrar matriz
                Matriz();

                while (!termina)
                {
                    // Capturar las posiciones
                    PedirMovimiento();

                    if (VerificarGanador())
                    {
                        MostrarTablero();
                        Console.WriteLine("Felicidades, ha ganado");
                        termina = true;
                    }
                    else if (Empate())
                    {
                        MostrarTablero();
                        Console.WriteLine("Empate!!!");
                        termina = true;
                    }
                    else
                    {
                        MostrarTablero();
                        jugadorX = !jugadorX; // Cambiar al otro jugador
                    }
                }

                Console.ReadKey();
            }
        }
    }

