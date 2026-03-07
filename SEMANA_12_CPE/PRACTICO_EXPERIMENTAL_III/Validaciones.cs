using System;

namespace TorneoFutbol.Utils
{
    /// <summary>
    /// Clase con métodos de validación reutilizables
    /// </summary>
    public static class Validaciones
    {
        /// <summary>
        /// Valida que un nombre no esté vacío y lo limpia
        /// </summary>
        public static bool ValidarNombreNoVacio(string entrada, out string nombreLimpio)
        {
            nombreLimpio = (entrada ?? "").Trim();

            if (string.IsNullOrWhiteSpace(nombreLimpio))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida que un número esté dentro de un rango
        /// </summary>
        public static bool ValidarOpcionMenu(string entrada, out int opcion, int min, int max)
        {
            opcion = -1;

            if (!int.TryParse(entrada, out opcion))
            {
                return false;
            }

            return opcion >= min && opcion <= max;
        }

        /// <summary>
        /// Muestra un mensaje de error en color rojo
        /// </summary>
        public static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ {mensaje}");
            Console.ResetColor();
        }

        /// <summary>
        /// Muestra un mensaje de éxito en color verde
        /// </summary>
        public static void MostrarExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✅ {mensaje}");
            Console.ResetColor();
        }

        /// <summary>
        /// Muestra un mensaje informativo en color amarillo
        /// </summary>
        public static void MostrarInfo(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"ℹ️ {mensaje}");
            Console.ResetColor();
        }
    }
}