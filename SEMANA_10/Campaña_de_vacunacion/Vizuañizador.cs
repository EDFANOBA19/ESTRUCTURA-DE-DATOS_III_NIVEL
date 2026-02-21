using System;
using System.Collections.Generic;
using System.Linq;

namespace CampañaVacunacion
{
    public static class Visualizador
    {
        public static void MostrarTitulo(string titulo)
        {
            Console.WriteLine($"\n=== {titulo} ===");
        }

        public static void MostrarResultados(HashSet<Ciudadano> conjunto, string titulo)
        {
            MostrarTitulo($"{titulo} (Total: {conjunto.Count})");

            if (conjunto.Count == 0)
            {
                Console.WriteLine("No hay ciudadanos en esta categoría.");
                return;
            }

            foreach (var ciudadano in conjunto.OrderBy(c => c.Id))
            {
                Console.WriteLine(ciudadano);
            }
        }

        public static void MostrarEstadisticas(Dictionary<string, int> estadisticas)
        {
            MostrarTitulo("ESTADÍSTICAS GENERALES");

            foreach (var stat in estadisticas)
            {
                Console.WriteLine($"{stat.Key,-30}: {stat.Value}");
            }
        }

        public static void MostrarVerificacion(bool esConsistente)
        {
            MostrarTitulo("VERIFICACIÓN DE CONSISTENCIA");

            if (esConsistente)
                Console.WriteLine("✓ Todos los ciudadanos están correctamente clasificados (Total = 500)");
            else
                Console.WriteLine("✗ Existe inconsistencia en los datos.");
        }
    }
}