using System;

namespace Ejercicio1_ListaNumeros
{
    /// <summary>
    /// Nodo de una lista enlazada simple para enteros.
    /// </summary>
    public class Nodo
    {
        public int Dato { get; set; }      // Valor entero almacenado
        public Nodo Siguiente { get; set; } // Puntero al siguiente nodo

        /// <summary>
        /// Constructor del nodo.
        /// </summary>
        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}
