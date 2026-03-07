using System;
using System.Collections.Generic;

namespace TorneoFutbol.Models
{
    /// <summary>
    /// Representa un equipo en el torneo
    /// </summary>
    public class Equipo
    {
        public string Nombre { get; set; }
        public HashSet<string> Jugadores { get; set; }

        public Equipo(string nombre)
        {
            Nombre = nombre;
            // HashSet con comparador ignorando mayúsculas/minúsculas
            Jugadores = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        public bool AgregarJugador(string nombreJugador)
        {
            if (string.IsNullOrWhiteSpace(nombreJugador))
                return false;
                
            return Jugadores.Add(nombreJugador.Trim());
        }

        public bool TieneJugadores()
        {
            return Jugadores.Count > 0;
        }

        public int CantidadJugadores()
        {
            return Jugadores.Count;
        }

        public override string ToString()
        {
            return $"Equipo: {Nombre} ({CantidadJugadores()} jugadores)";
        }
    }
}