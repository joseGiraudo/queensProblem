using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej1QueensAttack
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // problema de las 8 reinas

            // si tengo una reina en una posicion (i,j), no puedo tener otra reina en ninguna posicion que sea:
            // misma columna, es decir (i, j+n) siendo n positivo o negativo, 0 < j+n < 8
            // misma fila, es decir (i+n, j) siendo n positivo o negativo, 0 < i+n < 8
            // diagonal (arriba der o abajo izq), es decir (i+n, j+n) siendo n positivo o negativo, 0 < i+n < 8 & 0 < j+n < 8
            // diagonal (arriba izq o abajo der), es decir (i+n, j+n) siendo n positivo o negativo, 0 < i+n < 8 & 0 < j+n < 8

            // pensando en un array numerico con 8 posiciones, podría representar las 8 columnas,
            // con el numero en el array (0 < n < 8) tendria representada las 8 filas

            // entonces, partiendo de una reina colocada en x posicion del array (columna)
            // ninguna reina podria compartir el mismo numero por representar la misma fila
            // y ademas ninguna pueden ser diagonal a ella, como marque arriba


            int n = 8; // 8 es un numero que podría cambiar

            int[] queens = new int[n];

            if (assignQueens(queens, 0))
            {
                for (int i = 0; i < queens.Length; i++)
                {
                    // Console.WriteLine(queens[i]);

                    for (int j = 0; j < queens.Length; j++)
                    {
                        if (queens[i] == j)
                        {
                            Console.Write("[Q] ");
                        } else
                        {
                            Console.Write("[ ] ");
                        }
                    }
                    Console.WriteLine();

                }
            }

            // verifico si el lugar donde va la reina esta libre

            bool freePosition(int[] q, int row)
            {
                for (int i = 0; i < row; i++) {

                    // verifico la misma fila
                    if (q[i] == q[row])
                    {
                        return false;

                    } else if (Math.Abs(q[i] - q[row]) == Math.Abs(i - row))
                    {
                        return false;
                    }
                }
                return true;
            }


            bool assignQueens(int[] q, int row)
            {
                if (row >= n)
                {
                    return true; // ya recorri todas las filas y columans
                }

                for (int col = 0; col < n; col++)
                {

                    q[row] = col;

                    if (freePosition(q, row))
                    {

                        if (assignQueens(q, row + 1))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }


            Console.ReadLine();
        }

        
    }
}
