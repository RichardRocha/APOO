using System;
class Programa
{
    static void Main()
    {
        // Pede ao usuário a quantidade de vértices
        Console.Write("Quantidade de vértices: ");
        int total = int.Parse(Console.ReadLine());
        var grafo = new Grafo(total);

        // Loop principal do programa
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1 - Adicionar aresta");
            Console.WriteLine("2 - Remover aresta");
            Console.WriteLine("3 - Mostrar matriz de adjacência");
            Console.WriteLine("4 - Verificar adjacência");
            Console.WriteLine("5 - Mostrar indegree");
            Console.WriteLine("6 - Caminho mínimo (Dijkstra)");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");

            string op = Console.ReadLine();
            if (op == "0") break; // Sai do programa se digitar 0

            switch (op)
            {
                case "1":
                    Console.Write("Início e fim: ");
                    var a = Console.ReadLine().Split();
                    grafo.AdicionarAresta(int.Parse(a[0]), int.Parse(a[1]));
                    break;
                case "2":
                    Console.Write("Início e fim: ");
                    var b = Console.ReadLine().Split();
                    grafo.RemoverAresta(int.Parse(b[0]), int.Parse(b[1]));
                    break;
                case "3":
                    grafo.MostrarMatriz();
                    break;
                case "4":
                    Console.Write("V1 e V2: ");
                    var c = Console.ReadLine().Split();
                    bool adj = grafo.SaoAdjacentes(int.Parse(c[0]), int.Parse(c[1]));
                    if (adj)
                    {
                        Console.WriteLine("Sim.");
                    }
                    else
                    {
                        Console.WriteLine("Não.");
                    }
                    break;
                case "5":
                    grafo.CalcularIndegree();
                    grafo.MostrarIndegree();
                    break;
                case "6":
                    Console.Write("Origem e destino: ");
                    var d = Console.ReadLine().Split();
                    grafo.Dijkstra(int.Parse(d[0]), int.Parse(d[1]));
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
