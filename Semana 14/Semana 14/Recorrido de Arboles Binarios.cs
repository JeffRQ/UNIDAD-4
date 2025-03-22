using System;

class Nodo
{
    public string Valor { get; set; }
    public Nodo Izquierda { get; set; }
    public Nodo Derecha { get; set; }

    public Nodo(string valor)
    {
        Valor = valor;
        Izquierda = null;
        Derecha = null;
    }
}

class ArbolBinario
{
    private Nodo raiz;

    public ArbolBinario()
    {
        raiz = null;
    }

    // Método para registrar los datos del árbol desde el teclado
    public void RegistrarArbolViaje()
    {
        Console.WriteLine("Registro del árbol de 'Viaje familiar':");
        Console.Write("Ingrese el valor para 'Viaje' (raíz): ");
        raiz = new Nodo(Console.ReadLine());

        // Destino
        Console.Write("Ingrese el valor para 'Destino': ");
        raiz.Izquierda = new Nodo(Console.ReadLine());
        Console.Write("Ingrese el valor para 'Ciudad': ");
        raiz.Izquierda.Izquierda = new Nodo(Console.ReadLine());
        Console.Write("Ingrese el valor para 'Hotel': ");
        raiz.Izquierda.Derecha = new Nodo(Console.ReadLine());

        // Transporte
        Console.Write("Ingrese el valor para 'Transporte': ");
        raiz.Derecha = new Nodo(Console.ReadLine());
        Console.Write("Ingrese el valor para 'Auto': ");
        raiz.Derecha.Izquierda = new Nodo(Console.ReadLine());
        Console.Write("Ingrese el valor para 'Avión': ");
        raiz.Derecha.Derecha = new Nodo(Console.ReadLine());

        Console.WriteLine("Árbol registrado con éxito.\n");
    }

    // Recorrido Preorden: Raíz, Izquierda, Derecha
    public void Preorden(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            Preorden(nodo.Izquierda);
            Preorden(nodo.Derecha);
        }
    }

    // Recorrido Inorden: Izquierda, Raíz, Derecha
    public void Inorden(Nodo nodo)
    {
        if (nodo != null)
        {
            Inorden(nodo.Izquierda);
            Console.Write(nodo.Valor + " ");
            Inorden(nodo.Derecha);
        }
    }

    // Recorrido Postorden: Izquierda, Derecha, Raíz
    public void Postorden(Nodo nodo)
    {
        if (nodo != null)
        {
            Postorden(nodo.Izquierda);
            Postorden(nodo.Derecha);
            Console.Write(nodo.Valor + " ");
        }
    }

    // Métodos públicos para mostrar los recorridos
    public void MostrarPreorden()
    {
        if (raiz == null)
        {
            Console.WriteLine("El árbol no ha sido registrado aún.");
            return;
        }
        Console.Write("Recorrido Preorden: ");
        Preorden(raiz);
        Console.WriteLine();
    }

    public void MostrarInorden()
    {
        if (raiz == null)
        {
            Console.WriteLine("El árbol no ha sido registrado aún.");
            return;
        }
        Console.Write("Recorrido Inorden: ");
        Inorden(raiz);
        Console.WriteLine();
    }

    public void MostrarPostorden()
    {
        if (raiz == null)
        {
            Console.WriteLine("El árbol no ha sido registrado aún.");
            return;
        }
        Console.Write("Recorrido Postorden: ");
        Postorden(raiz);
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n=== Menú Árbol Binario - Viaje Familiar ===");
            Console.WriteLine("1. Registrar datos del árbol");
            Console.WriteLine("2. Mostrar recorrido Preorden");
            Console.WriteLine("3. Mostrar recorrido Inorden");
            Console.WriteLine("4. Mostrar recorrido Postorden");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    arbol.RegistrarArbolViaje();
                    break;
                case "2":
                    arbol.MostrarPreorden();
                    break;
                case "3":
                    arbol.MostrarInorden();
                    break;
                case "4":
                    arbol.MostrarPostorden();
                    break;
                case "5":
                    salir = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                    break;
            }
        }
    }
}