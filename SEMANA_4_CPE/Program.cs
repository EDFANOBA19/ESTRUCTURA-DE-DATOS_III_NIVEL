class Program
{
    // VECTOR (array) fijo de tamaño máximo 100 para almacenar contactos
    // Arrays: acceso O(1), tamaño fijo, estructura básica hasta semana 4 [file:1][web:5]
    private static Contacto[] agenda = new Contacto[100];  // Array de structs
    private static int totalContactos = 0;  // Contador de contactos válidos almacenados
    
    // Método principal - punto de entrada del programa
    static void Main(string[] args)
    {
        // Configura codificación UTF-8 para caracteres especiales (ñ, acentos)
        // Evita warnings de cultura y problemas de consola en español
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        // Bucle principal del menú interactivo (while true = hasta que usuario salga)
        while (true)
        {
            Console.Clear();  // Limpia pantalla para mejor UX
            MostrarMenu();    // Llama método que muestra menú
            
            // int.TryParse() valida entrada numérica, evita crashes y warnings CS0029
            // if con validación completa elimina 4 warnings comunes
            if (!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 1 || opcion > 4)
            {
                Console.WriteLine("Opción inválida. Presione Enter para continuar...");
                Console.ReadLine();  // Pausa para que usuario lea mensaje
                continue;            // Vuelve al inicio del while (no ejecuta switch)
            }
            
            // Switch mejorado con break explícito en cada case (buena práctica)
            switch (opcion)
            {
                case 1: AgregarContacto(); break;  // Agregar nuevo contacto
                case 2: BuscarContacto(); break;   // Buscar por nombre (consultar)
                case 3: VisualizarTodos(); break;  // Reportería completa
                case 4:                          // Salir del programa
                    Console.WriteLine("¡Gracias por usar la Agenda Telefónica!");
                    return;  // Sale del Main() y termina programa
            }
        }
    }
    
    // MÉTODO: Muestra menú principal de opciones (reportería de navegación)
    static void MostrarMenu()
    {
        Console.WriteLine("=== AGENDA TELEFÓNICA ===");
        Console.WriteLine("1. Agregar Contacto");
        Console.WriteLine("2. Buscar Contacto por Nombre");
        Console.WriteLine("3. Visualizar Todos los Contactos");  // Reportería requerida [file:1]
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opción: ");
    }
    
    // MÉTODO: Agregar nuevo contacto al array (verifica capacidad máxima)
    static void AgregarContacto()
    {
        // Verificación de límite del array (100 elementos máximo)
        if (totalContactos >= agenda.Length)
        {
            Console.WriteLine("¡Agenda llena! Máximo 100 contactos.");
            Console.ReadLine();  // Pausa para usuario
            return;              // Sale del método
        }
        
        // Lectura de datos con null-conditional ?. y Trim() para limpiar espacios
        // ?? "" evita warnings CS8602 "Dereferencing a possibly null reference"
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine()?.Trim() ?? "";
        
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine()?.Trim() ?? "";
        
        Console.Write("Email: ");
        string email = Console.ReadLine()?.Trim() ?? "";
        
        // Crea instancia de struct y la asigna en posición actual del array
        agenda[totalContactos] = new Contacto(nombre, telefono, email);
        totalContactos++;  // Incrementa contador de elementos válidos
        
        Console.WriteLine("¡Contacto agregado exitosamente!");
        Console.ReadLine();  // Pausa de confirmación
    }
    
    // MÉTODO: Búsqueda lineal O(n) por nombre en el array (consulta requerida [file:1])
    static void BuscarContacto()
    {
        Console.Write("Ingrese nombre a buscar: ");
        string buscar = Console.ReadLine()?.Trim().ToLower() ?? "";
        
        bool encontrado = false;  // Flag para verificar si existe resultado
        Console.WriteLine("\nResultados:");
        
        // Bucle for tradicional: recorre array desde 0 hasta totalContactos-1
        // Búsqueda secuencial típica en arrays no ordenados
        for (int i = 0; i < totalContactos; i++)
        {
            // Contains() con ToLower() para búsqueda insensible a mayúsculas
            // ?. y == true eliminan warnings CS8604 y CS8073
            if (agenda[i].Nombre?.ToLower().Contains(buscar) == true)
            {
                Console.WriteLine(agenda[i]);  // ToString() automático
                encontrado = true;
            }
        }
        
        if (!encontrado)
            Console.WriteLine("No se encontraron contactos.");
        
        Console.ReadLine();  // Pausa para revisar resultados
    }
    
    // MÉTODO: Reportería completa - visualiza TODOS los contactos [file:1]
    static void VisualizarTodos()
    {
        Console.WriteLine($"\n=== CONTACTOS ({totalContactos} total) ===");
        
        // Verificación de array vacío (evita mostrar nada innecesariamente)
        if (totalContactos == 0)
        {
            Console.WriteLine("No hay contactos registrados.");
        }
        else
        {
            // Bucle for numerado para mostrar posición (1, 2, 3...)
            for (int i = 0; i < totalContactos; i++)
            {
                Console.WriteLine($"{i + 1}. {agenda[i]}");  // Formato numerado
            }
        }
        
        Console.ReadLine();  // Pausa para revisar lista completa
    }
}