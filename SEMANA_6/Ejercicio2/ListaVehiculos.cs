using System;

namespace Ejercicio2_Vehiculos
{
    /// <summary>
    /// Lista enlazada de vehículos con TODAS las operaciones solicitadas:
    /// a. Agregar vehículo
    /// b. Buscar vehículo por placa
    /// c. Ver vehículo por año
    /// d. Ver todos los vehículos
    /// e. Eliminar vehículo registrado
    /// </summary>
    public class ListaVehiculos
    {
        public Nodo Cabeza { get; private set; }

        public ListaVehiculos()
        {
            Cabeza = null;
        }

        // a. AGREGAR VEHÍCULO
        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            Nodo nuevo = new Nodo(vehiculo);
            if (Cabeza == null)
            {
                Cabeza = nuevo;
                return;
            }
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }

        // b. BUSCAR POR PLACA
        public Vehiculo BuscarPorPlaca(string placa)
        {
            Nodo actual = Cabeza;
            while (actual != null)
            {
                if (string.Equals(actual.Dato.Placa, placa, StringComparison.OrdinalIgnoreCase))
                {
                    return actual.Dato;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        // c. VER POR AÑO
        public void VerPorAnio(int anio)
        {
            Nodo actual = Cabeza;
            bool encontrado = false;
            Console.WriteLine($"\nVehículos del año {anio}:");
            Console.WriteLine(new string('=', 80));

            while (actual != null)
            {
                if (actual.Dato.Anio == anio)
                {
                    Console.WriteLine(actual.Dato);
                    encontrado = true;
                }
                actual = actual.Siguiente;
            }

            if (!encontrado)
                Console.WriteLine("No hay vehículos de ese año.");
        }

        // d. VER TODOS
        public void VerTodos()
        {
            Console.WriteLine("\nTODOS LOS VEHÍCULOS REGISTRADOS:");
            Console.WriteLine(new string('=', 80));
            Nodo actual = Cabeza;
            if (actual == null)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }
            while (actual != null)
            {
                Console.WriteLine(actual.Dato);
                actual = actual.Siguiente;
            }
        }

        // e. ELIMINAR POR PLACA
        public bool EliminarPorPlaca(string placa)
        {
            if (Cabeza == null) return false;

            // Eliminar cabeza
            if (string.Equals(Cabeza.Dato.Placa, placa, StringComparison.OrdinalIgnoreCase))
            {
                Cabeza = Cabeza.Siguiente;
                return true;
            }

            // Buscar en el resto
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                if (string.Equals(actual.Siguiente.Dato.Placa, placa, StringComparison.OrdinalIgnoreCase))
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }
    }
}
