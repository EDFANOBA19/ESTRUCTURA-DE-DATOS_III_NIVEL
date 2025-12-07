using System;
using FigurasGeometricas;  // Directiva using que importa el namespace con las clases de figuras

// Clase Program contiene el método Main que es el punto de entrada de la aplicación
class Program
{
    // Main es el método estático que se ejecuta al iniciar la aplicación
    // Crea instancias de las clases Circulo y Rectangulo para demostrar su funcionamiento
    static void Main(string[] args)
    {
        // Creación de instancia de la clase Circulo pasando radio=5 como argumento de tipo double
        // El constructor privado inicializa el atributo radio de la instancia
        Circulo circulo = new Circulo(5);
        
        // Impresión de resultados del círculo
        Console.WriteLine("Círculo:");
        Console.WriteLine("Área: " + circulo.CalcularArea());           // Llama al método público CalcularArea
        Console.WriteLine("Perímetro: " + circulo.CalcularPerimetro());  // Llama al método público CalcularPerimetro

        // Creación de instancia de la clase Rectangulo pasando base=4 y altura=7 como argumentos double
        // El constructor privado inicializa los atributos baseRect y altura de la instancia
        Rectangulo rectangulo = new Rectangulo(4, 7);
        
        // Impresión de resultados del rectángulo con salto de línea previo
        Console.WriteLine("\nRectángulo:");
        Console.WriteLine("Área: " + rectangulo.CalcularArea());           // Llama al método público CalcularArea
        Console.WriteLine("Perímetro: " + rectangulo.CalcularPerimetro()); // Llama al método público CalcularPerimetro
    }
}
