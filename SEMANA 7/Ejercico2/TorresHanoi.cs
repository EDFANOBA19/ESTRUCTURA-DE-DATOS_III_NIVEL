/// <summary>
/// Clase TorresHanoi: Resuelve problema clásico usando 3 pilas.
/// Reglas: Solo mover cima, nunca disco grande sobre pequeño.
/// Algoritmo recursivo: Mover(n, origen→destino) = Mover(n-1, origen→aux) + Mover(1, origen→destino) + Mover(n-1, aux→destino) [file:1]
/// </summary>
public class TorresHanoi
{
    private StackPersonalizada<int> torreA; // Torre ORIGEN (discos iniciales)
    private StackPersonalizada<int> torreB; // Torre AUXILIAR (temporal)
    private StackPersonalizada<int> torreC; // Torre DESTINO (objetivo)

    /// <summary>
    /// Constructor: Inicializa 3 torres. Coloca n discos en torre A (1=pequeño arriba, n=grande abajo)
    /// </summary>
    public TorresHanoi(int nDiscos)
    {
        torreA = new StackPersonalizada<int>(); // Crea pila torre A
        torreB = new StackPersonalizada<int>(); // Crea pila torre B  
        torreC = new StackPersonalizada<int>(); // Crea pila torre C

        // Inicializa torre A: discos de grande a pequeño (orden LIFO correcto)
        for (int i = nDiscos; i >= 1; i--) // i=n (grande) hasta i=1 (pequeño)
        {
            torreA.Push(i); // PUSH: Disco i en cima. Al final: cima=1 (pequeño)
        }
    }

    /// <summary>
    /// Resolver: Algoritmo RECURSIVO principal usando pilas.
    /// Muestra CADA movimiento paso a paso como pide enunciado.
    /// Complejidad: O(2^n) movimientos (exponencial, normal para Hanoi) [file:1]
    /// </summary>
    public void Resolver(int nDiscos, StackPersonalizada<int> origen, 
                        StackPersonalizada<int> auxiliar, StackPersonalizada<int> destino)
    {
        if (nDiscos == 1) // CASO BASE: Solo 1 disco
        {
            int disco = origen.Pop(); // POP: Saca disco de origen
            destino.Push(disco);      // PUSH: Coloca en destino
            MostrarMovimiento(origen, auxiliar, destino, 
                $"Mover disco {disco} de {NombreTorre(origen)} a {NombreTorre(destino)}");
            return; // Fin recursión
        }

        // PASO 1: Mover n-1 discos de origen → auxiliar (usando destino como auxiliar)
        Resolver(nDiscos - 1, origen, destino, auxiliar);

        // PASO 2: Mover disco más grande de origen → destino
        int discoGrande = origen.Pop(); // POP: Disco grande
        destino.Push(discoGrande);      // PUSH: A destino
        MostrarMovimiento(origen, auxiliar, destino, 
            $"Mover disco {discoGrande} de {NombreTorre(origen)} a {NombreTorre(destino)}");

        // PASO 3: Mover n-1 discos de auxiliar → destino (usando origen como auxiliar)
        Resolver(nDiscos - 1, auxiliar, origen, destino);
    }

    /// <summary>
    /// MostrarMovimiento: IMPRIME estado completo de torres + movimiento (PASO A PASO como pide enunciado)
    /// </summary>
    private void MostrarMovimiento(StackPersonalizada<int> origen, StackPersonalizada<int> aux, 
                                  StackPersonalizada<int> dest, string movimiento)
    {
        Console.WriteLine(movimiento);                    // Muestra movimiento
        Console.WriteLine($"A: {EstadoTorre(origen)}");   // Estado torre A
        Console.WriteLine($"B: {EstadoTorre(aux)}");      // Estado torre B
        Console.WriteLine($"C: {EstadoTorre(dest)}");     // Estado torre C
        Console.WriteLine(new string('-', 40));           // Separador visual
    }

    /// <summary>
    /// EstadoTorre: Convierte pila → string legible [grande→pequeño] (no modifica pila original)
    /// </summary>
    private string EstadoTorre(StackPersonalizada<int> torre)
    {
        if (torre.IsEmpty()) return "[]"; // Torre vacía

        // Copia temporal para mostrar SIN modificar original
        List<int> temp = new List<int>();
        StackPersonalizada<int> copia = CopiarTorre(torre);
        while (!copia.IsEmpty())
        {
            temp.Add(copia.Pop()); // Extrae todos (invierte orden)
        }
        return $"[{string.Join(", ", temp)}]"; // Formato [3, 2, 1]
    }

    /// <summary>
    /// CopiarTorre: Crea copia exacta de pila (auxiliar para mostrar)
    /// </summary>
    private StackPersonalizada<int> CopiarTorre(StackPersonalizada<int> original)
    {
        StackPersonalizada<int> copia = new StackPersonalizada<int>();
        // Transferencia temporal para copiar sin perder original
        while (!original.IsEmpty())
        {
            copia.Push(original.Pop());
        }
        // Restaura original (invierte copia de vuelta)
        while (!copia.IsEmpty())
        {
            original.Push(copia.Pop());
        }
        return copia; // Retorna copia completa
    }

    /// <summary>
    /// NombreTorre: Identifica torre por referencia (A, B o C)
    /// </summary>
    private string NombreTorre(StackPersonalizada<int> torre)
    {
        if (torre == torreA) return "A";
        if (torre == torreB) return "B";
        return "C";
    }

    /// <summary>
    /// Ejecutar: Inicia resolución completa para n discos
    /// </summary>
    public void Ejecutar(int nDiscos)
    {
        Console.WriteLine($"INICIANDO TORRES DE HANOI con {nDiscos} discos\n");
        Resolver(nDiscos, torreA, torreB, torreC); // Llama algoritmo recursivo
        Console.WriteLine("\n¡RESUELTO! Todos los discos están en la torre C.");
        Console.WriteLine($"Total movimientos: 2^{nDiscos} - 1 = {((int)Math.Pow(2, nDiscos) - 1)}");
    }
}
