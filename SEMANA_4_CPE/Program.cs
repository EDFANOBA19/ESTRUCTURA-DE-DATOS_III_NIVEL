class Program
{
    // Array (vector) fijo de tamaño máximo 100 para almacenar contactos
    // Los arrays son estructuras de datos básicas que almacenan elementos del mismo tipo en posiciones indexadas
    private static Contacto[] agenda = new Contacto[100];
    private static int totalContactos = 0;  // Contador de contactos almacenados actualmente
    
    static void Main(string[] args)
    {
        // Bucle principal del menú interactivo que se ejecuta hasta que el usuario salga
        while (true)
        {
            Console.Clear();  // Limpia la consola para una mejor visualización del menú
            MostrarMenu();    // Muestra las opciones disponibles
            
            string opcion = Console.ReadLine();  // Lee la opción seleccionada por el usuario
            
            switch (opcion)
            {
                case "1":
                    AgregarContacto();  // Llama al método para agregar un nuevo contacto
                    break;
                case "2":
                    BuscarContacto();   // Llama al método para buscar contactos por nombre
                    break;
                case "3":
                    VisualizarTodos();  // Muestra todos los contactos almacenados (reportería completa)
                    break;
                case "4":
                    Console.WriteLine("¡Gracias por usar la Agenda Telefónica!");
                    return;  // Sale del programa
                default:
                    Console.WriteLine("Opción inválida. Presione Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        }
    }
    
    // Método para mostrar el menú principal de opciones
    static void MostrarMenu()
    {
        Console.WriteLine("=== AGENDA TELEFÓNICA ===");
        Console.WriteLine("1. Agregar Contacto");
        Console.WriteLine("2. Buscar Contacto por Nombre");
        Console.WriteLine("3. Visualizar Todos los Contactos");
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opción: ");
    }
    
    // Método para agregar un nuevo contacto al array
    // Verifica que no se exceda el tamaño máximo del vector
    static void AgregarContacto()
    {
        if (totalContactos >= agenda.Length)
        {
            Console.WriteLine("¡Agenda llena! Máximo 100 contactos.");
            Console.ReadLine();
            return;
        }
        
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        
        Console.Write("Email: ");
        string email = Console.ReadLine();
        
        // Crea un nuevo contacto usando el constructor de la struct
        // y lo almacena en la posición actual del array
        agenda[totalContactos] = new Contacto(nombre, telefono, email);
        totalContactos++;  // Incrementa el contador
        
        Console.WriteLine("¡Contacto agregado exitosamente!");
        Console.ReadLine();
    }
    
    // Método para buscar contactos por nombre usando un ciclo for
    // Recorre el array secuencialmente (búsqueda lineal)
    static void BuscarContacto()
    {
        Console.Write("Ingrese nombre a buscar: ");
        string buscar = Console.ReadLine().ToLower();
        
        bool encontrado = false;
        Console.WriteLine("\nResultados:");
        
        // Ciclo for para recorrer el array desde 0 hasta totalContactos-1
        for (int i = 0; i < totalContactos; i++)
        {
            // Compara ignorando mayúsculas/minúsculas si el nombre contiene el texto buscado
            if (agenda[i].nombre.ToLower().Contains(buscar))
            {
                Console.WriteLine(agenda[i]);  // Muestra el contacto usando ToString()
                encontrado = true;
            }
        }
        
        if (!encontrado)
            Console.WriteLine("No se encontraron contactos.");
        
        Console.ReadLine();
    }
    
    // Método de reportería: visualiza todos los contactos en el array
    static void VisualizarTodos()
    {
        Console.WriteLine($"\n=== CONTACTOS ({totalContactos} total) ===");
        
        // Ciclo foreach optimizado para recorrer solo los contactos válidos
        // foreach itera automáticamente sobre el array hasta totalContactos
        for (int i = 0; i < totalContactos; i++)
        {
            Console.WriteLine($"{i + 1}. {agenda[i]}");
        }
        
        Console.ReadLine();
    }
}