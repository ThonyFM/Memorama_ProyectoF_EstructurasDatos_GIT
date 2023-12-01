using Memorama_ProyectoF_EstructurasDatos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

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
            int parejasA=0;
            int contador;
            int turnos, turnosU;
            int comodines;
            int f1 = 0;
            int f2 = 0;
            int c1 = 0;
            int c2 = 0;
            int op=0;
            string carta1;
            string carta2;
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
            comodines = 4;
            do
            {
                if (turnos> turnosU)
                {
                    
                    do
                    {
                        try
                        {
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
                                    do
                                    {
                                        try
                                        {
                                            Console.WriteLine("\nDigite las cordenadas de la primer carta a voltear en el formato 'fila,columna'");
                                            string entrada = Console.ReadLine();
                                            string[] partes = entrada.Split(',');
                                            f1 = Convert.ToInt32(partes[0]);
                                            c1 = Convert.ToInt32(partes[1]);
                                            f1--;
                                            c1--;
                                            seguro = false;
                                        }
                                        catch (Exception ex)
                                        {
                                            seguro = true;
                                            Console.WriteLine("\n**Error: " + ex.Message + "**");
                                            Thread.Sleep(2000);
                                            GenerarTabla(filas, columnas, carasO);
                                        }
                                        if (f1<filas&&c2<columnas)
                                        {
                                            VoltearCara(columnas, filas, c1, f1, carasO, carasR, seguro);
                                            if (seguro == true)
                                            {
                                                Console.WriteLine("\n**Esta carta ya esta volteada**");
                                                Thread.Sleep(2000);
                                                GenerarTabla(filas, columnas, carasO);
                                            }
                                        }
                                        else
                                        {
                                            seguro = true;
                                            Console.WriteLine("\n**Coordenada Invalida**");
                                            Thread.Sleep(2000);
                                            GenerarTabla(filas, columnas, carasO);
                                        }
                                   
                                    } while (seguro);
                                    do
                                    {
                                        try
                                        {
                                            Console.WriteLine("\nDigite las cordenadas de la segunda carta a voltear en el formato 'fila,columna'");
                                            string entrada = Console.ReadLine();
                                            string[] partes = entrada.Split(',');
                                            f2 = Convert.ToInt32(partes[0]);
                                            c2 = Convert.ToInt32(partes[1]);
                                            f2--;
                                            c2--;
                                            seguro = false;
                                        }
                                        catch (Exception ex)
                                        {
                                            seguro = true;
                                            Console.WriteLine("\n**Error: " + ex.Message + "**");
                                            Thread.Sleep(2000);
                                            GenerarTabla(filas, columnas, carasO);
                                        }
                                        if (!seguro)
                                        {
                                           
                                            if (f1==f2&& c1==c2)
                                            {
                                                seguro = true;
                                                Console.WriteLine("\n**No se pueden dijitar las mismas coordenadas en ambas cartas**");
                                                Thread.Sleep(2000);
                                                GenerarTabla(filas, columnas, carasO);
                                            }
                                            VoltearCara(columnas,filas,c2, f2, carasO, carasR, seguro);
                                            if(seguro==true)
                                            {
                                                Console.WriteLine("\n**Esta carta ya esta volteada**");
                                                Thread.Sleep(2000);
                                                GenerarTabla(filas, columnas, carasO);
                                            }
                                        }
                                    } while (seguro);
                                    carta1 = carasR[f1, c1];
                                    carta2 = carasR[f2, c2];
                                    if (ComprobarParejas(carta1, carta2))
                                    {
                                        turnos--;
                                        turnosU++;
                                        parejasA++;;
                                    }
                                    else
                                    {
                                        turnos--;
                                        turnosU++;
                                        VoltearTapas(c1, f1, c2, f2, carasO, carasR);
                                    }
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
                }
            } while (parejas>contador);

            if (parejas == parejasA)
            {
                GenerarTabla(filas, columnas, carasO);
                Console.WriteLine("\nGanaste");
                Console.WriteLine("\nEstadisticas:" +
                    "\nTurnos usados: "+turnosU+"/"+(turnos+turnosU)+
                    "\nAciertos: "+ parejasA+"/"+parejas);
            }
            else
            {
                Console.WriteLine("\nPerdiste");
            }
            Console.ReadKey();
        }
    }
}
//hola
