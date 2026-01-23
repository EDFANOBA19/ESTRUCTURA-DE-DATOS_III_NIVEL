// =====================================================
// EJERCICIO 2: TORRES DE HANOI USANDO PILAS LIFO
// Algoritmo recursivo con 3 pilas (A=origen, B=auxiliar, C=destino) [file:1]
// Universidad Estatal Amazónica - Estructuras de Datos
// =====================================================
using System; // Namespace para Console y excepciones
using System.Collections.Generic; // Namespace para List<T> (base de pila)

/// <summary>
/// Clase StackPersonalizada: Pila LIFO genérica (misma del Ejercicio 1).
/// Push=agregar cima, Pop=eliminar cima, Peek=ver cima, IsEmpty=verificar vacía [file:1]
/// </summary>
/// <typeparam name="T">Tipo genérico (int para discos: 1=pequeño, n=grande)</typeparam>
public class StackPersonalizada<T>
{
    private List<T> elementos; // Lista interna: final = cima de pila

    public StackPersonalizada()
    {
        elementos = new List<T>(); // Inicializa pila vacía
    }

    /// <summary> PUSH: Inserta en CIMA (LIFO) O(1) </summary>
    public void Push(T item) => elementos.Add(item);

    /// <summary> POP: Elimina/retorna CIMA. Lanza error si vacía O(1) </summary>
    public T Pop()
    {
        if (IsEmpty()) throw new InvalidOperationException("Pila vacía. No se puede Pop.");
        T cima = elementos[elementos.Count - 1];
        elementos.RemoveAt(elementos.Count - 1);
        return cima;
    }

    /// <summary> PEEK: Ve CIMA sin eliminarla O(1) </summary>
    public T Peek()
    {
        if (IsEmpty()) throw new InvalidOperationException("Pila vacía. No se puede Peek.");
        return elementos[elementos.Count - 1];
    }

    /// <summary> ISEMPTY: Verifica si pila vacía O(1) </summary>
    public bool IsEmpty() => elementos.Count == 0;

    /// <summary> COUNT: Número de elementos </summary>
    public int Count => elementos.Count;
}
