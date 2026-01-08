// Ejercicio 2:
// Escribir un programa que almacene las asignaturas de un curso,
// junto con las notas obtenidas en cada una,
// y las muestre por pantalla con el mensaje:
// "En <asignatura> has sacado <nota>".

using System;
using System.Collections.Generic;

class Curso
{
    public Dictionary<string, double> AsignaturasConNotas { get; set; }

    public Curso()
    {
        // Asignaturas y notas cargadas directamente
        AsignaturasConNotas = new Dictionary<string, double>
        {
            { "Sistemas operativos", 9.0 },
            { "Matemática I", 5.0 },
            { "Fisica I", 7.8 },
            { "Metodologias de la investigacion", 9.8 },
            { "electricidad", 7.0 }
        };
    }

    public void MostrarNotas()
    {
        foreach (var item in AsignaturasConNotas)
        {
            Console.WriteLine($"En {item.Key} has sacado {item.Value}");
        }
    }
}
