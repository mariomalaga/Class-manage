using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;

namespace Practica5
{
    class BD
    {
        #region Constructor
        public BD()
        {
            
        }
        #endregion
        #region Métodos
        #region Insertar
        public void Insertar(Grupo grupo)
        {
            using (IObjectContainer bd = Db4oFactory.OpenFile("grupos.db"))
            {
                bd.Store(grupo);
                Console.WriteLine("Información guardada en la base de datos");
                bd.Close();
            }
        }
        #endregion
        #region LeerDatos
        public List<Grupo> LeerDatos()
        {
            List<Grupo> grupos = new List<Grupo>();
            using (IObjectContainer bd = Db4oFactory.OpenFile("grupos.db"))
            {
                IObjectSet result = bd.QueryByExample(new Grupo(null, 0, null));
                if (result.HasNext())
                {
                    while (result.HasNext())
                    {
                        Grupo next = (Grupo)result.Next();
                        Alumno alumno = next.Alumnos[next.Alumnos.Count - 1];
                        alumno.Contador = next.Alumnos.Count;
                        grupos.Add(next);
                        Console.WriteLine("Nombre del grupo: " + next.NombreGrupo);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No hay ningún grupo");
                    return null;
                }
                bd.Close();
            }
            return grupos;
        }
        #endregion
        #region BorrarGrupo
        public void BorrarGrupo(Grupo grupo)
        {
            using (IObjectContainer bd = Db4oFactory.OpenFile("grupos.db"))
            {
                IObjectSet result = bd.QueryByExample(new Grupo(null, 0, null));
                while (result.HasNext())
                {
                    Grupo next = (Grupo)result.Next();
                    if (next.NombreGrupo.Equals(grupo.NombreGrupo))
                    {
                        bool salir = false;
                        do
                        {
                            Console.WriteLine("\nEste grupo ya existe");
                            Console.WriteLine("¿Quiere sobreescribirlo? (s/n)");
                            string respuesta = Console.ReadLine();
                            if (respuesta.Equals("s"))
                            {
                                bd.Delete(next);
                                Console.WriteLine("Grupo sobreescrito");
                                salir = true;
                            }
                            else if (respuesta.Equals("n")){
                                string nombre = Auxiliar.LeerCadena("Introducir nuevo nombre para grupo: ", 5, 15);
                                grupo.NombreGrupo = nombre;
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Opción no válida");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Por favor introduzca 's' o 'n' \n");
                            }
                        }
                        while (salir == false);
                    }                   
                }
                bd.Close();
            }
        }
        #endregion
        #endregion
    }
}