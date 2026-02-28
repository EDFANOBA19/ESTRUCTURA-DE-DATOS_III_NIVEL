using System;
using System.Linq;

namespace TraductorInglesEspanol
{
    public class Menu
    {
        private DiccionarioBilingue diccionario;
        private Traductor traductor;

        public Menu()
        {
            diccionario = new DiccionarioBilingue();
            diccionario.InicializarDiccionarioBase();
            traductor = new Traductor(diccionario);
        }

        public void Mostrar()
        {
            int opcion;
            
            do
            {
                Console.Clear();
                Console.WriteLine("==================== MENÚ ====================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Agregar palabras al diccionario");
                Console.WriteLine("3. Mostrar diccionario actual");
                Console.WriteLine("0. Salir");
                Console.WriteLine("==============================================");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            OpcionTraducirFrase();
                            break;
                        case 2:
                            OpcionAgregarPalabras();
                            break;
                        case 3:
                            OpcionMostrarDiccionario();
                            break;
                        case 0:
                            Console.WriteLine("¡Hasta luego!");
                            break;
                        default:
                            MensajeError("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    MensajeError("Por favor, ingrese un número válido.");
                }
            } while (opcion != 0);
        }

        private void OpcionTraducirFrase()
        {
            Console.Clear();
            Console.WriteLine("===== TRADUCTOR INGLÉS-ESPAÑOL =====");
            Console.WriteLine("Ingrese la frase a traducir:");
            string frase = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(frase))
            {
                MensajeError("No ingresó ninguna frase.");
                return;
            }

            string idioma = traductor.ObtenerIdiomaDetectado(frase);
            string traduccion = traductor.TraducirFrase(frase);
            
            Console.WriteLine($"\nIdioma detectado: {idioma}");
            Console.WriteLine("Traduciendo...\n");
            Console.WriteLine("Frase original: " + frase);
            Console.WriteLine("Traducción: " + traduccion);
            
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void OpcionAgregarPalabras()
        {
            Console.Clear();
            Console.WriteLine("===== AGREGAR PALABRAS AL DICCIONARIO =====");
            Console.WriteLine("Seleccione el tipo de traducción:");
            Console.WriteLine("1. Inglés -> Español");
            Console.WriteLine("2. Español -> Inglés");
            Console.Write("Opción: ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.Write("Ingrese la palabra original: ");
                string original = Console.ReadLine();

                Console.Write("Ingrese la traducción: ");
                string traduccion = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(original) || string.IsNullOrWhiteSpace(traduccion))
                {
                    MensajeError("Debe ingresar ambas palabras.");
                    return;
                }

                bool resultado = false;

                if (opcion == 1)
                {
                    resultado = diccionario.AgregarPalabraInglesEspanol(original, traduccion);
                }
                else if (opcion == 2)
                {
                    resultado = diccionario.AgregarPalabraEspanolIngles(original, traduccion);
                }
                else
                {
                    MensajeError("Opción no válida.");
                    return;
                }

                if (resultado)
                {
                    Console.WriteLine($"\n¡Palabra agregada exitosamente!");
                }
                else
                {
                    Console.WriteLine("\nError: La palabra ya existe en el diccionario.");
                }
            }
            else
            {
                MensajeError("Opción no válida.");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void OpcionMostrarDiccionario()
        {
            Console.Clear();
            Console.WriteLine("===== DICCIONARIO ACTUAL =====");
            Console.WriteLine("Inglés -> Español:");
            Console.WriteLine("------------------------");
            
            var dictInglesEspanol = diccionario.ObtenerDiccionarioInglesEspanol();
            foreach (var item in dictInglesEspanol.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            Console.WriteLine("\nEspañol -> Inglés:");
            Console.WriteLine("------------------------");
            
            var dictEspanolIngles = diccionario.ObtenerDiccionarioEspanolIngles();
            foreach (var item in dictEspanolIngles.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            Console.WriteLine($"\nTotal de palabras: {diccionario.TotalPalabras()}");
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void MensajeError(string mensaje)
        {
            Console.WriteLine($"\nError: {mensaje} Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}