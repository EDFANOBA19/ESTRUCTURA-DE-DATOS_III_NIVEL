using System;

namespace Ejercicio1_ListaNumeros
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "EJERCICIO 1 - Lista Enlazada 50 Números Aleatorios";
            
            // Crear la lista enlazada
            ListaEnlazada lista = new ListaEnlazada();
            
            // Generar EXACTAMENTE 50 números aleatorios del 1 al 999
            Random random = new Random();
            Console.WriteLine("EJERCICIO 1: LISTA ENLAZADA CON 50 NÚMEROS ALEATORIOS");
            Console.WriteLine("=====================================================");
            Console.WriteLine();

            for (int i = 0; i < 50; i++)
            {
                int numero = random.Next(1, 1000); // 1 <= numero <= 999
                lista.AgregarAlFinal(numero);
            }

            Console.WriteLine("LISTA ORIGINAL (50 números aleatorios del 1 al 999):");
            lista.Imprimir();
            Console.WriteLine();

            // Leer RANGO desde teclado
            Console.Write("Ingrese el valor MÍNIMO del rango: ");
            int minimo = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el valor MÁXIMO del rango: ");
            int maximo = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nEliminando números FUERA del rango [{minimo}, {maximo}]...");
            lista.EliminarFueraRango(minimo, maximo);

            Console.WriteLine("\nLISTA RESULTANTE (solo números DENTRO del rango):");
            lista.Imprimir();

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
