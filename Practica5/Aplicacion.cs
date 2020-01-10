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
    class Aplicacion
    {
        #region Main
        static void Main(string[] args)
        {
            Menu();
        }
        #endregion
        #region Menu
        static void Menu()
        {
            string casos = "";
            Grupo grupo = null;
            while (casos != "8")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("GESTIÓN DEL GRUPO ");
                Console.WriteLine("1.Añadir alumno");
                Console.WriteLine("2.Borrar alumno");
                Console.WriteLine("3.Consulta alumno");
                Console.WriteLine("4.Acta del grupo");
                Console.WriteLine("5.Guardar información");
                Console.WriteLine("6.Recuperar información");
                Console.WriteLine("7.Crear grupo");
                Console.WriteLine("8.Salir");
                Console.Write("Teclee opción: ");
                casos = Console.ReadLine();
                int numMatricula;
                BD bd = new BD();
                switch (casos)
                {
                    case "1":
                        if (grupo == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Realizar punto 6 o 7 antes");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Pulse 'Enter' para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Alumno alumno = CreaAlumno(grupo);
                            grupo.AnadirAlumno(alumno);
                        }
                        break;
                    case "2":
                        if (grupo == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Realizar punto 6 o 7 antes");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Pulse 'Enter' para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            numMatricula = Auxiliar.LeerEnteroPositivo("Teclee la matrícula del alumno a borrar: ", 1, 20);
                            bool pregunta = false;
                            do
                            {
                                string preguntar = Auxiliar.LeerCadena("¿Seguro que quiere borrar? (Escribir 's' o 'n'): ", 1, 1);
                                if (preguntar.Equals("s"))
                                {
                                    bool borrar = grupo.BorraAlumno(numMatricula);
                                    if (borrar == true)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Alumno borrado correctamente");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("No se ha encontrado al alumno");
                                    }
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Pulse 'Enter' para continuar...");
                                    Console.ReadLine();
                                    pregunta = !pregunta;
                                }
                                else if (preguntar.Equals("n"))
                                {
                                    pregunta = !pregunta;
                                    Console.WriteLine("Pulse 'Enter' para continuar...");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error al introducir");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Por favor introduzca 's' o 'n' \n");
                                }
                            }
                            while (!pregunta);
                        }
                        break;
                    case "3":
                        if (grupo == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Realizar punto 6 o 7 antes");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Pulse 'Enter' para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            numMatricula = Auxiliar.LeerEnteroPositivo("Teclee la matrícula del alumno a consultar: ", 1, 20);
                            Alumno buscarAlumno = grupo.BuscaAlumno(numMatricula);
                            if (buscarAlumno == null)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Alumno no encontrado");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Pulse 'Enter' para continuar...");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(buscarAlumno.NumMatricula + " " + buscarAlumno.NombreAlumno);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Pulse 'Enter' para continuar...");
                                Console.ReadLine();
                            }
                        } 
                        break;
                    case "4":
                        if (grupo == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("No hay datos\n");
                            Console.WriteLine("Realizar punto 6 o 7 antes");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Pulse 'Enter' para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            grupo.ActaGrupo();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Pulse 'Enter' para continuar...");
                            Console.ReadLine();
                        }   
                        break;
                    case "5":
                        if (grupo == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Realizar punto 6 o 7 antes");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Pulse 'Enter' para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            bd.BorrarGrupo(grupo);
                            bd.Insertar(grupo);
                            Console.WriteLine("Pulse 'Enter' para continuar...");
                            Console.ReadLine();
                        }   
                        break;
                    case "6":
                        List<Grupo> grupos = bd.LeerDatos();
                        if (grupos == null)
                        {
                            Console.WriteLine("Pulse 'Enter' para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            bool eleccionGrupo = false;
                            do
                            {
                                string elegirGrupo = Auxiliar.LeerCadena("Elija grupo: ", 5, 15);
                                for (int i = 0; i < grupos.Count; i++)
                                {
                                    if (elegirGrupo.Equals(grupos[i].NombreGrupo))
                                    {
                                        eleccionGrupo = !eleccionGrupo;
                                        grupo = grupos[i];
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Se han recuperado los datos del grupo " + grupo.NombreGrupo);
                                    }
                                }
                                if (!eleccionGrupo)
                                {
                                    eleccionGrupo = !eleccionGrupo;
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("No se ha encontrado al grupo");
                                }
                            }
                            while (!eleccionGrupo);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Pulse 'Enter' para continuar...");
                            Console.ReadLine();
                        }
                        break;
                    case "7":
                        grupo = CreaGrupo();
                        break;
                    case "8":
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción no válida");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Por favor introduzca una opción válida \n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Pulse 'Enter' para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        #endregion
        #region Métodos
        #region CrearGrupo
        static Grupo CreaGrupo()
        {
            string nombreGrupo = Auxiliar.LeerCadena("Nombre del grupo a gestionar....: ", 5, 15);
            int numeroAsignaturas = Auxiliar.LeerEnteroPositivo("Número de asignaturas [4 - 7]: ", 4, 7);
            Console.WriteLine("Teclee los códigos (3 caracteres) de las 5 asignaturas");
            List<string> asignaturas = new List<string>();
            for (int i = 0; i < numeroAsignaturas; i++)
            {
                string asignatura = Auxiliar.LeerCadena("Asignatura "+ (i+1) +": ", 3, 3);
                asignaturas.Add(asignatura);
            }
            Grupo grupo = new Grupo(nombreGrupo, numeroAsignaturas, asignaturas);
            Console.WriteLine("Pulse 'Enter' para continuar...");
            Console.ReadLine();
            return grupo;
        }
        #endregion
        #region CrearAlumno
        static Alumno CreaAlumno(Grupo grupo)
        {
            string nombreAlumno = Auxiliar.LeerCadena("Nombre alumno...: ", 5, 20);
            List<float> notas = new List<float>();
            for (int i = 0; i < grupo.NumAsignaturas; i++)
            {
                float nota = Auxiliar.LeerFloat("Nota "+ grupo.CodAsignaturas[i] +": ", 1, 10);
                notas.Add(nota);
            }
            Alumno alumno = new Alumno(nombreAlumno, notas);
            Console.WriteLine("Alumno añadido.");
            Console.WriteLine("Pulse 'Enter' para continuar...");
            Console.ReadLine();
            return alumno;
        }
        #endregion
        #endregion
    }
}
