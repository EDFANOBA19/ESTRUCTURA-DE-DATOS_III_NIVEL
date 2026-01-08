using System;

// ESTRUCTURA (struct) para representar un contacto telefónico
// Las structs son tipos de valor ideales para datos simples y pequeños como contactos
// Cumple con requisitos de la guía: "registros y estructuras" hasta semana 4 [file:1]
public struct Contacto
{
    // Propiedades automáticas con get/set (mejor práctica que campos públicos)
    // Elimina warnings CS8618 "Non-nullable property must contain a non-null value"
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    
    // Constructor de la struct para inicializar propiedades fácilmente
    // Usa ?? para evitar null y warnings CS8625
    public Contacto(string nombre, string telefono, string email)
    {
        Nombre = nombre ?? "";     // Null-coalescing: si null, asigna cadena vacía
        Telefono = telefono ?? "";
        Email = email ?? "";
    }
    
    // Método ToString() sobrescrito para mostrar contacto formateado
    // Interpolación de cadenas $"" para formato legible
    public override string ToString()
    {
        return $"Nombre: {Nombre}, Teléfono: {Telefono}, Email: {Email}";
    }
}