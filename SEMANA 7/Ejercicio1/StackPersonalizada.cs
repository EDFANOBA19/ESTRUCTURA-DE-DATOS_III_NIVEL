// =====================================================
// EJERCICIO 1: VERIFICACIÓN DE PARÉNTESIS BALANCEADOS
// Implementación usando PILAS (LIFO) en C# - Teoría de clase [file:1]
// Universidad Estatal Amazónica - Estructuras de Datos
// =====================================================
using System; // Namespace para Console, InvalidOperationException, etc.
using System.Collections.Generic; // Namespace para List<T> (base de nuestra pila)

/// <summary>
/// Clase StackPersonalizada: Implementa pila LIFO (Last In, First Out) genérica.
/// Basada en teoría de pilas: Push (insertar cima), Pop (eliminar cima), Peek (ver cima), IsEmpty [file:1]
/// </summary>
/// <typeparam name="T">Tipo genérico de elementos (char para paréntesis, int para discos, etc.)</typeparam>
public class StackPersonalizada<T>
{
    private List<T> elementos; // Campo privado: Lista interna que simula la pila (final = cima)

    /// <summary>
    /// Constructor: Inicializa la pila vacía creando una nueva lista.
    /// Complejidad: O(1)
    /// </summary>
    public StackPersonalizada()
    {
        elementos = new List<T>(); // Crea lista vacía - pila lista para usar
    }

    /// <summary>
    /// Push: Inserta elemento en la CIMA de la pila (final de la lista).
    /// Principio LIFO: último en entrar estará primero en salir [file:1]
    /// Complejidad: O(1) amortizado
    /// </summary>
    public void Push(T item)
    {
        elementos.Add(item); // Agrega al final = cima de pila
    }

    /// <summary>
    /// Pop: ELIMINA y RETORNA el elemento de la CIMA.
    /// Lanza excepción si pila vacía (stack underflow) [file:1]
    /// Complejidad: O(1) amortizado
    /// </summary>
    public T Pop()
    {
        if (IsEmpty()) // Verifica si está vacía antes de pop
        {
            throw new InvalidOperationException("Error: Pila vacía. No se puede Pop (underflow).");
        }
        T cima = elementos[elementos.Count - 1]; // Obtiene referencia al elemento cima
        elementos.RemoveAt(elementos.Count - 1); // Elimina el último elemento
        return cima; // Retorna el elemento eliminado
    }

    /// <summary>
    /// Peek: OBSERVA el elemento de la CIMA sin eliminarlo.
    /// Útil para verificar sin modificar la pila [file:1]
    /// Complejidad: O(1)
    /// </summary>
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Error: Pila vacía. No se puede Peek.");
        }
        return elementos[elementos.Count - 1]; // Solo retorna, no elimina
    }

    /// <summary>
    /// IsEmpty: Retorna true si la pila no tiene elementos.
    /// Complejidad: O(1) [file:1]
    /// </summary>
    public bool IsEmpty()
    {
        return elementos.Count == 0; // Cuenta elementos == 0?
    }

    /// <summary>
    /// Propiedad Count: Número de elementos en la pila (solo lectura).
    /// </summary>
    public int Count => elementos.Count; // Sintaxis abreviada de get
}
