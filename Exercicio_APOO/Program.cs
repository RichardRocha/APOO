// Trabalho de APOOI - Implementação de TAD Grafo (versão com matriz de adjacência e indegree)
// Grupo: Arlyson RA: 113627 , Richard Rocha RA:113760 , Kauan Melo RA:113471.
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
                    Console.Write("Início e fim(ex:0 1): ");
                    var a = Console.ReadLine().Split();
                    grafo.AdicionarAresta(int.Parse(a[0]), int.Parse(a[1]));
                    break;
                case "2":
                    Console.Write("Início e fim(ex:0 1): ");
                    var b = Console.ReadLine().Split();
                    grafo.RemoverAresta(int.Parse(b[0]), int.Parse(b[1]));
                    break;
                case "3":
                    grafo.MostrarMatriz();
                    break;
                case "4":
                    Console.Write("V1 e V2(ex:0 1): ");
                    var c = Console.ReadLine().Split();
                    bool adj = grafo.SaoAdjacentes(int.Parse(c[0]), int.Parse(c[1]));
                    if (adj)
                    {
                        Console.WriteLine("Sim é adjacente.");
                    }
                    else
                    {
                        Console.WriteLine("Não é adjacente.");
                    }
                    break;
                case "5":
                    grafo.CalcularIndegree();
                    grafo.MostrarIndegree();
                    break;
                case "6":
                    Console.Write("Origem e destino(ex:0 5): ");
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
