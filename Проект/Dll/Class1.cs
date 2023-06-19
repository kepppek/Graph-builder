using System;
using System.Collections.Generic;
using System.Linq;

namespace Dll
{
    /// <summary>
    /// Сериализация данных о графе в текстовый файл
    /// </summary>
    public class XML
    {
        public int n;
        public List<int> X = new List<int>();
        public List<int> Y = new List<int>();
        public List<int> M = new List<int>();
    }
    /// <summary>
    /// Методы для формы соединения узлов графа
    /// </summary>
    public class Conect
    {
        public static int top_1;
        public static int top_2;
        public static char direction;
        public static int num_1;
        public static int num_2;
        public static int num_3;
    }
    /// <summary>
    /// Алгоритмы поиска максимального потока в графе
    /// </summary>
    public class MaxFlow
    {
        /// <summary>
        /// Алгоритм проталкивания предпотока 
        /// </summary>
        /// <param name="cap">Матрица смежности</param>
        /// <param name="s">Из</param>
        /// <param name="t">В</param>
        /// <returns>Максимальный поток</returns>
        public static int PushRelabel(int[,] cap, int s, int t)
        {
            int n = cap.GetLength(1);

            int[] h = new int[n];
            h[s] = n - 1;

            int[] maxh = new int[n];

            int[,] f = new int[n, n];
            int[] e = new int[n];

            for (int i = 0; i < n; ++i)
            {
                f[s, i] = cap[s, i];
                f[i, s] = -f[s, i];
                e[i] = cap[s, i];
            }

            for (int sz = 0; ;)
            {
                if (sz == 0)
                {
                    for (int i = 0; i < n; ++i)
                        if (i != s && i != t && e[i] > 0)
                        {
                            if (sz != 0 && h[i] > h[maxh[0]])
                                sz = 0;
                            maxh[sz++] = i;
                        }
                }
                if (sz == 0)
                    break;
                while (sz != 0)
                {
                    int i = maxh[sz - 1];
                    bool pushed = false;
                    for (int j = 0; j < n && e[i] != 0; ++j)
                    {
                        if (h[i] == h[j] + 1 && cap[i, j] - f[i, j] > 0)
                        {
                            int df = Math.Min(cap[i, j] - f[i, j], e[i]);
                            f[i, j] += df;
                            f[j, i] -= df;
                            e[i] -= df;
                            e[j] += df;
                            if (e[i] == 0)
                                --sz;
                            pushed = true;
                        }
                    }
                    if (!pushed)
                    {
                        h[i] = int.MaxValue;
                        for (int j = 0; j < n; ++j)
                            if (h[i] > h[j] + 1 && cap[i, j] - f[i, j] > 0)
                                h[i] = h[j] + 1;
                        if (h[i] > h[maxh[0]])
                        {
                            sz = 0;
                            break;
                        }
                    }
                }
            }

            int flow = 0;
            for (int i = 0; i < n; i++)
                flow += f[s, i];

            return flow;
        }
        /// <summary>
        /// Алгоритм поиска в ширину (Форд - Фалкерсон) 
        /// </summary>
        /// <param name="rGraph">матрица смежности</param>
        /// <param name="s">исток</param>
        /// <param name="t">сток</param>
        /// <param name="parent">массив посещенний</param>
        /// <returns>Возвращает true, если есть путь от источника 's' к стоку 
        ///'t' в матрице смежности.Также заполняет parent[] для хранения пути</returns>
        public static bool BFS_1(int[,] rGraph, int s, int t, int[] parent)
        {
            int V = rGraph.GetLength(1);
            // Создаем  массив посещений и отмечаем все вершины как непосещенные
            bool[] visited = new bool[V];
            for (int i = 0; i < V; ++i)
                visited[i] = false;

            // Создаем очередь, поставим в очередь исходную вершину и отметим
            // исходную вершину как посещенную
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            visited[s] = true;
            parent[s] = -1;

            // Стандартный цикл BFS
            while (queue.Count() != 0)
            {
                int u = queue.Dequeue();

                for (int v = 0; v < V; v++)
                {
                    if (visited[v] == false && rGraph[u, v] > 0)
                    {
                        queue.Enqueue(v);
                        parent[v] = u;
                        visited[v] = true;
                    }
                }
            }
            // Если мы достигли стока в BFS, начиная с источника, то 
            // возвращает true, иначе false
            return (visited[t] == true);
        }


