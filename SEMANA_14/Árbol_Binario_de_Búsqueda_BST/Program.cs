using System;

namespace BST_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Árbol Binario de Búsqueda (BST)";
            Console.ForegroundColor = ConsoleColor.Cyan;

            Menu menu = new Menu();
            menu.MostrarMenuPrincipal();
        }
    }
}