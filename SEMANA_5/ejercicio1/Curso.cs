// Ejercicio 1:
// Escribir un programa que almacene las asignaturas de un curso
// (por ejemplo Sistemas operativos, Estructuras de datos, Metodolofias de la investigacion, Electricidad y Sistemas digitales)
// en una lista y la muestre por pantalla.

using System;
using System.Collections.Generic;

class Curso
{
    public List<string> Asignaturas { get; set; }

    public Curso()
    {
        Asignaturas = new List<string>
        {
            "Sistemas operativos",
            "Estructuras de datos",
            "Metodologías de la investigación",
            "Electricidad",
            "Sistemas digitales"
        };
    }

    public void MostrarAsignaturas()
    {
        foreach (string asignatura in Asignaturas)
        {
            Console.WriteLine(asignatura);
        }
    }
}
