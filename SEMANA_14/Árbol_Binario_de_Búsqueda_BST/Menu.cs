using System;
using System.Collections.Generic;

namespace BST_Project
{
    public class Menu
    {
        private ArbolBinarioBusqueda arbol;

        public Menu()
        {
            arbol = new ArbolBinarioBusqueda();
        }

        public void MostrarMenuPrincipal()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("   ÁRBOL BINARIO DE BÚSQUEDA (BST)");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Insertar valores");
                Console.WriteLine("2. Buscar valor");
                Console.WriteLine("3. Eliminar valor");
                Console.WriteLine("4. Mostrar recorridos");
                Console.WriteLine("5. Mostrar mínimo, máximo y altura");
                Console.WriteLine("6. Limpiar árbol");
                Console.WriteLine("7. Mostrar información completa");
                Console.WriteLine("8. Insertar valores de prueba");
                Console.WriteLine("0. Salir");
                Console.WriteLine("========================================");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            InsertarValores();
                            break;
                        case 2:
                            BuscarValor();
                            break;
                        case 3:
                            EliminarValor();
                            break;
                        case 4:
                            MostrarRecorridos();
                            break;
                        case 5:
                            MostrarMinMaxAltura();
                            break;
                        case 6:
                            LimpiarArbol();
                            break;
                        case 7:
                            MostrarInformacionCompleta();
                            break;
                        case 8:
                            InsertarValoresPrueba();
                            break;
                        case 0:
                            Console.WriteLine("\n¡Hasta luego!");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Presione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Presione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        private void InsertarValores()
        {
            Console.Clear();
            Console.WriteLine("=== INSERTAR VALORES ===");
            Console.WriteLine("Ingrese valores separados por espacio o coma");
            Console.WriteLine("Ejemplo: 50 30 70 20 40 60 80");
            Console.Write("Valores: ");

            string entrada = Console.ReadLine();
            string[] partes = entrada.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            int insertados = 0;
            foreach (string parte in partes)
            {
                if (int.TryParse(parte, out int valor))
                {
                    arbol.Insertar(valor);
                    insertados++;
                    Console.WriteLine($"✓ Valor {valor} insertado");
                }
                else
                {
                    Console.WriteLine($"✗ '{parte}' no es un número válido");
                }
            }

            Console.WriteLine($"\nSe insertaron {insertados} valores.");
            Console.WriteLine($"Total de nodos en el árbol: {arbol.ObtenerCantidadNodos()}");
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void BuscarValor()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR VALOR ===");
            Console.Write("Ingrese el valor a buscar: ");

            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                bool existe = arbol.Buscar(valor);
                if (existe)
                {
                    Console.WriteLine($"\n✓ El valor {valor} SÍ existe en el árbol.");
                }
                else
                {
                    Console.WriteLine($"\n✗ El valor {valor} NO existe en el árbol.");
                }
            }
            else
            {
                Console.WriteLine("Valor no válido.");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void EliminarValor()
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR VALOR ===");

            if (arbol.EstaVacio())
            {
                Console.WriteLine("El árbol está vacío. No hay valores para eliminar.");
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
                return;
            }

            MostrarRecorridoInorden();
            Console.Write("\nIngrese el valor a eliminar: ");

            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                bool eliminado = arbol.Eliminar(valor);
                if (eliminado)
                {
                    Console.WriteLine($"\n✓ Valor {valor} eliminado correctamente.");
                    Console.WriteLine($"Total de nodos restantes: {arbol.ObtenerCantidadNodos()}");
                }
                else
                {
                    Console.WriteLine($"\n✗ El valor {valor} no se encontró en el árbol.");
                }
            }
            else
            {
                Console.WriteLine("Valor no válido.");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void MostrarRecorridos()
        {
            Console.Clear();
            Console.WriteLine("=== RECORRIDOS DEL ÁRBOL ===");

            if (arbol.EstaVacio())
            {
                Console.WriteLine("El árbol está vacío.");
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
                return;
            }

            // Preorden
            List<int> preorden = arbol.RecorridoPreorden();
            Console.WriteLine("\n┌─────────────────────────────────────────┐");
            Console.WriteLine("│ RECORRIDO PREORDEN (Raíz - Izq - Der) │");
            Console.WriteLine("├─────────────────────────────────────────┤");
            Console.WriteLine($"│ {string.Join(" → ", preorden)}");
            Console.WriteLine("└─────────────────────────────────────────┘");

            // Inorden
            List<int> inorden = arbol.RecorridoInorden();
            Console.WriteLine("\n┌─────────────────────────────────────────┐");
            Console.WriteLine("│ RECORRIDO INORDEN (Izq - Raíz - Der)   │");
            Console.WriteLine("├─────────────────────────────────────────┤");
            Console.WriteLine($"│ {string.Join(" → ", inorden)}");
            Console.WriteLine("└─────────────────────────────────────────┘");

            // Postorden
            List<int> postorden = arbol.RecorridoPostorden();
            Console.WriteLine("\n┌─────────────────────────────────────────┐");
            Console.WriteLine("│ RECORRIDO POSTORDEN (Izq - Der - Raíz) │");
            Console.WriteLine("├─────────────────────────────────────────┤");
            Console.WriteLine($"│ {string.Join(" → ", postorden)}");
            Console.WriteLine("└─────────────────────────────────────────┘");

            Console.WriteLine($"\nTotal de nodos: {arbol.ObtenerCantidadNodos()}");

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void MostrarMinMaxAltura()
        {
            Console.Clear();
            Console.WriteLine("=== INFORMACIÓN DEL ÁRBOL ===");

            if (arbol.EstaVacio())
            {
                Console.WriteLine("El árbol está vacío.");
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\n┌─────────────────────────────────────────┐");
            Console.WriteLine("│        PROPIEDADES DEL ÁRBOL           │");
            Console.WriteLine("├─────────────────────────────────────────┤");

            int? minimo = arbol.ObtenerMinimo();
            Console.WriteLine($"│ Valor Mínimo: {minimo,-34}│");

            int? maximo = arbol.ObtenerMaximo();
            Console.WriteLine($"│ Valor Máximo: {maximo,-34}│");

            int altura = arbol.ObtenerAltura();
            Console.WriteLine($"│ Altura del árbol: {altura,-31}│");

            int cantidad = arbol.ObtenerCantidadNodos();
            Console.WriteLine($"│ Cantidad de nodos: {cantidad,-30}│");

            Console.WriteLine("└─────────────────────────────────────────┘");

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void MostrarRecorridoInorden()
        {
            if (arbol.EstaVacio())
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }

            List<int> inorden = arbol.RecorridoInorden();
            Console.WriteLine($"Valores actuales en el árbol (Inorden): {string.Join(", ", inorden)}");
        }

        private void MostrarInformacionCompleta()
        {
            Console.Clear();
            Console.WriteLine("=== INFORMACIÓN COMPLETA DEL ÁRBOL ===\n");

            if (arbol.EstaVacio())
            {
                Console.WriteLine("El árbol está vacío.");
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
                return;
            }

            MostrarMinMaxAlturaSinPausa();

            Console.WriteLine("\n--- RECORRIDOS ---");
            List<int> preorden = arbol.RecorridoPreorden();
            Console.WriteLine($"Preorden:  {string.Join(" → ", preorden)}");

            List<int> inorden = arbol.RecorridoInorden();
            Console.WriteLine($"Inorden:   {string.Join(" → ", inorden)}");

            List<int> postorden = arbol.RecorridoPostorden();
            Console.WriteLine($"Postorden: {string.Join(" → ", postorden)}");

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void MostrarMinMaxAlturaSinPausa()
        {
            if (!arbol.EstaVacio())
            {
                int? minimo = arbol.ObtenerMinimo();
                int? maximo = arbol.ObtenerMaximo();
                int altura = arbol.ObtenerAltura();
                int cantidad = arbol.ObtenerCantidadNodos();

                Console.WriteLine("┌─────────────────────────────────────────┐");
                Console.WriteLine("│        PROPIEDADES DEL ÁRBOL           │");
                Console.WriteLine("├─────────────────────────────────────────┤");
                Console.WriteLine($"│ Valor Mínimo: {minimo,-34}│");
                Console.WriteLine($"│ Valor Máximo: {maximo,-34}│");
                Console.WriteLine($"│ Altura del árbol: {altura,-31}│");
                Console.WriteLine($"│ Cantidad de nodos: {cantidad,-30}│");
                Console.WriteLine("└─────────────────────────────────────────┘");
            }
        }

        private void InsertarValoresPrueba()
        {
            Console.Clear();
            Console.WriteLine("=== INSERTAR VALORES DE PRUEBA ===");

            int[] valoresPrueba = { 50, 30, 70, 20, 40, 60, 80, 25, 35, 45, 55, 65, 75, 85 };

            foreach (int valor in valoresPrueba)
            {
                arbol.Insertar(valor);
            }

            Console.WriteLine("Se insertaron los siguientes valores de prueba:");
            Console.WriteLine(string.Join(", ", valoresPrueba));
            Console.WriteLine($"\nTotal de nodos insertados: {arbol.ObtenerCantidadNodos()}");

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void LimpiarArbol()
        {
            Console.Clear();
            Console.WriteLine("=== LIMPIAR ÁRBOL ===");

            if (arbol.EstaVacio())
            {
                Console.WriteLine("El árbol ya está vacío.");
            }
            else
            {
                Console.Write($"¿Está seguro de eliminar todos los {arbol.ObtenerCantidadNodos()} nodos? (S/N): ");
                string respuesta = Console.ReadLine()?.ToUpper();

                if (respuesta == "S")
                {
                    arbol.Limpiar();
                    Console.WriteLine("✓ El árbol ha sido limpiado correctamente.");
                }
                else
                {
                    Console.WriteLine("Operación cancelada.");
                }
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}