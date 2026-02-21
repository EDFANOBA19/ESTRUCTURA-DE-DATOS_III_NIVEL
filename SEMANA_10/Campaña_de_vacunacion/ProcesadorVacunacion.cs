using System.Collections.Generic;
using System.Linq;

namespace CampañaVacunacion
{
    public class ProcesadorVacunacion
    {
        private HashSet<Ciudadano> _todosCiudadanos;
        private HashSet<Ciudadano> _vacunadosPfizer;
        private HashSet<Ciudadano> _vacunadosAstraZeneca;

        public HashSet<Ciudadano> NoVacunados { get; private set; }
        public HashSet<Ciudadano> AmbasDosis { get; private set; }
        public HashSet<Ciudadano> SoloPfizer { get; private set; }
        public HashSet<Ciudadano> SoloAstraZeneca { get; private set; }

        public ProcesadorVacunacion(
            HashSet<Ciudadano> todosCiudadanos,
            HashSet<Ciudadano> vacunadosPfizer,
            HashSet<Ciudadano> vacunadosAstraZeneca)
        {
            _todosCiudadanos = todosCiudadanos;
            _vacunadosPfizer = vacunadosPfizer;
            _vacunadosAstraZeneca = vacunadosAstraZeneca;

            ProcesarConjuntos();
        }

        private void ProcesarConjuntos()
        {
            // No vacunados
            NoVacunados = new HashSet<Ciudadano>(_todosCiudadanos);
            NoVacunados.ExceptWith(_vacunadosPfizer);
            NoVacunados.ExceptWith(_vacunadosAstraZeneca);

            // Ambas dosis
            AmbasDosis = new HashSet<Ciudadano>(_vacunadosPfizer);
            AmbasDosis.IntersectWith(_vacunadosAstraZeneca);

            // Solo Pfizer
            SoloPfizer = new HashSet<Ciudadano>(_vacunadosPfizer);
            SoloPfizer.ExceptWith(_vacunadosAstraZeneca);

            // Solo AstraZeneca
            SoloAstraZeneca = new HashSet<Ciudadano>(_vacunadosAstraZeneca);
            SoloAstraZeneca.ExceptWith(_vacunadosPfizer);
        }

        public Dictionary<string, int> ObtenerEstadisticas()
        {
            return new Dictionary<string, int>
            {
                ["Total Ciudadanos"] = _todosCiudadanos.Count,
                ["Vacunados Pfizer"] = _vacunadosPfizer.Count,
                ["Vacunados AstraZeneca"] = _vacunadosAstraZeneca.Count,
                ["Ambas Dosis"] = AmbasDosis.Count,
                ["Solo Pfizer"] = SoloPfizer.Count,
                ["Solo AstraZeneca"] = SoloAstraZeneca.Count,
                ["No Vacunados"] = NoVacunados.Count,
                ["Total Vacunados (1+ dosis)"] = _vacunadosPfizer.Union(_vacunadosAstraZeneca).Count()
            };
        }

        public bool VerificarConsistencia()
        {
            int totalProcesados =
                NoVacunados.Count +
                AmbasDosis.Count +
                SoloPfizer.Count +
                SoloAstraZeneca.Count;

            return totalProcesados == _todosCiudadanos.Count;
        }
    }
}