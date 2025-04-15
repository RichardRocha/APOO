// Trabalho de APOOI - Implementação de TAD Grafo (versão com matriz de adjacência e indegree)
// Grupo: Arlyson RA: 113627 , Richard Rocha RA:113760 , Kauan Melo RA:113471.

using System;

class Grafo
{
    // Matriz que guarda as conexões entre os vértices
    int[,] mAdjacencia;
    // Vetor que armazena o número de arestas que chegam em cada vértice
    int[] indegree;
    // Quantidade total de vértices
    int nos;

    // Construtor da classe Grafo, define o tamanho e inicializa as estruturas
    public Grafo(int totalNos)
    {
        nos = totalNos;
        mAdjacencia = new int[nos, nos];
        indegree = new int[nos];
    }

    // Função para adicionar uma conexão (aresta) entre dois vértices
    public void AdicionarAresta(int inicio, int fim)
    {
        mAdjacencia[inicio, fim] = 1;
    }

    // Função para remover uma conexão entre dois vértices
    public void RemoverAresta(int inicio, int fim)
    {
        mAdjacencia[inicio, fim] = 0;
    }

    // Verifica se dois vértices são ligados diretamente
    public bool SaoAdjacentes(int v1, int v2)
    {
        return mAdjacencia[v1, v2] == 1;
    }

    // Mostra a matriz de adjacência completa
    public void MostrarMatriz()
    {
        Console.WriteLine("Matriz de Adjacência:");
        for (int i = 0; i < nos; i++)
        {
            for (int j = 0; j < nos; j++)
            {
                Console.Write($"{mAdjacencia[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    // Calcula o indegree (quantas arestas entram) de cada vértice
    public void CalcularIndegree()
    {
        for (int i = 0; i < nos; i++) indegree[i] = 0;

        for (int j = 0; j < nos; j++)
            for (int i = 0; i < nos; i++)
                if (mAdjacencia[i, j] == 1) indegree[j]++;
    }

    // Mostra o indegree de todos os vértices
    public void MostrarIndegree()
    {
        Console.WriteLine("Indegree de cada vértice:");
        for (int i = 0; i < nos; i++)
            Console.WriteLine($"Vértice {i}: {indegree[i]}");
    }

    // Procura um vértice com indegree 0
    public int EncontraI0()
    {
        for (int i = 0; i < nos; i++)
            if (indegree[i] == 0)
                return i;
        return -1;
    }

    // Decrementa o indegree dos vértices que estavam ligados ao vértice removido
    public void DecrementaIndegree(int v)
    {
        indegree[v] = -1;
        for (int j = 0; j < nos; j++)
            if (mAdjacencia[v, j] == 1)
                indegree[j]--;
    }

    // Algoritmo de Dijkstra para encontrar o menor caminho entre dois vértices
    public void Dijkstra(int origem, int destino)
    {
        int[] dist = new int[nos];
        int[] anterior = new int[nos];
        bool[] visitado = new bool[nos];

        for (int i = 0; i < nos; i++)
        {
            dist[i] = int.MaxValue; // Inicia as distâncias como infinitas
            anterior[i] = -1; // Nenhum vértice anterior definido
        }

        dist[origem] = 0; // A distância da origem para ela mesma é 0

        for (int i = 0; i < nos; i++)
        {
            int u = -1;
            for (int j = 0; j < nos; j++)
                if (!visitado[j] && (u == -1 || dist[j] < dist[u]))
                    u = j;

            if (dist[u] == int.MaxValue)
                break;

            visitado[u] = true;

            for (int v = 0; v < nos; v++)
            {
                if (mAdjacencia[u, v] == 1 && dist[v] > dist[u] + 1)
                {
                    dist[v] = dist[u] + 1;
                    anterior[v] = u;
                }
            }
        }

        if (dist[destino] == int.MaxValue)
        {
            Console.WriteLine("Não há caminho.");
            return;
        }

        var caminho = new System.Collections.Generic.List<int>();
        int atual = destino;
        while (atual != -1)
        {
            caminho.Add(atual);
            atual = anterior[atual];
        }
        caminho.Reverse();

        Console.WriteLine($"Caminho mínimo: {string.Join(" -> ", caminho)}");
        Console.WriteLine($"Custo: {dist[destino]}");
    }
}
