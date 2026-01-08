// Ejercicio 5:
// Escribir un programa que almacene las asignaturas de un curso,
// junto con las notas obtenidas,
// y muestre únicamente las asignaturas que el estudiante debe repetir
// (notas menores a 6).

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
            { "Estructura de datos", 4.3 }, // Repite
            { "Sistemas operativos", 4.2 },      // Repite
            { "Sistemas digitales", 9.0 },
            { "Electricidad", 3.9 },    // Repite
            { "Metodologias de la investigacion", 7.5 }
        };
    }

    public void MostrarAsignaturasARepetir()
    {
        Console.WriteLine("Asignaturas que debe repetir el estudiante:");

        foreach (var item in AsignaturasConNotas)
        {
            if (item.Value < 6)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
