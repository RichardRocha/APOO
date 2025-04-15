using System;
using System.Collections.Generic;
using System.IO;

class Grafo
{
    private Dictionary<int, Dictionary<int, int>> adjacencias;

    public Grafo()
    {
        adjacencias = new Dictionary<int, Dictionary<int, int>>();
    }

    public void insertVertex(int v)
    {
        if (!adjacencias.ContainsKey(v))
            adjacencias[v] = new Dictionary<int, int>();
    }

    public void insertEdge(int v, int w, int o)
    {
        insertVertex(v);
        insertVertex(w);
        adjacencias[v][w] = o;
        adjacencias[w][v] = o; // grafo não-direcionado
    }

    public void removeVertex(int v)
    {
        if (adjacencias.ContainsKey(v))
        {
            foreach (var vizinho in adjacencias[v].Keys)
            {
                adjacencias[vizinho].Remove(v);
            }
            adjacencias.Remove(v);
        }
    }

    public void removeEdge(int v, int w)
    {
        if (adjacencias.ContainsKey(v)) adjacencias[v].Remove(w);
        if (adjacencias.ContainsKey(w)) adjacencias[w].Remove(v);
    }

    public bool areAdjacent(int v, int w) => adjacencias.ContainsKey(v) && adjacencias[v].ContainsKey(w);

    public int edgeValue(int v, int w) => adjacencias[v][w];

    public void replaceEdge(int v, int w, int o)
    {
        if (areAdjacent(v, w))
        {
            adjacencias[v][w] = o;
            adjacencias[w][v] = o;
        }
    }

    public void Dijkstra(int origem, int destino)
    {
        var dist = new Dictionary<int, int>();
        var prev = new Dictionary<int, int?>();
        var visitado = new HashSet<int>();
        var fila = new PriorityQueue<int, int>();

        foreach (var v in adjacencias.Keys)
        {
            dist[v] = int.MaxValue;
            prev[v] = null;
        }

        dist[origem] = 0;
        fila.Enqueue(origem, 0);

        while (fila.Count > 0)
        {
            var u = fila.Dequeue();
            if (visitado.Contains(u)) continue;
            visitado.Add(u);

            foreach (var vizinho in adjacencias[u])
            {
                int alt = dist[u] + vizinho.Value;
                if (alt < dist[vizinho.Key])
                {
                    dist[vizinho.Key] = alt;
                    prev[vizinho.Key] = u;
                    fila.Enqueue(vizinho.Key, alt);
                }
            }
        }

        if (dist[destino] == int.MaxValue)
        {
            Console.WriteLine("Não há caminho entre os vértices.");
            return;
        }

        Stack<int> caminho = new Stack<int>();
        for (int? at = destino; at != null; at = prev[at.Value])
            caminho.Push(at.Value);

        Console.WriteLine("Caminho mínimo:");
        Console.WriteLine(string.Join(" -> ", caminho));
        Console.WriteLine($"Custo: {dist[destino]}");
    }

    public static Grafo LerDoArquivo(string caminho)
    {
        var grafo = new Grafo();
        var linhas = File.ReadAllLines(caminho);
        int numVertices = int.Parse(linhas[0]);

        for (int i = 1; i < linhas.Length; i++)
        {
            var partes = linhas[i].Split();
            int v = int.Parse(partes[0]);
            int w = int.Parse(partes[1]);
            grafo.insertEdge(v, w, 1); // valor padrão da aresta como 1
        }

        return grafo;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Informe o caminho do arquivo de entrada:");
        string caminho = Console.ReadLine();

        Grafo grafo = Grafo.LerDoArquivo(caminho);

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Inserir vértice");
            Console.WriteLine("2. Inserir aresta");
            Console.WriteLine("3. Remover vértice");
            Console.WriteLine("4. Remover aresta");
            Console.WriteLine("5. Verificar adjacência");
            Console.WriteLine("6. Executar Dijkstra");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha: ");

            string opcao = Console.ReadLine();
            if (opcao == "0") break;

            switch (opcao)
            {
                case "1":
                    Console.Write("Vértice: ");
                    int v1 = int.Parse(Console.ReadLine());
                    grafo.insertVertex(v1);
                    break;
                case "2":
                    Console.Write("V1 V2 peso: ");
                    var parts = Console.ReadLine().Split();
                    grafo.insertEdge(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
                    break;
                case "3":
                    Console.Write("Vértice: ");
                    grafo.removeVertex(int.Parse(Console.ReadLine()));
                    break;
                case "4":
                    Console.Write("V1 V2: ");
                    parts = Console.ReadLine().Split();
                    grafo.removeEdge(int.Parse(parts[0]), int.Parse(parts[1]));
                    break;
                case "5":
                    Console.Write("V1 V2: ");
                    parts = Console.ReadLine().Split();
                    Console.WriteLine(grafo.areAdjacent(int.Parse(parts[0]), int.Parse(parts[1])));
                    break;
                case "6":
                    Console.Write("Origem Destino: ");
                    parts = Console.ReadLine().Split();
                    grafo.Dijkstra(int.Parse(parts[0]), int.Parse(parts[1]));
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
