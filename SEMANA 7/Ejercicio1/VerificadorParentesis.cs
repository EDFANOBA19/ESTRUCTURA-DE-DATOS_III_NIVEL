
/// <summary>
/// Clase VerificadorParentesis: Usa pila para verificar balanceo de (), [], {}.
/// Algoritmo: Apertura → Push, Cierre → Pop+Match. Al final pila debe estar vacía [file:1]
/// </summary>
public class VerificadorParentesis
{
    private StackPersonalizada<char> pilaParentesis; // Pila específica para caracteres de paréntesis

    /// <summary>
    /// Constructor: Crea nueva pila para paréntesis.
    /// </summary>
    public VerificadorParentesis()
    {
        pilaParentesis = new StackPersonalizada<char>();
    }

    /// <summary>
    /// Método principal EsBalanceada: Verifica expresión matemática.
    /// Ejemplo requerido: {7 + (8 * 5) - [(9 - 7) + (4 + 1)]} → "Fórmula balanceada."
    /// Lógica LIFO: Cada cierre debe matching la apertura más reciente [file:1]
    /// Complejidad: O(n) donde n = longitud expresión
    /// </summary>
    public bool EsBalanceada(string expresion)
    {
        pilaParentesis = new StackPersonalizada<char>(); // Reinicia pila para esta verificación

        foreach (char c in expresion) // Itera cada carácter de la expresión
        {
            if (EsApertura(c)) // ¿Es (, [, o {? 
            {
                pilaParentesis.Push(c); // PUSH: Guarda apertura en pila
            }
            else if (EsCierre(c)) // ¿Es ), ], o }?
            {
                if (pilaParentesis.IsEmpty()) // Pila vacía = más cierres que aperturas
                {
                    return false; // No balanceada
                }
                char aperturaEsperada = pilaParentesis.Pop(); // POP: Saca apertura más reciente
                if (!SonPareja(aperturaEsperada, c)) // Verifica si coinciden tipos
                {
                    return false; // Tipos no coinciden (ej: ( ] )
                }
            }
            // Ignora números, operadores (+, -, *, /), espacios, etc.
        }

        return pilaParentesis.IsEmpty(); // Balanceada SIEMPRE que pila esté VACÍA al final
    }

    /// <summary>
    /// EsApertura: Identifica caracteres de APERTURA: (, [, {
    /// </summary>
    private bool EsApertura(char c)
    {
        return c == '(' || c == '[' || c == '{'; // True si es alguna apertura
    }

    /// <summary>
    /// EsCierre: Identifica caracteres de CIERRE: ), ], }
    /// </summary>
    private bool EsCierre(char c)
    {
        return c == ')' || c == ']' || c == '}'; // True si es alguna cierre
    }

    /// <summary>
    /// SonPareja: Verifica matching correcto: () , [] , {}
    /// </summary>
    private bool SonPareja(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||  // Paréntesis redondos
               (apertura == '[' && cierre == ']') ||  // Corchetes
               (apertura == '{' && cierre == '}');   // Llaves
    }
}