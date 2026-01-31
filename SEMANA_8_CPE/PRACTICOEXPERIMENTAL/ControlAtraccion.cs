using System;
using System.Collections.Generic;

namespace GestionAtraccion
{
    public class ControlAtraccion
    {
        private Queue<Usuario> filaUsuarios;
        private int limite;
        private int turno;

        public ControlAtraccion(int capacidad)
        {
            filaUsuarios = new Queue<Usuario>();
            limite = capacidad;
            turno = 1;
        }

        public void AgregarUsuario(string nombre)
        {
            if (filaUsuarios.Count >= limite)
            {
                Console.WriteLine("No hay asientos disponibles.");
                return;
            }

            Usuario nuevo = new Usuario(nombre, turno);
            filaUsuarios.Enqueue(nuevo);
            turno++;

            Console.WriteLine("Usuario agregado correctamente.");
        }

        public void MostrarUsuarios()
        {
            if (filaUsuarios.Count == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
                return;
            }

            Console.WriteLine("\n--- USUARIOS CON ASIENTO ---");
            foreach (Usuario u in filaUsuarios)
            {
                Console.WriteLine(u);
            }
        }

        public void MostrarEstado()
        {
            Console.WriteLine($"Asientos ocupados: {filaUsuarios.Count}");
            Console.WriteLine($"Asientos disponibles: {limite - filaUsuarios.Count}");
        }
    }
}
