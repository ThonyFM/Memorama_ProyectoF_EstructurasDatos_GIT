using Memorama_ProyectoF_EstructurasDatos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memorama_ProyectoF_EstructurasDatos
{
    internal class Principal:Juego
    {
    
        static void Main(string[] args)
        {
    
            //Variables
            int columnas=0;
            int filas=0;
            bool seguro;
            int parejas;
            int contador;
            int turnos, turnosU;
            int comodines;
            int f1, f2, c1, c2;
            int op=0;
            bool victoria;



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
                    Console.WriteLine("\nDijite la cantidad de filas para el memorama");
                    filas = Convert.ToInt32(Console.ReadLine());
                    seguro = false;
                }
                catch (Exception ex)
                {
                    seguro = true;
                    Console.WriteLine("\n**Error: " + ex.Message + "**");
                    Console.WriteLine("\n**Solo se puede dijitar un numero par y mayor que 4**");
                }
                if (!seguro)
                {
                    if (filas >= 4)
                    {
                        if (filas % 2 == 0) { }
                        else
                        {
                            seguro = true;
                            Console.WriteLine("\n**Solo se puede dijitar un numero par**");
                        }
                    }
                    else
                    {
                        seguro = true;
                        Console.WriteLine("\n**Solo se puede dijitar un numero mayor que 4**");
                    }
                }
            } while (seguro);

            do
            {
                try
                {
                    Console.WriteLine("\nDijite la cantidad de columnas para el memorama");
                    columnas = Convert.ToInt32(Console.ReadLine());
                    seguro = false;
                }
                catch (Exception ex)
                {
                    seguro = true;
                    Console.WriteLine("\n**Error: " + ex.Message + "**");
                    Console.WriteLine("\n**Solo se puede dijitar un numero par y mayor que 4**");
                }
                if (!seguro)
                {
                    if (columnas >= 4)
                    {
                        if (columnas % 2 == 0) { }
                        else
                        {
                            seguro = true;
                            Console.WriteLine("\n**Solo se puede dijitar un numero par**");
                        }
                    }
                    else
                    {
                        seguro = true;
                        Console.WriteLine("\n**Solo se puede dijitar un numero mayor que 4**");
                    }
                }
            } while (seguro);

            string[,] carasR = GenerarMemorama(filas, columnas);
            string[,] carasO = GenerarMemoramaOculto(filas, columnas);
            parejas = (filas * columnas) / 2;
            turnos= (filas * columnas) * 2;
            contador =0;
            turnosU = 0;
            comodines = 3;
            victoria = true;
            do
            {
                if (turnos> turnosU)
                {
                    
                    do
                    {
                        try
                        {

                            Console.Clear();
                            GenerarTabla(filas, columnas, carasO);
                            Console.WriteLine("\n1.Turnos disoponibles: " + turnos + "\n2.Comodines Disponibles: " + comodines);
                            Console.WriteLine("\n\n1.Ingresar cordenas\n2.Usar comidin");
                            op = Convert.ToInt32(Console.ReadLine());
                            seguro = false;
                        }
                        catch (Exception ex)
                        {
                            seguro = true;
                            Console.WriteLine("\n**Error: " + ex.Message + "**");
                            Console.WriteLine("\n**Dijite el numero de la opcion**");
                        }
               
                 
                        if (!seguro)
                        {
                                switch (op)
                                {
                                    case 1:

                                        break;
                                    case 2:
                                    if (comodines>0)
                                    {
                                        turnos--;
                                        turnosU++;
                                        comodines--;
                                        Comodin(columnas, filas, carasO, carasR,turnos,comodines,op);

                                    }
                                    else
                                    {
                                        Console.WriteLine("\n**Sin turnos disponibles**");
                                        Thread.Sleep(2000);
                                    }

                                        break;
                                    default:

                                   
                                    Console.WriteLine("\n**Dijite una opcion valida**");
                                    seguro = true;
                                    break;
                                }
                            }
                         
                        
                    } while (seguro);
                }
                else
                {
                    contador = parejas;
                    victoria = false;
                }
            } while (parejas>contador);
            Console.ReadKey();
        }
      

    }

}
//hola
