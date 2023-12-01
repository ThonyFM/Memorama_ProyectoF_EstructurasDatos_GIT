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
        protected static void VoltearCara(int c, int f, string[,] o, string[,] d)
        {
            if (o[f, c] == "*")
            {
                o[f, c] = d[f, c];
            }
            else
            {
                Console.WriteLine("\n**Cara ya volteada**");
            }
        }
        protected static void VoltearTapas(int c1, int f1, int c2, int f2, string[,] o, string[,] d)
        {
            Thread.Sleep(3000);
            d[f1, c1] = "*";
            d[f2, c2] = "*";
        }
        protected static void ComprobarParejas(string c1, string c2)
        {
            if (c1 == c2)
            {
                Console.WriteLine("Correcto!!!");
            }
            else
            {
                Console.WriteLine("Fallaste");
            }

        }
        protected static void Comodin(int c, int f, string[,] o, string[,] d, int turnos, int comodines, int op)
        {
            Random rnd = new Random();
            bool seguro;
            do
            {
                seguro = false;
                int co = rnd.Next(0, c);
                int fi = rnd.Next(0, f);

                if (o[fi, co] == "*")
                {
                    VoltearCara(co, fi, o, d);
                    Console.Clear();
                    for (int i = 0; i < f; i++)
                        GenerarTabla(f, c, o);
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
            for (int i = 0; i < filas; i++)
            {
                for (int z = 0; z < columnas; z++)
                {
                    Console.Write(carasO[i, z] + " ");
                }
                Console.WriteLine("");
            }
   

        }
    }
}
