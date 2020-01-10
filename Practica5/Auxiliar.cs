/*
* PRÁCTICA.............: Práctica 5.
* NOMBRE Y APELLIDOS...: Mario Olivera Castañeda
* CURSO Y GRUPO........: 2o Desarrollo de Interfaces
* TÍTULO DE LA PRÁCTICA: Estructuras de Datos Internas y Manejo de Ficheros.
* FECHA DE ENTREGA.....: 19 de Noviembre de 2018
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica5
{
    class Auxiliar
    {
        #region Métodos
        #region LeerCadena
        public static string LeerCadena(string mensaje, int minimo, int maximo)
        {
            string introducir;
            bool correcto = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(mensaje);
                introducir = Console.ReadLine();
                if (introducir.Equals(""))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al dejar sin contestar");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Por favor conteste el apartado  \n");
                }
                else
                {
                    if (introducir.Length > maximo || introducir.Length < minimo)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error, valor introducido fuera de rango");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Por favor introduzca un valor entre " + minimo + " y " + maximo + " de caracteres \n");
                    }
                    else
                    {
                        correcto = true;
                    }
                }
            }
            while (!correcto);
            return introducir;
        }
        #endregion
        #region LeerEnteroPositivo
        public static int LeerEnteroPositivo(string mensaje, int minimo, int maximo)
        {
            bool salir = false;
            int comprobar;
            string introducir;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(mensaje);
                introducir = Console.ReadLine();
                if (!(int.TryParse(introducir, out comprobar)))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al introducir");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Por favor introduzca un número entero \n");
                }
                else
                {
                    if (int.Parse(introducir) > maximo || int.Parse(introducir) < minimo)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error, valor introducido fuera de rango");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Por favor introduzca un valor entre " + minimo + " y " + maximo + " \n");
                    }
                    else
                    {
                        salir = true;
                    }
                }
            }
            while (!salir);
            return int.Parse(introducir);
        }
        #endregion
        #region LeerFloat
        public static float LeerFloat(string mensaje, int minimo, int maximo)
        {
            bool salir = false;
            float comprobar;
            string introducir;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(mensaje);
                introducir = Console.ReadLine();
                if (!(float.TryParse(introducir, out comprobar)))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al introducir");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Por favor introduzca un número decimal \n");
                }
                else
                {
                    if (float.Parse(introducir) > maximo || float.Parse(introducir) < minimo)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error, valor introducido fuera de rango");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Por favor introduzca un valor entre " + minimo + " y " + maximo + " \n");
                    }
                    else
                    {
                        salir = true;
                    }
                }
            }
            while (!salir);
            return float.Parse(introducir);
        }
        #endregion
        #endregion
    }
}
