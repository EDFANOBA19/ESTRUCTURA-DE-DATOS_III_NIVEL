/// <summary>
/// Clase Program: Punto de entrada. Ejecuta Hanoi con 3 discos (recomendado para ver pasos claros)
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== TORRES DE HANOI - PILAS LIFO (RECUSIÓN) === [file:1]");
        Console.WriteLine("Reglas: Solo cima, nunca disco grande sobre pequeño\n");

        // EJECUTA CON 3 DISCOS (7 movimientos, perfecto para ver algoritmo)
        TorresHanoi hanoi = new TorresHanoi(3);
        hanoi.Ejecutar(3);

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}