        /// <summary>
        ///Алгоритм Форда — Фалкерсона
        /// </summary>
        /// <param name="graph">матрица смежности</param>
        /// <param name="s">исток</param>
        /// <param name="t">сток</param>
        /// <returns>Возвращает максимальный поток от s до t на заданном графике</returns>
        public static int Algorithm_Ford_Falkerson(int[,] graph, int s, int t, ref int[] x, ref int[] y)
        {
            int u, v;
            int V = graph.GetLength(1);

            int[,] rGraph = new int[V, V];

            for (u = 0; u < V; u++)
                for (v = 0; v < V; v++)
                    rGraph[u, v] = graph[u, v];

            // Этот массив заполняется методом BFS и сохраняет путь
            int[] parent = new int[V];

            int max_flow = 0; // Изначально потока нет

            // Увеличить поток, пока есть путь от источника 
            // до стока
            int i = 0;
            while (BFS_1(rGraph, s, t, parent))
            {

                // Ищем максимальный поток по найденному пути.
                int path_flow = int.MaxValue;
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    path_flow = Math.Min(path_flow, rGraph[u, v]);                   
                    x[i] = u; y[i] = v;
                    i++;
                }

                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] -= path_flow;
                    rGraph[v, u] += path_flow;
                }
                // Добавим поток пути к общему потоку
                max_flow += path_flow;
            }
            // Вернем общий поток
            return max_flow;
        }
        /// <summary>
        /// Алгоритм Эдмондса — Карпа
        /// </summary>
        /// <param name="capacityMatrix">матрица смежности</param>
        /// <param name="source">исток</param>
        /// <param name="sink">сток</param>
        /// <returns>Возвращает максимальный поток от s до t на заданном графике</returns>
        public static int Algorithm_Edmonds_Karp(int[,] capacityMatrix, int source, int sink)
        {
            int n = capacityMatrix.GetLength(0);

            int f = 0; // начальный поток равен 0
            int[,] legalFlows = new int[n, n];

            while (true)
            {
                int[] p;
                int m = BFS_2(capacityMatrix, source, sink, legalFlows, out p);

                if (m == 0) break;
                f += m;

                int v = sink;

                while (v != source)
                {
                    int u = p[v];
                    legalFlows[u, v] += m;
                    legalFlows[v, u] -= m;
                    v = u;
                }
            }
            return f;
        }
        /// <summary>
        /// Алгоритм поиска в ширину (Эдмондса — Карпа) 
        /// </summary>
        /// <param name="rGraph">матрица смежности</param>
        /// <param name="s">исток</param>
        /// <param name="t">сток</param>
        /// <param name="parent">массив посещенний</param>
        /// <returns>Возвращает true, если есть путь от источника 's' к стоку 
        ///'t' в матрице смежности.Также заполняет parent[] для хранения пути</returns>
        private static int BFS_2(int[,] capacityMatrix, int source, int sink, int[,] legalFlows, out int[] p)
        {
            int n = capacityMatrix.GetLength(1);
            p = new int[n];
            for (int u = 0; u < n; u++)
                p[u] = -1;

            p[source] = -2; // убедимся, что источник не обнаружен повторно
            int[] m = new int[n]; // емкость найденного пути к узлу
            m[source] = int.MaxValue;

            Queue<int> q = new Queue<int>();
            q.Enqueue(source);

            while (q.Count > 0)
            {
                int u = q.Dequeue();
                for (int v = 0; v < capacityMatrix.GetLength(1); v++)
                {
                    // если имеется доступная емкость, а v не виден ранее в поиске
                    if (capacityMatrix[u, v] - legalFlows[u, v] > 0 &&
                        p[v] == -1)
                    {
                        p[v] = u;
                        m[v] = Math.Min(m[u], capacityMatrix[u, v] - legalFlows[u, v]);

                        if (v != sink) q.Enqueue(v);
                        else return m[sink];
                    }
                }
            }
            return 0;
        }

        public static int[] d;
        public static int[] q;
        /// <summary>
        /// Находит, можно ли отправить еще потоки из s в t. 
        /// </summary>
        /// <param name="graf">матрица</param>
        /// <param name="s">исток</param>
        /// <param name="t">сток</param>
        /// <param name="legalFlows">копия матрицы</param>
        /// <returns>true\false</returns>
        public static bool BFS_3(int[,] graf, int s, int t, int[,] legalFlows)
        {
            int n = graf.GetLength(1);
            d = new int[n];
            q = new int[n];
            int qh = 0, qt = 0;
            q[qt++] = s;
            for (int i = 0; i < n; i++) d[i] = -1;
            d[s] = 0;

            while (qh < qt)
            {
                int v = q[qh++];
                for (int to = 0; to < n; ++to)
                    if (d[to] == -1 && legalFlows[v, to] < graf[v, to])
                    {
                        q[qt++] = to;
                        d[to] = d[v] + 1;
                    }
            }
            return d[t] != -1;
        }
        /// <summary>
        /// Ищет максимальное число в потоке
        /// </summary>
        /// <param name="u">текущая вершина</param>
        /// <param name="flow">текущий поток отправляется вызовом родительской функции </param>
        /// <param name="t">сток</param>
        /// <param name="start">хранит количество исследованных ребер</param>
        /// <param name="graf">матрица</param>
        /// <param name="legalFlows"></param>
        /// <returns></returns>
        public static int DFS(int u, int flow, int t, int[] start, int[,] graf, int[,] legalFlows)
        {
            if (u == t) return flow;
            int n = graf.GetLength(1);

            for (int to = start[u]; to < n; ++to)
            {
                if (d[to] == d[u] + 1 && legalFlows[u, to] < graf[u, to])
                {
                    // найдем минимальный расход от u до t
                    int curr_flow = Math.Min(flow, graf[u, to] - legalFlows[u, to]);
                    int temp_flow = DFS(to, curr_flow, t, start, graf, legalFlows);

                    // поток больше нуля
                    if (temp_flow > 0)
                    {
                        // добавиим поток к текущему ребру
                        legalFlows[u, to] += temp_flow;
                        legalFlows[t, u] -= temp_flow;
                        return temp_flow;
                    }
                }
            }
            return 0;
        }
        /// <summary>
        /// Алгоритм Диница
        /// </summary>
        /// <param name="graf">матрица</param>
        /// <param name="s">исток</param>
        /// <param name="t">сток</param>
        /// <returns>Возвращает максимальный поток от s до t на заданном графике</returns>
        public static int Algorithm_Dinitz(int[,] graf, int s, int t)
        {
            int total = 0;
            int n = graf.GetLength(0);
            int[,] legalFlows = new int[n, n];

            while (BFS_3(graf, s, t, legalFlows))
            {
                int[] start = new int[n];
                int flow = DFS(s, int.MaxValue, t, start, graf, legalFlows);
                while (flow != 0)
                {
                    total += flow;
                    flow = DFS(s, int.MaxValue, t, start, graf, legalFlows);
                }
            }
            return total;
        }
    }
    /// <summary>
    /// Алгоритмы поиска кратчайшего пути в графе
    /// </summary>
    public class ShortestDistance
    {
        //Хранит путь от узла к узлу
        static string way = "";

        /// <summary>
        /// Алгоритм Дейкстры
        /// </summary>
        /// <param name="adjacencyMatrix">Матрица смежности</param>
        /// <param name="startVertex">Из</param>
        /// <param name="end">В</param>
        /// <returns>Текст с дистанцией и путем к узлу</returns>
        public static string Dijkstra(int[,] adjacencyMatrix,int startVertex,int end)
        {
            int nVertices = adjacencyMatrix.GetLength(0);

            int[] shortestDistances = new int[nVertices];

            bool[] added = new bool[nVertices];

            for (int vertexIndex = 0; vertexIndex < nVertices;
                                                vertexIndex++)
            {
                shortestDistances[vertexIndex] = int.MaxValue;
                added[vertexIndex] = false;
            }

            shortestDistances[startVertex] = 0;

            int[] parents = new int[nVertices];
            parents[startVertex] = -1;

     
              for (int i = 0; i < nVertices; i++)
              {


                int nearestVertex = -1;
                int shortestDistance = int.MaxValue;
                for (int vertexIndex = 0;
                        vertexIndex < nVertices;
                        vertexIndex++)
                {
                    if (!added[vertexIndex] &&
                        shortestDistances[vertexIndex] <
                        shortestDistance)
                    {
                        nearestVertex = vertexIndex;
                        shortestDistance = shortestDistances[vertexIndex];
                    }
                }
                if (nearestVertex == -1) continue;
                added[nearestVertex] = true;


                for (int vertexIndex = 0;
                        vertexIndex < nVertices;
                        vertexIndex++)
                {
                    int edgeDistance = adjacencyMatrix[nearestVertex, vertexIndex];

                    if (edgeDistance > 0
                        && ((shortestDistance + edgeDistance) <
                            shortestDistances[vertexIndex]))
                    {
                        parents[vertexIndex] = nearestVertex;
                        shortestDistances[vertexIndex] = shortestDistance +
                                                        edgeDistance;
                    }
                }
            }
            way = "";

            printPath(end, parents);

            if (shortestDistances[end] == int.MaxValue) return "Пути нет.";
            return "Дистанция = " + shortestDistances[end] + "\r\nПуть = " + way.Remove(way.Length-1);
        }

        /// <summary>
        /// Метод поиска пути 
        /// </summary>
        /// <param name="currentVertex">Количество узлов</param>
        /// <param name="parents">Пути</param>
        private static void printPath(int currentVertex,int[] parents)
        {

            if (currentVertex == -1)
            {
                return;
            }
            printPath(parents[currentVertex], parents);
            way += currentVertex + 1 + " ";
        }

        public struct Edge
        {
            public int Source;
            public int Destination;
            public int Weight;
        }

        public struct Graph
        {
            public int VerticesCount;
            public int EdgesCount;
            public Edge[] edge;
        }

        public static Graph CreateGraph(int verticesCount, int edgesCount)
        {
            Graph graph = new Graph();
            graph.VerticesCount = verticesCount;
            graph.EdgesCount = edgesCount;
            graph.edge = new Edge[graph.EdgesCount];

            return graph;
        }

        /// <summary>
        /// Алгоритм Белмана-Форда
        /// </summary>
        /// <param name="matrix">Матрица смежности</param>
        /// <param name="source">Из</param>
        /// <param name="end">в</param>
        /// <returns>Текст с дистанцией</returns>
        public static string BellmanFord(int [,] matrix, int source, int end)
        {
            Graph graph = MatrixToList(matrix);
            int verticesCount = graph.VerticesCount;
            int edgesCount = graph.EdgesCount;
            int[] distance = new int[verticesCount];

            for (int i = 0; i < verticesCount; i++)
                distance[i] = int.MaxValue;

            distance[source] = 0;

            for (int i = 1; i <= verticesCount - 1; ++i)
            {
                for (int j = 0; j < edgesCount; ++j)
                {
                    int u = graph.edge[j].Source;
                    int v = graph.edge[j].Destination;
                    int weight = graph.edge[j].Weight;

                    if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                        distance[v] = distance[u] + weight;
                }
            }

            for (int i = 0; i < edgesCount; ++i)
            {
                int u = graph.edge[i].Source;
                int v = graph.edge[i].Destination;
                int weight = graph.edge[i].Weight;

                if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                    return "Граф содержит отрицательный цикл.";
            }
            if (distance[end] == int.MaxValue) return "Пути нет.";
            return "Дистанция = " + distance[end].ToString();
        }
        public static Graph MatrixToList(int[,] matrix)
        {
            int n = matrix.GetLength(1);
            int verticesCount = n;
            int edgesCount = 0;

            //считаем количество ребер
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] != 0)
                        edgesCount++;
                }
            }

            //создаем граф в виде списка ребер
            Graph graph = CreateGraph(verticesCount, edgesCount);

            int k = 0;

            //записываем ребра в список
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    if (matrix[i, j] != 0)
                    {
                        graph.edge[k].Source = i;
                        graph.edge[k].Destination = j;
                        graph.edge[k].Weight = matrix[i, j];

                        k++;
                    }
                }
            }
            return graph;
        }
    }
}


