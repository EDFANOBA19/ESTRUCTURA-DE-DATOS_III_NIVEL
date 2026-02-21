namespace CampañaVacunacion
{
    public class Ciudadano
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public Ciudadano(string id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return $"{Nombre} (ID: {Id})";
        }

        public override bool Equals(object obj)
        {
            if (obj is Ciudadano otro)
                return this.Id == otro.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}