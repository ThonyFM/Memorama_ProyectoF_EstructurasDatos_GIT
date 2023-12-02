using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memorama_ProyectoF_EstructurasDatos.Modelo
{
    internal class Juego
    {
        protected static string[,] GenerarMemorama(int c, int f)
        {

            int contador;
            int tamanho = c * f;
            string[] lista = new string[tamanho];
            Random aleatorio = new Random();
            string a;
            string[,] orden = new string[f, c];

            //Codigo
            contador = 0;
            //se Guardan los elementos necesarios 
            while (contador < tamanho)
            {
                try
                {
                    lista[contador] = ("♥");
                    contador++;
                    lista[contador] = ("♥");
                    contador++;
                    lista[contador] = ("♣");
                    contador++;
                    lista[contador] = ("♣");
                    contador++;
                    lista[contador] = ("♦");
                    contador++;
                    lista[contador] = ("♦");
                    contador++;
                    lista[contador] = ("♠");
                    contador++;
                    lista[contador] = ("♠");
                    contador++;
                }
                catch (Exception)
                {

                    break;
                }



            }
            for (int i = 0; i < tamanho; i++)
            {
                int r = aleatorio.Next(0, i + 1);

                a = lista[i];
                lista[i] = lista[r];
                lista[r] = a;
            }
            //ahora se agrega a una matriz de tamanho t1xt2 con el orden de las cartas listo
            contador = 0;
            for (int i = 0; i < f; i++)
            {
                for (int z = 0; z < c; z++)
                {
                    orden[i, z] = lista[contador];
                    contador++;

                }
            }
            return orden;
        }
        protected static string[,] GenerarMemoramaOculto(int c, int f)
        {
            string[,] oculto = new string[f, c];

            for (int i = 0; i < f; i++)
            {
                for (int z = 0; z < c; z++)
                {
                    oculto[i, z] = "*";
                }
            }

            return oculto;
        }
        protected static void VoltearCara(int columnas, int filas, int c, int f, string[,] o, string[,] d)
        {
            if (o[f, c] == ("*"))
            {
                o[f, c] = d[f, c];
                GenerarTabla(filas, columnas, o);
               
            }
        }
        protected static void VoltearTapas(int c1, int f1, int c2, int f2, string[,] o, string[,] d)
        {
            o[f1, c1] = "*";
            o[f2, c2] = "*";
        }
        protected static bool ComprobarParejas(string c1, string c2)
        {
            if (c1 == c2)
            {
                Console.WriteLine("Correcto!!!");
                Thread.Sleep(1000);
                return true;
            }
            else
            {
                Console.WriteLine("Fallaste");
                Thread.Sleep(1000);
                return false;
            }

        }
        protected static void Comodin(int c, int f, string[,] o, string[,] d, int turnos, int comodines, int op)
        {
            Random rnd = new Random();
            bool seguro;
            do
            {
                seguro = false;
                int co = rnd.Next(0, (c-1));
                int fi = rnd.Next(0, (f-1));

                if (o[fi, co] == "*")
                {
                    VoltearCara(c,f,co, fi, o, d);
                    Thread.Sleep(3000);
                    o[fi, co] = "*";
                    
                }
                else
                {
                    seguro = true;
                }
            } while (seguro);

        }
        protected static void GenerarTabla(int filas, int columnas, string[,] carasO)
        {
            bool seguro;
            Console.Clear();
            Console.Write("  ");
           
            for (int j = 1; j <= columnas; j++)
            {
                Console.Write($"{j} ");
            }
            Console.WriteLine();
            for (int i = 0; i < filas; i++)
            {
                Console.Write($"{i + 1} ");
                for (int z = 0; z < columnas; z++)
                {
                    Console.Write($"{carasO[i, z]} " );
                }
                Console.WriteLine("");
            }
   

        }
        static void MostrarTablero(int filas, int columnas, char[,] tablero, bool[,] cartasReveladas)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Console.WriteLine("Tablero:");
            Console.Write("  ");
            for (int j = 1; j <= columnas; j++)
            {
                Console.Write($"{j} ");
            }
            Console.WriteLine();

            for (int i = 0; i < filas; i++)
            {
                Console.Write($"{i + 1} ");
                for (int j = 0; j < columnas; j++)
                {
                    if (cartasReveladas[i, j])
                    {
                        Console.Write($"{tablero[i, j]} ");
                    }
                    else
                    {
                        Console.Write("* ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
