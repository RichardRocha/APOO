README - TAD Grafo (Matriz de Adjacência + Indegree + Dijkstra)
Grupo: Arlyson (113627), Richard Rocha (113760), Kauan Melo (113471)

Descrição:
Implementação de um grafo direcionado usando matriz de adjacência. Permite adicionar/remover arestas, ver a matriz, verificar adjacência, mostrar indegree e calcular o caminho mínimo com Dijkstra.

Ao iniciar o programa, o usuário informa o número de vértices do grafo. Em seguida, é apresentado um menu interativo com as opções:

1-Adicionar aresta — Conecta dois vértices (grafo direcionado).

2-Remover aresta — Remove a conexão entre dois vértices.

3-Mostrar matriz de adjacência — Mostra a estrutura do grafo.

4-Verificar adjacência — Informa se dois vértices são conectados diretamente.

5-Mostrar indegree — Exibe quantas arestas chegam a cada vértice.

6-Caminho mínimo (Dijkstra) — Apresenta o caminho mínimo entre dois vértices e o custo.

0-Sair — Encerra o programa.


Limitações/Bugs:
- Não valida entradas (pode dar erro se digitar letra ou número inválido).
- Dijkstra funciona só com pesos iguais a 1.
- Indegree só atualiza se o usuário pedir (opção 5).
- Não detecta ciclos.

Exemplo de Utilização do código:

Quantidade de vértices: 6

Menu:
1 - Adicionar aresta
...
Opção: 1
Início e fim(ex:0 1): 0 1

Opção: 1
Início e fim(ex:0 1): 0 2

Opção: 1
Início e fim(ex:0 1): 1 3

Opção: 1
Início e fim(ex:0 1): 2 3

Opção: 1
Início e fim(ex:0 1): 3 4

Opção: 1
Início e fim(ex:0 1): 4 5

Opção: 3
// Mostra a matriz de adjacência
-Saída:
Matriz de Adjacência:
0 1 1 0 0 0 
0 0 0 1 0 0 
0 0 0 1 0 0 
0 0 0 0 1 0 
0 0 0 0 0 1 
0 0 0 0 0 0 
Opção: 5
// Mostra o indegree de cada vértice
-Saída:
Indegree de cada vértice:
Vértice 0: 0
Vértice 1: 1
Vértice 2: 1
Vértice 3: 2
Vértice 4: 1
Vértice 5: 1
Opção: 6
Origem e destino(ex:0 5): 0 5
// Mostra o caminho mínimo e o custo
-Saída:
Caminho mínimo: 0 -> 1 -> 3 -> 4 -> 5
Custo: 4
Opção: 0
// Sai do programa
