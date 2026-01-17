using System;

namespace Ejercicio2_Vehiculos
{
    /// <summary>
    /// Nodo de lista enlazada para objetos Vehiculo.
    /// </summary>
    public class Nodo
    {
        public Vehiculo Dato { get; set; }     // Vehículo almacenado
        public Nodo Siguiente { get; set; }    // Puntero al siguiente nodo

        /// <summary>
        /// Constructor del nodo.
        /// </summary>
        public Nodo(Vehiculo dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}
