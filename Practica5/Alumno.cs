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
    class Alumno : IComparable<Alumno>
    {
        #region Atributos
        private int numMatricula;
        private string nombreAlumno;
        private List<float> notas;
        private static int contador;
        #endregion
        #region CompareTo
        public int CompareTo(Alumno alumno)
        {
            if (nombreAlumno.Equals(alumno.nombreAlumno))
            {
                return NumMatricula.CompareTo(alumno.NumMatricula);
            }
            return nombreAlumno.CompareTo(alumno.nombreAlumno);
        }
        #endregion
        #region Constructor
        public Alumno(string nombreAlumno, List<float> notas)
        {
            contador++;
            numMatricula = contador;
            this.nombreAlumno = nombreAlumno;
            this.notas = notas;
        }
        #endregion
        #region Métodos
        #region ImprimeAlumno
        public void ImprimeAlumno()
        {
            Console.WriteLine(""+ NumMatricula + nombreAlumno);
        }
        #endregion
        #region MediaAlumno
        public float MediaAlumno()
        {
            float suma = 0;
            for (int i = 0; i < notas.Count; i++)
            {
                suma = suma + notas[i];
            }
            return (suma / notas.Count);
        }
        #endregion
        #region NumSuspensos
        public int NumSuspensos()
        {
            int suspensos = 0;
            for (int i = 0; i < notas.Count; i++)
            {
                if (notas[i] < 5)
                {
                    suspensos++;
                }
            }
            return suspensos;
        }
        #endregion
        #endregion
        #region Propiedades
        public string NombreAlumno { get => nombreAlumno;}
        public List<float> Notas { get => notas; }
        public int NumMatricula { get => numMatricula;}
        public int Contador { get => contador; set => contador = value; }
        #endregion
    }
}
