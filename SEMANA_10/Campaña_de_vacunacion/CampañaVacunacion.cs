using System.Collections.Generic;
using System.Linq;

namespace CampañaVacunacion
{
    public static class GeneradorDatos
    {
        public static HashSet<Ciudadano> GenerarTodosCiudadanos(int cantidad)
        {
            var ciudadanos = new HashSet<Ciudadano>();

            for (int i = 1; i <= cantidad; i++)
            {
                ciudadanos.Add(new Ciudadano($"CID-{i:000}", $"Ciudadano {i}"));
            }

            return ciudadanos;
        }

        public static HashSet<Ciudadano> ObtenerRangoVacunados(
            HashSet<Ciudadano> todos,
            int inicio,
            int fin)
        {
            return todos
                .Where(c =>
                {
                    int numero = int.Parse(c.Id.Split('-')[1]);
                    return numero >= inicio && numero <= fin;
                })
                .ToHashSet();
        }
    }
}