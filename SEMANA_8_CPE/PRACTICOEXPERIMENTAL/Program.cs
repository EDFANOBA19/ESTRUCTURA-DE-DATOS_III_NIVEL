using System;

namespace GestionAtraccion
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlAtraccion control = new ControlAtraccion(5);
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN ATRACCIÓN ===");
                Console.WriteLine("1. Agregar usuario");
                Console.WriteLine("2. Ver usuarios");
                Console.WriteLine("3. Ver estado");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre: ");
                        control.AgregarUsuario(Console.ReadLine());
                        break;
                    case "2":
                        control.MostrarUsuarios();
                        Console.ReadKey();
                        break;
                    case "3":
                        control.MostrarEstado();
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("¡Adiós!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != "4");
        }
    }
}
