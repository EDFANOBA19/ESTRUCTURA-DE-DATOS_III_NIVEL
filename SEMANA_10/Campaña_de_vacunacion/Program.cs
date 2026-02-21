using System;

namespace CampañaVacunacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SISTEMA DE VACUNACIÓN COVID-19");
            Console.WriteLine("--------------------------------");

            // Generar 500 ciudadanos
            var todosCiudadanos = GeneradorDatos.GenerarTodosCiudadanos(500);

            // 1–75 Pfizer
            var vacunadosPfizer = GeneradorDatos.ObtenerRangoVacunados(todosCiudadanos, 1, 75);

            // 51–125 AstraZeneca (25 tendrán ambas dosis)
            var vacunadosAstraZeneca = GeneradorDatos.ObtenerRangoVacunados(todosCiudadanos, 51, 125);

            // Procesar conjuntos
            var procesador = new ProcesadorVacunacion(
                todosCiudadanos,
                vacunadosPfizer,
                vacunadosAstraZeneca);

            // Mostrar listados solicitados
            Visualizador.MostrarResultados(procesador.NoVacunados, "CIUDADANOS NO VACUNADOS");
            Visualizador.MostrarResultados(procesador.AmbasDosis, "CIUDADANOS CON AMBAS DOSIS");
            Visualizador.MostrarResultados(procesador.SoloPfizer, "CIUDADANOS SOLO PFIZER");
            Visualizador.MostrarResultados(procesador.SoloAstraZeneca, "CIUDADANOS SOLO ASTRAZENECA");

            // Mostrar estadísticas completas
            Visualizador.MostrarEstadisticas(procesador.ObtenerEstadisticas());

            // Verificar consistencia
            Visualizador.MostrarVerificacion(procesador.VerificarConsistencia());

            Console.WriteLine("\nProceso finalizado correctamente.");
            Console.ReadKey();
        }
    }
}