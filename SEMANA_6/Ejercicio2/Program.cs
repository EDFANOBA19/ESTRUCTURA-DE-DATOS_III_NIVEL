using System;

namespace Ejercicio2_Vehiculos
{
    class Program
    {
        static ListaVehiculos lista = new ListaVehiculos();

        static void Main(string[] args)
        {
            Console.Title = "EJERCICIO 2 - Registro Vehículos Estacionamiento";

            bool salir = false;
            while (!salir)
            {
                Menu();
                string opcion = Console.ReadLine();

                switch (opcion?.ToLower())
                {
                    case "a": Agregar(); break;
                    case "b": Buscar(); break;
                    case "c": PorAnio(); break;
                    case "d": lista.VerTodos(); Pausa(); break;
                    case "e": Eliminar(); break;
                    case "s": salir = true; break;
                    default: Console.WriteLine("Opción inválida."); Pausa(); break;
                }
            }
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("EJERCICIO 2: REGISTRO DE VEHÍCULOS");
            Console.WriteLine("==================================");
            Console.WriteLine("\na. Agregar vehículo");
            Console.WriteLine("b. Buscar por placa");
            Console.WriteLine("c. Ver por año");
            Console.WriteLine("d. Ver todos");
            Console.WriteLine("e. Eliminar vehículo");
            Console.WriteLine("s. Salir");
            Console.Write("\nOpción: ");
        }

        static void Agregar()
        {
            Console.Clear();
            Console.WriteLine("AGREGAR VEHÍCULO");
            Console.Write("Placa: "); string p = Console.ReadLine();
            Console.Write("Marca: "); string m = Console.ReadLine();
            Console.Write("Modelo: "); string mo = Console.ReadLine();
            Console.Write("Año: "); int a = int.Parse(Console.ReadLine());
            Console.Write("Precio: $"); decimal pre = decimal.Parse(Console.ReadLine());

            lista.AgregarVehiculo(new Vehiculo(p, m, mo, a, pre));
            Console.WriteLine("\n¡Agregado!");
            Pausa();
        }

        static void Buscar()
        {
            Console.Clear();
            Console.Write("Placa: "); string placa = Console.ReadLine();
            var v = lista.BuscarPorPlaca(placa);
            Console.WriteLine(v != null ? $"\n{v}" : "\nNo encontrado.");
            Pausa();
        }

        static void PorAnio()
        {
            Console.Clear();
            Console.Write("Año: "); int anio = int.Parse(Console.ReadLine());
            lista.VerPorAnio(anio);
            Pausa();
        }

        static void Eliminar()
        {
            Console.Clear();
            Console.Write("Placa: "); string placa = Console.ReadLine();
            Console.WriteLine(lista.EliminarPorPlaca(placa) ? "\n¡Eliminado!" : "\nNo encontrado.");
            Pausa();
        }

        static void Pausa() { Console.Write("\nPresione una tecla..."); Console.ReadKey(); }
    }
}
