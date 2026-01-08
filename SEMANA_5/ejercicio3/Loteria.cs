// Ejercicio 3:
// Escribir un programa que almacene los números ganadores
// de la lotería primitiva en una lista
// y los muestre por pantalla ordenados de menor a mayor.

using System;
using System.Collections.Generic;

class Loteria
{
    public List<int> NumerosGanadores { get; set; }

    public Loteria()
    {
        // Números ganadores cargados directamente
        NumerosGanadores = new List<int> { 23, 5, 41, 12, 8, 30 };
    }

    public void MostrarNumerosOrdenados()
    {
        NumerosGanadores.Sort();

        Console.WriteLine("Números ganadores ordenados de menor a mayor:");
        foreach (int numero in NumerosGanadores)
        {
            Console.Write(numero + " ");
        }
    }
}
