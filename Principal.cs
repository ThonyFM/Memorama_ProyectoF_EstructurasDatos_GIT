using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memorama_ProyectoF_EstructurasDatos
{
    internal class Principal
    {
    
        public static string[,] GenerarTablero(int c, int f)
        {

            int contador;
            int tamanho = c * f;
            string[] lista = new string[tamanho];
            Random aleatorio = new Random();
            string a;
            string[,] orden = new string[f, c];
            char[,] oculto = new char[f, c];
            //Codigo
            contador = 0;
            //se Guardan los elementos necesarios 
            while (contador < tamanho)
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
            //for (int i = 0; i < tamanho; i++)
            //{
            //    Console.WriteLine(lista[i]);
            //}
            //string mensaje = "Hola ♠ Mundo!";
            //Console.WriteLine(mensaje);
            //se revuelven los elementos de la lista 

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
            //ahora se genera la matriz que va a ocultar las cartas
            for (int i = 0; i < f; i++)
            {
                for (int z = 0; z < c; z++)
                {
                    oculto[i, z] = '*';
                }
            }

       
            return orden;
        }


        static void Main(string[] args)
        {
            //Variables
            int columnas=0;
            int filas=0;
            bool seguro;
            
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Codigo
            Console.WriteLine("**********"); 
            Console.WriteLine("*Memorama*");
            Console.WriteLine("**********\n\n");
            Console.WriteLine("Para seleccionar el tamaño de las columnas y filas debe tomar en cuenta que:\n*Solo se puede dijita un numero par y mayor que 4*\n");
         
            do
            {
                try
                {
                    Console.WriteLine("\nDijite la cantidad de columas para el memorama");
                    filas = Convert.ToInt32(Console.ReadLine());
                    seguro = false;
                }
                catch (Exception ex)
                {
                    seguro = true;
                    Console.WriteLine("\n**Error: " + ex.Message + "**");
                    Console.WriteLine("\n**Solo se puede dijita un numero par y mayor que 4**");
                }
                if (!seguro)
                {
                    if (filas >= 4)
                    {
                        if (filas % 2 == 0) { }
                        else
                        {
                            seguro = true;
                            Console.WriteLine("\n**Solo se puede dijita un numero par**");
                        }
                    }
                    else
                    {
                        seguro = true;
                        Console.WriteLine("\n**Solo se puede dijita un numero mayor que 4**");
                    }
                }
            } while (seguro);

            do
            {
                try
                {
                    Console.WriteLine("\nDijite la cantidad de columas para el memorama");
                    columnas = Convert.ToInt32(Console.ReadLine());
                    seguro = false;
                }
                catch (Exception ex)
                {
                    seguro = true;
                    Console.WriteLine("\n**Error: " + ex.Message + "**");
                    Console.WriteLine("\n**Solo se puede dijita un numero par y mayor que 4**");
                }
                if (!seguro)
                {
                    if (columnas >= 4)
                    {
                        if (columnas % 2 == 0) { }
                        else
                        {
                            seguro = true;
                            Console.WriteLine("\n**Solo se puede dijita un numero par**");
                        }
                    }
                    else
                    {
                        seguro = true;
                        Console.WriteLine("\n**Solo se puede dijita un numero mayor que 4**");
                    }
                }
            } while (seguro);

            string[,] carasR = GenerarTablero(filas, columnas);

           
            for (int i = 0; i < filas; i++)
            {
                for (int z = 0; z < columnas; z++)
                {
                    Console.Write(carasR[i, z] + " ");

                }
                Console.WriteLine("");
            }

            Console.ReadKey();
        }
      

    }

}
//hola
