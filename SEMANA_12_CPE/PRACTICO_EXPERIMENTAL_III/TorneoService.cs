using System;
using System.Collections.Generic;
using TorneoFutbol.Models;
using TorneoFutbol.Utils;

namespace TorneoFutbol.Services
{
    /// <summary>
    /// Servicio que gestiona las operaciones del torneo
    /// </summary>
    public class TorneoService
    {
        // Diccionario de equipos (clave: nombre del equipo, valor: objeto Equipo)
        private Dictionary<string, Equipo> _equipos;

        public TorneoService()
        {
            // Inicializar con comparador que ignora mayúsculas/minúsculas
            _equipos = new Dictionary<string, Equipo>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Registra un nuevo equipo en el torneo
        /// </summary>
        public (bool exito, string mensaje) RegistrarEquipo(string nombreEquipo)
        {
            // Validar que el nombre no esté vacío
            if (!Validaciones.ValidarNombreNoVacio(nombreEquipo, out string nombreLimpio))
            {
                return (false, "El nombre del equipo no puede estar vacío.");
            }

            // Verificar si el equipo ya existe
            if (_equipos.ContainsKey(nombreLimpio))
            {
                return (false, "El equipo ya se encuentra registrado.");
            }

            // Crear y agregar el nuevo equipo
            Equipo nuevoEquipo = new Equipo(nombreLimpio);
            _equipos.Add(nombreLimpio, nuevoEquipo);

            return (true, $"Equipo '{nombreLimpio}' registrado correctamente.");
        }

        /// <summary>
        /// Agrega un jugador a un equipo existente
        /// </summary>
        public (bool exito, string mensaje) AgregarJugador(string nombreEquipo, string nombreJugador)
        {
            // Validar nombre del equipo
            if (!Validaciones.ValidarNombreNoVacio(nombreEquipo, out string equipoLimpio))
            {
                return (false, "El nombre del equipo no puede estar vacío.");
            }

            // Validar nombre del jugador
            if (!Validaciones.ValidarNombreNoVacio(nombreJugador, out string jugadorLimpio))
            {
                return (false, "El nombre del jugador no puede estar vacío.");
            }

            // Buscar el equipo
            if (!_equipos.TryGetValue(equipoLimpio, out Equipo equipo))
            {
                return (false, $"El equipo '{equipoLimpio}' no existe.");
            }

            // Agregar jugador al equipo
            if (equipo.AgregarJugador(jugadorLimpio))
            {
                return (true, $"Jugador '{jugadorLimpio}' agregado correctamente a {equipoLimpio}.");
            }
            else
            {
                return (false, $"El jugador '{jugadorLimpio}' ya pertenece al equipo {equipoLimpio}.");
            }
        }

        /// <summary>
        /// Obtiene todos los equipos registrados
        /// </summary>
        public Dictionary<string, Equipo> ObtenerTodosLosEquipos()
        {
            return _equipos;
        }

        /// <summary>
        /// Verifica si hay equipos registrados
        /// </summary>
        public bool HayEquiposRegistrados()
        {
            return _equipos.Count > 0;
        }

        /// <summary>
        /// Obtiene un equipo por su nombre
        /// </summary>
        public Equipo ObtenerEquipo(string nombreEquipo)
        {
            if (string.IsNullOrWhiteSpace(nombreEquipo))
                return null;

            _equipos.TryGetValue(nombreEquipo.Trim(), out Equipo equipo);
            return equipo;
        }

        /// <summary>
        /// Elimina un equipo del torneo
        /// </summary>
        public (bool exito, string mensaje) EliminarEquipo(string nombreEquipo)
        {
            if (!Validaciones.ValidarNombreNoVacio(nombreEquipo, out string equipoLimpio))
            {
                return (false, "El nombre del equipo no puede estar vacío.");
            }

            if (_equipos.Remove(equipoLimpio))
            {
                return (true, $"Equipo '{equipoLimpio}' eliminado correctamente.");
            }

            return (false, $"El equipo '{equipoLimpio}' no existe.");
        }
    }
}