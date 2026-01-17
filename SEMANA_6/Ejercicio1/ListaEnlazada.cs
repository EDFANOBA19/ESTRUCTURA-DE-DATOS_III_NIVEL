using System;

namespace Ejercicio1_ListaNumeros
{
    /// <summary>
    /// Lista enlazada simple de números enteros.
    /// Implementa las operaciones requeridas por el ejercicio.
    /// </summary>
    public class ListaEnlazada
    {
        public Nodo Cabeza { get; private set; } // Primer nodo de la lista

        public ListaEnlazada()
        {
            Cabeza = null;
        }

        /// <summary>
        /// Agrega un nuevo nodo al FINAL de la lista.
        /// </summary>
        public void AgregarAlFinal(int dato)
        {
            Nodo nuevo = new Nodo(dato);

            // Caso 1: Lista vacía
            if (Cabeza == null)
            {
                Cabeza = nuevo;
                return;
            }

            // Caso 2: Lista con elementos - buscar el último
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }

        /// <summary>
        /// Elimina TODOS los nodos cuyo valor esté FUERA del rango [minimo, maximo].
        /// </summary>
        public void EliminarFueraRango(int minimo, int maximo)
        {
            // Paso 1: Eliminar desde la CABEZA mientras cumpla la condición
            while (Cabeza != null && (Cabeza.Dato < minimo || Cabeza.Dato > maximo))
            {
                Cabeza = Cabeza.Siguiente;
            }

            // Paso 2: Si la lista quedó vacía, terminar
            if (Cabeza == null)
                return;

            // Paso 3: Eliminar en el resto de la lista
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato < minimo || actual.Siguiente.Dato > maximo)
                {
                    // Saltar el nodo no deseado
                    actual.Siguiente = actual.Siguiente.Siguiente;
                }
                else
                {
                    // Avanzar al siguiente nodo válido
                    actual = actual.Siguiente;
                }
            }
        }

        /// <summary>
        /// Imprime todos los valores de la lista en consola.
        /// </summary>
        public void Imprimir()
        {
            Nodo actual = Cabeza;
            if (actual == null)
            {
                Console.WriteLine("La lista está VACÍA.");
                return;
            }

            Console.Write("Elementos: ");
            while (actual != null)
            {
                Console.Write(actual.Dato + " ");
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }
    }
}
