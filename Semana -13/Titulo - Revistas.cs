// Clase que representa un nodo en el árbol binario de búsqueda
public class NodoRev
{
    public string Titulo { get; set; }
    public NodoRev Izquierda { get; set; }
    public NodoRev Derecha { get; set; }

    public NodoRev(string titulo)
    {
        Titulo = titulo;
        Izquierda = null;
        Derecha = null;
    }
}

// Clase que maneja el catálogo de revistas
public class CatalogoRevistas
{
    private NodoRev raiz;

    public CatalogoRevistas()
    {
        raiz = null;
    }

    // Método público para insertar un nuevo título
    public void Insertar(string titulo)
    {
        raiz = InsertarRec(raiz, titulo);
    }

    // Método recursivo privado para insertar
    private NodoRev InsertarRec(NodoRev raiz, string titulo)
    {
        if (raiz == null)
        {
            raiz = new NodoRev(titulo);
            return raiz;
        }

        // Compara alfabéticamente para decidir dónde insertar
        if (string.Compare(titulo, raiz.Titulo) < 0)
            raiz.Izquierda = InsertarRec(raiz.Izquierda, titulo);
        else if (string.Compare(titulo, raiz.Titulo) > 0)
            raiz.Derecha = InsertarRec(raiz.Derecha, titulo);

        return raiz;
    }

    // Método público para buscar un título
    public bool Buscar(string titulo)
    {
        return BuscarRec(raiz, titulo);
    }

    // Método recursivo privado para buscar
    private bool BuscarRec(NodoRev raiz, string titulo)
    {
        if (raiz == null)
            return false;

        if (raiz.Titulo == titulo)
            return true;

        // Compara alfabéticamente para decidir en qué dirección buscar
        if (string.Compare(titulo, raiz.Titulo) < 0)
            return BuscarRec(raiz.Izquierda, titulo);

        return BuscarRec(raiz.Derecha, titulo);
    }
}

class Program
{
    static void Main(string[] args)
    {
        CatalogoRevistas catalogo = new CatalogoRevistas();

        // Insertar los 10 títulos iniciales de revistas
        string[] revistas = {
            "Mad Magazine",
            "People Magazine",
            "Tatler Magazine",
            "Empire Magazine",
            "HELLO! Magazine",
            "The Phoenix Magazine",
            "Lego Star Wars Magazine",
            "Pokemon Magazine",
            "American Cinematographer Magazine",
            "Scream Magazine"
        };

        foreach (string revista in revistas)
        {
            catalogo.Insertar(revista);
        }

        while (true)
        {
            Console.WriteLine("\n=== Menú del Catálogo de Revistas ===");
            Console.WriteLine("1. Buscar un título de revista");
            Console.WriteLine("2. Registrar un nuevo título de revista");
            Console.WriteLine("3. Salir");
            Console.Write("Ingrese su opción (1-3): ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título de la revista a buscar: ");
                    string tituloBusqueda = Console.ReadLine();
                    bool encontrado = catalogo.Buscar(tituloBusqueda);
                    Console.WriteLine(encontrado ? "encontrado" : "no encontrado");
                    break;

                case "2":
                    Console.Write("Ingrese el nuevo título de revista: ");
                    string nuevoTitulo = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevoTitulo))
                    {
                        if (catalogo.Buscar(nuevoTitulo))
                        {
                            Console.WriteLine("Este título ya existe en el catálogo.");
                        }
                        else
                        {
                            catalogo.Insertar(nuevoTitulo);
                            Console.WriteLine("Título registrado exitosamente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El título no puede estar vacío.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Saliendo del programa...");
                    return;

                default:
                    Console.WriteLine("Opción inválida. Por favor intenta de nuevo.");
                    break;
            }
        }
    }
}