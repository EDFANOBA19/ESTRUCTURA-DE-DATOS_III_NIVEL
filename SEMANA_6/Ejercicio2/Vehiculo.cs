using System;

namespace Ejercicio2_Vehiculos
{
    /// <summary>
    /// Clase que representa un vehículo del estacionamiento.
    /// Contiene todos los datos solicitados: placa, marca, modelo, año, precio.
    /// </summary>
    public class Vehiculo
    {
        public string Placa { get; set; }   // Identificador único
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public decimal Precio { get; set; }

        /// <summary>
        /// Constructor completo del vehículo.
        /// </summary>
        public Vehiculo(string placa, string marca, string modelo, int anio, decimal precio)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            Precio = precio;
        }

        /// <summary>
        /// Representación formateada del vehículo para mostrar en consola.
        /// </summary>
        public override string ToString()
        {
            return $"Placa: {Placa,-10} | Marca: {Marca,-12} | Modelo: {Modelo,-12} | Año: {Anio,-6} | Precio: ${Precio,10:N2}";
        }
    }
}
