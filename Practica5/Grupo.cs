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
    class Grupo
    {
        #region Atributos
        private string nombreGrupo;
        private int numAsignaturas;
        private List<string> codAsignaturas;
        private List<Alumno> alumnos;
        #endregion
        #region Constructor
        public Grupo(string nombreGrupo, int numAsignaturas, List<string> codAsignaturas)
        {
            this.NombreGrupo = nombreGrupo;
            this.numAsignaturas = numAsignaturas;
            this.codAsignaturas = codAsignaturas;
            alumnos = new List<Alumno>();
        }
        #endregion
        #region Métodos
        #region AnadirAlumno
        public void AnadirAlumno(Alumno alumno)
        {
            alumnos.Add(alumno);
        }
        #endregion
        #region LocalizaAlumno
        private int LocalizaAlumno(int numMatricula)
        {
            for (int i = 0; i < Alumnos.Count; i++)
            {
                if (alumnos[i].NumMatricula == numMatricula)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
        #region BuscaAlumno
        public Alumno BuscaAlumno(int numMatricula)
        {
            int numAlumno = LocalizaAlumno(numMatricula);
            if (numAlumno != -1)
            {
                return alumnos[numAlumno];
            }
            return null;
        }
        #endregion
        #region BorraAlumno
        public bool BorraAlumno(int numMatricula)
        {
            int numAlumno = LocalizaAlumno(numMatricula);
            if (numAlumno != -1)
            {
                alumnos.RemoveAt(numAlumno);
                return true;
            }
            return false;
        }
        #endregion
        #region MediaAsignatura
        public float MediaAsignatura(int indiceAsignatura)
        {
            float suma = 0;
            for (int i = 0; i < alumnos.Count; i++)
            {
                suma = suma + alumnos[i].Notas[indiceAsignatura];
            }
            return suma / alumnos.Count;
        }
        #endregion
        #region ActaGrupo
        public void ActaGrupo()
        {
            List<float> mediaNotas = new List<float>();
            int contador0 = 0;
            int contador1 = 0;
            int contador2 = 0;
            int contador3 = 0;
            alumnos.Sort();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ACTA DEL GRUPO "+ NombreGrupo +"\n");
            StringBuilder cabecera = new StringBuilder(); 
            cabecera.Append(String.Format("{0,-10}{1,-20}","MATRÍCULA","NOMBRE"));
            for (int i = 0; i < codAsignaturas.Count; i++)
            {
                cabecera.Append(String.Format("{0,-6}",codAsignaturas[i]));
            }
            cabecera.Append(String.Format("{0,-8}{1,-8}\n\n", "MEDIA", "NºSUS"));
            for (int i = 0; i < codAsignaturas.Count; i++)
            {
                mediaNotas.Add(0);
            }
            if(alumnos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("NO HAY ALUMNOS EN ESTE GRUPO\n");
            }
            else
            {
                for (int i = 0; i < alumnos.Count; i++)
                {
                    cabecera.Append(String.Format("{0,-10}{1,-20}", alumnos[i].NumMatricula, alumnos[i].NombreAlumno));
                    int contadorNotas = 0;
                    for (int j = 0; j < alumnos[i].Notas.Count; j++)
                    {
                        mediaNotas[j] = mediaNotas[j] + alumnos[i].Notas[j];
                        cabecera.Append(String.Format("{0,-6}", alumnos[i].Notas[j]));
                        if (alumnos[i].Notas[j] < 5)
                        {
                            contadorNotas++;
                        }
                    }
                    if (contadorNotas == 0)
                    {
                        contador0++;
                    }
                    else if (contadorNotas == 1)
                    {
                        contador1++;
                    }
                    else if (contadorNotas == 2)
                    {
                        contador2++;
                    }
                    else
                    {
                        contador3++;
                    }
                    float media = alumnos[i].MediaAlumno();
                    cabecera.Append(String.Format("{0,-8}", Math.Round(media, 2)));
                    int suspensos = alumnos[i].NumSuspensos();
                    cabecera.Append(String.Format("{0,-8}\n", suspensos));
                }
            }
            cabecera.Append(String.Format("\n{0,-30}","MEDIA"));
            for (int i = 0; i < mediaNotas.Count; i++)
            {
                float calcularMedia = mediaNotas[i] / alumnos.Count;
                cabecera.Append(String.Format("{0,-6}", Math.Round(calcularMedia, 2)));
            }
            Console.WriteLine(cabecera + "\n");
            Console.WriteLine("Nº de alumnos con 0 suspensos: "+ contador0);
            Console.WriteLine("Nº de alumnos con 1 suspenso: " + contador1);
            Console.WriteLine("Nº de alumnos con 2 suspensos: " + contador2);
            Console.WriteLine("Nº de alumnos con 3 o más suspensos: " + contador3);
        }
        #endregion
        #endregion
        #region Propiedades
        public int NumAsignaturas { get => numAsignaturas;}
        public List<string> CodAsignaturas { get => codAsignaturas;}
        internal List<Alumno> Alumnos { get => alumnos;}
        public string NombreGrupo { get => nombreGrupo; set => nombreGrupo = value; }
        #endregion
    }
}
