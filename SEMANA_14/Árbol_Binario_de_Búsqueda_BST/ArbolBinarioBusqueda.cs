using System;
using System.Collections.Generic;

namespace BST_Project
{
    public class ArbolBinarioBusqueda
    {
        private Nodo raiz;

        public ArbolBinarioBusqueda()
        {
            raiz = null;
        }

        // 1. INSERTAR VALOR
        public void Insertar(int valor)
        {
            raiz = InsertarRecursivo(raiz, valor);
        }

        private Nodo InsertarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                return new Nodo(valor);
            }

            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
            }
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);
            }
            // Si el valor ya existe, no se inserta (evita duplicados)

            return nodo;
        }

        // 2. BUSCAR VALOR
        public bool Buscar(int valor)
        {
            return BuscarRecursivo(raiz, valor);
        }

        private bool BuscarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                return false;
            }

            if (valor == nodo.Valor)
            {
                return true;
            }
            else if (valor < nodo.Valor)
            {
                return BuscarRecursivo(nodo.Izquierdo, valor);
            }
            else
            {
                return BuscarRecursivo(nodo.Derecho, valor);
            }
        }

        // 3. ELIMINAR VALOR
        public bool Eliminar(int valor)
        {
            if (!Buscar(valor))
            {
                return false;
            }

            raiz = EliminarRecursivo(raiz, valor);
            return true;
        }

        private Nodo EliminarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                return null;
            }

            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, valor);
            }
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, valor);
            }
            else
            {
                // Caso 1: Nodo hoja (sin hijos)
                if (nodo.Izquierdo == null && nodo.Derecho == null)
                {
                    return null;
                }
                // Caso 2: Nodo con un solo hijo
                else if (nodo.Izquierdo == null)
                {
                    return nodo.Derecho;
                }
                else if (nodo.Derecho == null)
                {
                    return nodo.Izquierdo;
                }
                // Caso 3: Nodo con dos hijos
                else
                {
                    // Encontrar el sucesor inorden (mínimo del subárbol derecho)
                    Nodo sucesor = ObtenerMinimoNodo(nodo.Derecho);
                    nodo.Valor = sucesor.Valor;
                    nodo.Derecho = EliminarRecursivo(nodo.Derecho, sucesor.Valor);
                }
            }

            return nodo;
        }

        private Nodo ObtenerMinimoNodo(Nodo nodo)
        {
            Nodo actual = nodo;
            while (actual.Izquierdo != null)
            {
                actual = actual.Izquierdo;
            }
            return actual;
        }

        // 4. RECORRIDO PREORDEN (Raíz, Izquierdo, Derecho)
        public List<int> RecorridoPreorden()
        {
            List<int> resultado = new List<int>();
            PreordenRecursivo(raiz, resultado);
            return resultado;
        }

        private void PreordenRecursivo(Nodo nodo, List<int> resultado)
        {
            if (nodo != null)
            {
                resultado.Add(nodo.Valor);
                PreordenRecursivo(nodo.Izquierdo, resultado);
                PreordenRecursivo(nodo.Derecho, resultado);
            }
        }

        // 5. RECORRIDO INORDEN (Izquierdo, Raíz, Derecho) - Orden ascendente
        public List<int> RecorridoInorden()
        {
            List<int> resultado = new List<int>();
            InordenRecursivo(raiz, resultado);
            return resultado;
        }

        private void InordenRecursivo(Nodo nodo, List<int> resultado)
        {
            if (nodo != null)
            {
                InordenRecursivo(nodo.Izquierdo, resultado);
                resultado.Add(nodo.Valor);
                InordenRecursivo(nodo.Derecho, resultado);
            }
        }

        // 6. RECORRIDO POSTORDEN (Izquierdo, Derecho, Raíz)
        public List<int> RecorridoPostorden()
        {
            List<int> resultado = new List<int>();
            PostordenRecursivo(raiz, resultado);
            return resultado;
        }

        private void PostordenRecursivo(Nodo nodo, List<int> resultado)
        {
            if (nodo != null)
            {
                PostordenRecursivo(nodo.Izquierdo, resultado);
                PostordenRecursivo(nodo.Derecho, resultado);
                resultado.Add(nodo.Valor);
            }
        }

        // 7. OBTENER VALOR MÍNIMO
        public int? ObtenerMinimo()
        {
            if (raiz == null)
            {
                return null;
            }

            Nodo actual = raiz;
            while (actual.Izquierdo != null)
            {
                actual = actual.Izquierdo;
            }
            return actual.Valor;
        }

        // 8. OBTENER VALOR MÁXIMO
        public int? ObtenerMaximo()
        {
            if (raiz == null)
            {
                return null;
            }

            Nodo actual = raiz;
            while (actual.Derecho != null)
            {
                actual = actual.Derecho;
            }
            return actual.Valor;
        }

        // 9. OBTENER ALTURA DEL ÁRBOL
        public int ObtenerAltura()
        {
            return CalcularAltura(raiz);
        }

        private int CalcularAltura(Nodo nodo)
        {
            if (nodo == null)
            {
                return 0;
            }

            int alturaIzquierda = CalcularAltura(nodo.Izquierdo);
            int alturaDerecha = CalcularAltura(nodo.Derecho);

            return Math.Max(alturaIzquierda, alturaDerecha) + 1;
        }

        // 10. LIMPIAR ÁRBOL
        public void Limpiar()
        {
            raiz = null;
        }

        // 11. VERIFICAR SI EL ÁRBOL ESTÁ VACÍO
        public bool EstaVacio()
        {
            return raiz == null;
        }

        // 12. OBTENER CANTIDAD DE NODOS
        public int ObtenerCantidadNodos()
        {
            return ContarNodos(raiz);
        }

        private int ContarNodos(Nodo nodo)
        {
            if (nodo == null)
            {
                return 0;
            }
            return 1 + ContarNodos(nodo.Izquierdo) + ContarNodos(nodo.Derecho);
        }
    }
}