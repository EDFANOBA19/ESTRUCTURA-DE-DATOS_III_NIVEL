using System;

namespace RegistroEstudiante
{
    // Clase que representa un estudiante con sus datos personales
    public class Estudiante
    {
        // Propiedades para encapsular los datos del estudiante
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        
        // Array de strings para almacenar hasta 3 números de teléfono
        // Se declara con tamaño fijo de 3 elementos [web:5]
        public string[] Telefonos { get; set; } = new string[3];

        // Constructor para inicializar el objeto
        public Estudiante(int id, string nombres, string apellidos, string direccion)
        {
            ID = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
        }

        // Método para mostrar todos los datos del estudiante formateados
        public void MostrarDatos()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                if (!string.IsNullOrEmpty(Telefonos[i]))
                    Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
            }
            Console.WriteLine("-------------------");
        }
    }
}
