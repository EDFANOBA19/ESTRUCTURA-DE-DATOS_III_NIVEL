
/// <summary>
/// Clase Program: Punto de entrada. Ejecuta el ejemplo EXACTO del enunciado.
/// Presiona cualquier tecla para salir [file:1]
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== VERIFICACIÓN DE PARÉNTESIS BALANCEADOS - PILAS LIFO === [file:1]");
        Console.WriteLine("Teoría: Push para aperturas, Pop+Match para cierres.\n");

        VerificadorParentesis verificador = new VerificadorParentesis(); // Crea instancia

        // EJEMPLO EXACTO DEL ENUNCIADO
        string entradaEjemplo = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
        bool esBalanceada = verificador.EsBalanceada(entradaEjemplo); // Ejecuta algoritmo

        Console.WriteLine($"Entrada: {entradaEjemplo}");
        Console.WriteLine($"Salida: {(esBalanceada ? "Fórmula balanceada." : "Fórmula NO balanceada.")}");
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey(); // Pausa para ver resultado
    }
}