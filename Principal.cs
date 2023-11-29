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
        static void Main(string[] args)
        {
            //Variables
            int columnas=0;
            int filas=0;
            bool seguro;

            Timer timer;



            //Codigo
            Console.WriteLine("**********"); 
            Console.WriteLine("*Memorama*");
            Console.WriteLine("**********\n\n");

            Console.WriteLine("Para seleccionar el tamaño de las columnas y filas debe tomar en cuenta que:\n*Solo se puede dijita un numero par y mayor que 4*\n\n");
            do
            {
                try
                {
                    Console.WriteLine("Dijite la cantidad de columas para el memorama");
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
                    if (columnas >= 4 )
                    {
                            if (columnas % 2 == 0){}
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
                    Console.WriteLine("Dijite la cantidad de filas para el memorama");
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
                    if (filas < 4)
                    {
                        seguro = true;
                    }
                }
            } while (seguro);

   

            Console.ReadKey();
        }
    }
}
//hola
