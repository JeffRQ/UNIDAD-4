namespace VuelosBaratos
{
    // Esta clase representa el grafo de rutas de vuelo
    class Grafo
    {
        // Diccionario que almacena para cada ciudad sus destinos y costos asociados
        private Dictionary<string, List<(string destino, int costo)>> adyacencias;

        public Grafo()
        {
            adyacencias = new Dictionary<string, List<(string, int)>>();
        }

        // Método para agregar un vuelo al grafo
        public void AgregarVuelo(string origen, string destino, int costo)
        {
            // Si el nodo de origen no existe, se crea
            if (!adyacencias.ContainsKey(origen))
                adyacencias[origen] = new List<(string, int)>();

            // Se añade el vuelo (arista con peso) al grafo
            adyacencias[origen].Add((destino, costo));

            // Aseguramos que el destino también esté en el grafo
            if (!adyacencias.ContainsKey(destino))
                adyacencias[destino] = new List<(string, int)>();
        }

        // Algoritmo de Dijkstra para encontrar rutas más baratas desde una ciudad origen
        public void BuscarVuelosMasBaratos(string origen)
        {
            // Diccionario para registrar las distancias mínimas encontradas
            var distancias = new Dictionary<string, int>();

            // Conjunto de nodos ya procesados
            var visitado = new HashSet<string>();

            // Cola de prioridad que organiza los nodos por menor costo acumulado
            var colaPrioridad = new SortedSet<(int costo, string ciudad)>();

            // Inicializar las distancias: infinito para todos, excepto el origen
            foreach (var nodo in adyacencias.Keys)
                distancias[nodo] = int.MaxValue;

            distancias[origen] = 0;
            colaPrioridad.Add((0, origen));

            // Proceso principal del algoritmo
            while (colaPrioridad.Count > 0)
            {
                var (costoActual, ciudadActual) = colaPrioridad.Min;
                colaPrioridad.Remove(colaPrioridad.Min);

                if (visitado.Contains(ciudadActual))
                    continue;

                visitado.Add(ciudadActual);

                // Evaluar todos los vecinos (vuelos desde esta ciudad)
                foreach (var (vecino, costo) in adyacencias[ciudadActual])
                {
                    int nuevoCosto = costoActual + costo;
                    if (nuevoCosto < distancias[vecino])
                    {
                        distancias[vecino] = nuevoCosto;
                        colaPrioridad.Add((nuevoCosto, vecino));
                    }
                }
            }

            // Imprimir los resultados: rutas más baratas desde la ciudad origen
            Console.WriteLine($"\nVuelos más baratos desde {origen}:");
            foreach (var destino in distancias)
            {
                string costoStr = destino.Value == int.MaxValue ? "No disponible" : $"${destino.Value}";
                Console.WriteLine($"- {destino.Key}: {costoStr}");
            }
        }
    }

    // Clase principal que contiene el método Main
    class Program
    {
        static void Main()
        {
            var grafoVuelos = new Grafo();

            // Simulación de una base de datos de vuelos (grafo dirigido)
            grafoVuelos.AgregarVuelo("A", "B", 100);
            grafoVuelos.AgregarVuelo("A", "C", 300);
            grafoVuelos.AgregarVuelo("B", "C", 50);
            grafoVuelos.AgregarVuelo("C", "D", 100);
            grafoVuelos.AgregarVuelo("B", "D", 200);
            grafoVuelos.AgregarVuelo("D", "E", 120);
            grafoVuelos.AgregarVuelo("A", "E", 1000);

            // Ejecutar la búsqueda de vuelos más baratos desde "A"
            grafoVuelos.BuscarVuelosMasBaratos("A");

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
