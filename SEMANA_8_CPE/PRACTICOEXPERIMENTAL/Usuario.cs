using System;

namespace GestionAtraccion
{
    public class Usuario
    {
        public string Nombre { get; private set; }
        public int Turno { get; private set; }

        public Usuario(string nombre, int turno)
        {
            Nombre = nombre;
            Turno = turno;
        }

        public override string ToString()
        {
            return $"Usuario: {Nombre}, Turno: {Turno}";
        }
    }
}
