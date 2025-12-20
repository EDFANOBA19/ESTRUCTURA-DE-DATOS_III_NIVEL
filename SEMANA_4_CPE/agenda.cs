using System;

// Definimos una estructura (struct) para representar un contacto telefónico
// Las structs son tipos de valor ideales para datos simples y pequeños como este
public struct Contacto
{
    public string nombre;      // Campo para el nombre completo del contacto
    public string telefono;    // Campo para el número telefónico
    public string email;       // Campo opcional para el correo electrónico
    
    // Constructor de la struct para inicializar campos fácilmente
    public Contacto(string n, string tel, string em)
    {
        nombre = n;
        telefono = tel;
        email = em;
    }
    
    // Método ToString() sobrescrito para mostrar el contacto formateado
    public override string ToString()
    {
        return $"Nombre: {nombre}, Teléfono: {telefono}, Email: {email}";
    }
}
