using System;

namespace RegistroEstudiante
{
    class Program
    {
        static void Main(string[] args)
        {
            // Datos del estudiante pre-ingresados [web:15]
            Estudiante estudiante = new Estudiante(
                20208310,           // ID: 0202128310 (sin ceros iniciales para int)
                "EDWIN FABIAN",     // NOMBRES
                "NORIEGA BALDEON",  // APELLIDOS
                "Provincia Bolívar, cantón san miguel, parroquia Bilovan, sector guapoloma"  // DIRECCION
            );
            
            // Array de teléfonos pre-cargados
            estudiante.Telefonos[0] = "0990937513";
            estudiante.Telefonos[1] = "0981255577";
            estudiante.Telefonos[2] = "0999777257";
            
            // Mostrar los datos registrados
            Console.WriteLine("\n=== REGISTRO DEL ESTUDIANTE ===");
            estudiante.MostrarDatos();
            
            Console.WriteLine("Datos guardados exitosamente.");
            Console.WriteLine("Presione Enter para salir...");
            Console.ReadLine();
        }
    }
}
