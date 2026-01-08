// Ejercicio 4:
// Escribir un programa que almacene en una lista los siguientes precios:
// 30, 78, 42, 28, 85, 95, 5
// y muestre por pantalla el menor y el mayor de los precios.

using System;
using System.Collections.Generic;
using System.Linq;

class Precios
{
    public List<int> ListaPrecios { get; set; }

    public Precios()
    {
        ListaPrecios = new List<int> { 30, 78, 42, 28, 85, 95, 5 };
    }

    public void MostrarMayorYMenor()
    {
        Console.WriteLine("Precio menor: " + ListaPrecios.Min());
        Console.WriteLine("Precio mayor: " + ListaPrecios.Max());
    }
}
